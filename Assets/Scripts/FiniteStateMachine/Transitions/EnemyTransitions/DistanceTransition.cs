using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DistanceTransition : Transition
{
    [SerializeField] private float _transitionRangeX;
    [SerializeField] private float _transitionRangeY;

    private float _lowerRangeY;
    private float _upperRangeY;

    private void Update()
    {
        _lowerRangeY = transform.position.y - _transitionRangeY;
        _upperRangeY = transform.position.y + _transitionRangeY;

        if (Target.transform.position.y > _lowerRangeY && Target.transform.position.y < _upperRangeY)
        {
            if (Vector2.Distance(transform.position, Target.transform.position) <= _transitionRangeX)
                NeedTransit = true;
        }
    }
}
