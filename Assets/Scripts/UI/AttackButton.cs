using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class AttackButton : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    [SerializeField] private Image _attackTypeImage;

    public event UnityAction AtackButtonPressed;
    public event UnityAction AtackButtonReleased;

    public void OnPointerDown(PointerEventData eventData)
    {
        AtackButtonPressed?.Invoke();
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        AtackButtonReleased?.Invoke();
    }

    public void SetAttackTypeIcon(Sprite targetIcon)
    {
        _attackTypeImage.sprite = targetIcon;
    }
}
