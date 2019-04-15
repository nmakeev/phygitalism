using UnityEngine;
using UnityEngine.UI;

public class SpeedSlider : MonoBehaviour
{
  [SerializeField] private Engine _engine;
  [SerializeField] private Slider _slider;

  private void Awake()
  {
    _engine.OnSelectBall += SelectBallHandler;
    _slider.onValueChanged.AddListener(SliderValueChanged);
  }

  private void OnDestroy()
  {
    _engine.OnSelectBall -= SelectBallHandler;
    _slider.onValueChanged.RemoveListener(SliderValueChanged);
  }

  private void SliderValueChanged(float value)
  {
    _engine.selectedBall.speed = value;
  }

  private void SelectBallHandler(Ball ball)
  {
    _slider.value = ball.speed;
  }
}
