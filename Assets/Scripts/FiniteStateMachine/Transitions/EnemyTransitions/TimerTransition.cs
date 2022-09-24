using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimerTransition : Transition
{
    [SerializeField] private float _time;

    private float _lastTime;

    private void OnDisable()
    {
        _lastTime = _time;
    }

    private void Start()
    {
        _lastTime = _time;
    }

    private void Update()
    {
        if (_lastTime <= 0)
            NeedTransit = true;

        _lastTime -= Time.deltaTime;
    }
}
