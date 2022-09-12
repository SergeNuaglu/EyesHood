using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimerTransition : Transition
{
    [SerializeField] private float _time;

    private float _lastTime = 0;

    private void Update()
    {
        if (_lastTime <= 0)
        {
            NeedTransit = true;
            _lastTime = _time;
        }

        _lastTime -= Time.deltaTime;
    }
}
