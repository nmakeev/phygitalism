using TMPro;
using UnityEngine;

namespace UI
{
  public class NameLabel : MonoBehaviour
  {
    [SerializeField] private Engine _engine;
    [SerializeField] private TextMeshProUGUI _nameLabel;

    private void Awake()
    {
      _engine.OnSelectBall += SelectBallHandler;
    }

    private void OnDestroy()
    {
      _engine.OnSelectBall -= SelectBallHandler;
    }

    private void SelectBallHandler(Ball ball)
    {
      _nameLabel.text = ball.name;
    }
  }
}