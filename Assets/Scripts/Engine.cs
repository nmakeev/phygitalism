using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Engine : MonoBehaviour
{
  public event UnityAction<Ball> OnSelectBall = delegate { };

  [SerializeField] private JsonTrajectoryParser _parser;
  [SerializeField] private List<Ball> _balls;
  [SerializeField] private Ball _selectedBall;
  [SerializeField] private int _selectedBallIndex;

  public Ball selectedBall => _selectedBall;

  public void NextBall()
  {
    _selectedBallIndex = _selectedBallIndex == _balls.Count - 1 ? 0 : _selectedBallIndex + 1;
    SelectBall(_selectedBallIndex);
  }

  public void PreviousBall()
  {
    _selectedBallIndex = _selectedBallIndex == 0 ? _balls.Count - 1 : _selectedBallIndex - 1;
    SelectBall(_selectedBallIndex);
  }

  private void Start()
  {
    _parser.Init();
    foreach (var ball in _balls)
      ball.Init();

    if (_selectedBall == null && _balls.Count > 0)
    {
      SelectBall(0);
    }
  }

  private void SelectBall(int index)
  {
    if (_selectedBall != null)
      _selectedBall.Deselect();
    _selectedBallIndex = index;
    _selectedBall = _balls[index];
    OnSelectBall(_selectedBall);
    _selectedBall.Select();
  }
}
