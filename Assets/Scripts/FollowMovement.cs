using UnityEngine;

public class FollowMovement : MonoBehaviour
{
  [SerializeField] private Engine _engine;
  [SerializeField] private SwipeMediator _swipeMediator;
  [SerializeField] private float _maxRotation;

  private Transform _objectToFollow;
  private float _moveDirection;

  private void Awake()
  {
    _engine.OnSelectBall += SelectBallHandler;
    _swipeMediator.OnMove += MoveHandler;
  }

  private void SelectBallHandler(Ball ball)
  {
    _objectToFollow = ball.transform;
  }

  private void MoveHandler(Vector2 moveDirection)
  {
    _moveDirection = Mathf.Clamp(moveDirection.x, -_maxRotation, _maxRotation);
  }

  private void Update()
  {
    transform.Rotate(0, _moveDirection * Time.deltaTime, 0);
    transform.localPosition = _objectToFollow.localPosition;
    transform.LookAt(_objectToFollow.localPosition);
    _moveDirection = 0;
  }
}
