using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
  [SerializeField] private float _movementSpeed;
  [SerializeField] private MouseClickMediator _clickMediator;

  private List<Vector3> _trajectory;
  private bool _isMoving;
  private int _trajectoryIndex;
  private bool _isFinished;

  public float speed = 1;

  public void Init()
  {
    MoveToInitialPosition();
    _clickMediator.OnMouseClick += MouseClickHandler;
    _clickMediator.OnDoubleMouseClick += MouseDoubleClickHandler;
  }

  private void MouseDoubleClickHandler()
  {
    if (_isMoving)
      _isMoving = false;
    
    MoveToInitialPosition();
  }

  private void MouseClickHandler()
  {
    if (_isMoving || _isFinished)
      return;

    _isMoving = true;
  }

  public void MoveToInitialPosition()
  {
    transform.localPosition = _trajectory[0];
    _trajectoryIndex = 0;
  }

  private void Update()
  {
    if (!_isMoving)
      return;


    var pathForFrame = _movementSpeed * Mathf.Clamp01(speed) * Time.deltaTime;
    while (pathForFrame > 0)
    {
      var movement_vector = _trajectory[_trajectoryIndex + 1] - transform.localPosition;
      var segmentPath = movement_vector.magnitude;
      if (segmentPath > pathForFrame)
      {
        var normalized = movement_vector / segmentPath;
        transform.localPosition += normalized * pathForFrame;
        break;
      }

      _trajectoryIndex++;
      transform.localPosition = _trajectory[_trajectoryIndex];
      pathForFrame -= segmentPath;

      if (_trajectoryIndex + 1 == _trajectory.Count)
      {
        _isMoving = false;
        _isFinished = true;
        break;
      }
    }
  }

  public void SetTrajectory(List<Vector3> trajectory)
  {
    _trajectory = trajectory;
  }

  public void Deselect()
  {
    if (_isMoving)
      speed = 0;
    _clickMediator.enabled = false;
  }

  public void Select()
  {
    _clickMediator.enabled = true;
  }
}
