using System;
using System.Collections.Generic;
using UnityEngine;

public class JsonTrajectoryParser : MonoBehaviour
{
  [SerializeField] private List<JsonTrajectoryPair> _jsonTrajectoryPairs;

  public void Init()
  {
    foreach (var pair in _jsonTrajectoryPairs)
    {
      var jsonTrajectory = JsonUtility.FromJson<JsonTrajectory>(pair.trajectoryJson.text);
      pair.trajectoryReceiver.SetTrajectory(FromJsonTrajectory(jsonTrajectory));
    }
  }

  private List<Vector3> FromJsonTrajectory(JsonTrajectory trajectory)
  {
    if (trajectory.x.Length != trajectory.y.Length || trajectory.y.Length != trajectory.z.Length)
      Debug.LogWarning("JsonTrajectory has different size of coordinate lists");

    var size = Math.Min(trajectory.x.Length, trajectory.y.Length);
    size = Math.Min(size, trajectory.z.Length);


    var result = new List<Vector3>(size);
    for (var i = 0; i < size; i++)
      result.Add(new Vector3(trajectory.x[i], trajectory.y[i], trajectory.z[i]));
    return result;
  }
}