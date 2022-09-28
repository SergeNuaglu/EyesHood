using System.Collections;
using UnityEngine;
using UnityEngine.EventSystems;

public class Joystick : MonoBehaviour, IPointerDownHandler, IDragHandler, IPointerUpHandler
{
    [SerializeField] private float _handleMoveRange;
    [SerializeField] private float _deadZone;
    [SerializeField] private RectTransform _background;
    [SerializeField] private RectTransform _handle;
    [SerializeField] private Canvas _canvas;

    private Vector2 _handlePositionDelta;
    private Vector2 _radius;
    private Coroutine _lowDeltaRoutine;

    public Vector2 HandlePositionDelta =>_handlePositionDelta;

    private void Start()
    {
        Vector2 center = new Vector2(0.5f, 0.5f);
        _background.pivot = center;
        _handle.anchorMin = center;
        _handle.anchorMax = center;
        _handle.pivot = center;
        _radius = _background.sizeDelta / 2;
        _handle.anchoredPosition = Vector2.zero;
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        if (_lowDeltaRoutine != null)
            StopCoroutine(_lowDeltaRoutine);

        _handlePositionDelta = GetDelta(eventData.position);
        MoveHandle();
    }

    public void OnDrag(PointerEventData eventData)
    {
        _handlePositionDelta = GetDelta(eventData.position);
        MoveHandle();
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        _lowDeltaRoutine = StartCoroutine(LowDelta());
    }

    private Vector2 GetDelta(Vector2 pointerPosition)
    {
        Vector2 delta = (pointerPosition - (Vector2)_background.position) / (_radius * _canvas.scaleFactor);
        
        if (delta.magnitude > _deadZone)
        {
            if (delta.magnitude > 1)
                delta = delta.normalized;
        }
        else
            delta = Vector2.zero;

        return delta;
    }

    private void MoveHandle()
    {
        _handle.anchoredPosition = _handlePositionDelta * _radius * _handleMoveRange;
    }

    private IEnumerator LowDelta()
    {
        int frameCount = 1;

        for (int i = 1; i <= frameCount; i++)
        {
            _handlePositionDelta -= _handlePositionDelta / frameCount * i;
            MoveHandle();
            yield return null;
        }
    }
}