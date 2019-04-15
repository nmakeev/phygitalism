using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class SwipeMediator : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
  public event UnityAction<Vector2> OnMove = delegate { };
  
  private Vector2 originPoint;
  private Vector2 dragPoint;
  private bool isPressed;

  public void OnBeginDrag(PointerEventData eventData)
  {
    isPressed = true;
    originPoint = eventData.position;
  }

  public void OnDrag(PointerEventData eventData)
  {
    dragPoint = eventData.position;
    OnMove(eventData.position - originPoint);
    originPoint = dragPoint;
  }

  public void OnEndDrag(PointerEventData eventData)
  {
  }
}
