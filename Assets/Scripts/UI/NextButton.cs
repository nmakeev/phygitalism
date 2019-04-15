using UnityEngine;
using UnityEngine.UI;

namespace UI
{
  public class NextButton : MonoBehaviour
  {
    [SerializeField] private Button _button;
    [SerializeField] private Engine _engine;

    private void Awake()
    {
      _button.onClick.AddListener(_engine.NextBall);
    }

    private void OnDestroy()
    {
      _button.onClick.RemoveListener(_engine.NextBall);
    }
  }
}