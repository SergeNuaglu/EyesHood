using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTracker : MonoBehaviour
{
    [SerializeField] private Player _player;
    [SerializeField] private float _damping;
    [SerializeField] private float _xOffset;
    [SerializeField] private float _xLefLimit;
    [SerializeField] private float _xRightLimit;

    private Vector3 _targetPosition;
    private bool _isRightDirection;

    private void LateUpdate()
    {
        if (_player.transform.localScale.x < 0)
            _isRightDirection = false;
        else
            _isRightDirection = true;

        SetTargetPosition();
        transform.position = Vector3.Lerp(transform.position, _targetPosition, _damping * Time.deltaTime);
    }

    private void SetTargetPosition()
    {
        if (_isRightDirection)
            _targetPosition = new Vector3(_player.transform.position.x + _xOffset, _player.transform.position.y, transform.position.z);
        else
            _targetPosition = new Vector3(_player.transform.position.x - _xOffset, _player.transform.position.y, transform.position.z);

        _targetPosition.x = Mathf.Clamp(_targetPosition.x, _xLefLimit, _xRightLimit);
    }
}
