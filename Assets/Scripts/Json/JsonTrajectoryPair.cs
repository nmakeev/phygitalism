using System;
using UnityEngine;

[Serializable]
public class JsonTrajectoryPair
{
  [SerializeField] private TextAsset _trajectoryJson;
  [SerializeField] private Ball _trajectoryReceiver;

  public TextAsset trajectoryJson => _trajectoryJson;
  public Ball trajectoryReceiver => _trajectoryReceiver;
}