using UnityEngine;

public class TimerTransition : Transition
{
    [SerializeField] private float _time;

    private float _lastTime;

    private void Start()
    {
        _lastTime = _time;
    }

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
