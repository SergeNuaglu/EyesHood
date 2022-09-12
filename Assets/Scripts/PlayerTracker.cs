using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTracker : MonoBehaviour
{
    [SerializeField] private Player _player;
    [SerializeField] private float _damping;
    [SerializeField] private float _xOffset;
    [SerializeField] private float _leftLimit;
    [SerializeField] private float _rightLimit;
    [SerializeField] private float _upperLimit;
    [SerializeField] private float _bottomLimit;

    private Vector3 _targetPosition;
    private Vector2 _lastPosition;
    private float _yOffset;
    private float _centerPositionX;
    private float _centerPositionY;
    private bool _isRightDirection;

    private void Start()
    {
        _yOffset = transform.position.y - _player.transform.position.y;
        _lastPosition = transform.position;
    }

    private void Update()
    {
        if (_player.transform.localScale.x < 0)
            _isRightDirection = false;
        else
            _isRightDirection = true;

        SetTargetPosition();
        transform.position = Vector3.Lerp(transform.position, _targetPosition, _damping * Time.deltaTime);
        LimitPosition();
    }

    private void SetTargetPosition()
    {
        if (_isRightDirection)
            _targetPosition = new Vector3(_player.transform.position.x + _xOffset, _player.transform.position.y + _yOffset, transform.position.z);
        else
            _targetPosition = new Vector3(_player.transform.position.x - _xOffset, _player.transform.position.y + _yOffset, transform.position.z);
    }

    private void LimitPosition()
    {
        _centerPositionX = Mathf.Clamp(transform.position.x, _leftLimit, _rightLimit);
        _centerPositionY = Mathf.Clamp(transform.position.y, _bottomLimit, _upperLimit);
        transform.position = new Vector3(_centerPositionX, _centerPositionY, transform.position.z);
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawLine(new Vector2(_leftLimit, _bottomLimit), new Vector2(_leftLimit, _upperLimit));
        Gizmos.DrawLine(new Vector2(_leftLimit, _upperLimit), new Vector2(_rightLimit, _upperLimit));
        Gizmos.DrawLine(new Vector2(_rightLimit, _bottomLimit), new Vector2(_rightLimit, _upperLimit));
        Gizmos.DrawLine(new Vector2(_rightLimit, _bottomLimit), new Vector2(_leftLimit, _bottomLimit));
    }
}
