using UnityEngine;
using UnityEngine.Events;

public class MouseClickMediator : MonoBehaviour
{
  [SerializeField] private float _timeout = .2f;
  private bool _firstClick;
  private float _timeSinceFirstClick;
  
  public event UnityAction OnMouseClick = delegate { };
  public event UnityAction OnDoubleMouseClick = delegate { };
  
  private void Update() 
  {
    if (_firstClick && Time.time > (_timeSinceFirstClick + _timeout))
    {
      OnMouseClick();
      _firstClick = false;
    }
  }
 
  private void OnMouseDown() 
  {
    if (_firstClick && Time.time <= (_timeSinceFirstClick + _timeout))
    {
      OnDoubleMouseClick();
      _firstClick = false;
    }
    else
    {
      _firstClick = true;
      _timeSinceFirstClick = Time.time;
    }
  }
}