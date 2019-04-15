using UnityEngine;
using UnityEngine.UI;

namespace UI
{
  public class PreviousButton : MonoBehaviour
  {
    [SerializeField] private Button _button;
    [SerializeField] private Engine _engine;

    private void Awake()
    {
      _button.onClick.AddListener(_engine.PreviousBall);
    }

    private void OnDestroy()
    {
      _button.onClick.RemoveListener(_engine.PreviousBall);
    }
  }
}