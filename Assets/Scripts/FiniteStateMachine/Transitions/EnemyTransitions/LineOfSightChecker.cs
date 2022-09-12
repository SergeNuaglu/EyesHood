using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(Enemy))]


public class LineOfSightChecker : MonoBehaviour
{
    [SerializeField] protected float _transitionRange;
    [SerializeField] private float _rangeYPosition;
    [SerializeField] private ContactFilter2D _filter;

    private float _currentDistance;
    private Vector2 _toTargetDirection;
    private Foot _foot;
    private float _dotResult;
    private Rigidbody2D _rigidbody;
    private readonly RaycastHit2D[] _results = new RaycastHit2D[1];

    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();

        if (GetComponent<Enemy>().Foot != null)
            _foot = GetComponent<Enemy>().Foot;
    }

    public bool Check(Vector2 movementDirection, Vector3 target)
    {
        _currentDistance = Vector2.Distance(transform.position, target);
        _toTargetDirection = target - transform.position;


        if (_currentDistance <= _transitionRange)
        {
            if (target.y < transform.position.y + _rangeYPosition && target.y > transform.position.y - _rangeYPosition)
            {
                int collisionCount = _rigidbody.Cast(movementDirection, _filter, _results, _currentDistance);
                int minCount = 0;

                _dotResult = Vector2.Dot(movementDirection, _toTargetDirection);

                if (_foot != null)
                    return _dotResult > 0 && collisionCount == minCount && _foot.IsGrounded;
                else
                    return _dotResult > 0 && collisionCount == minCount;
            }
        }

        return false;
    }
}
