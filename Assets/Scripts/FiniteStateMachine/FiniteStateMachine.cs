using System.Collections.Generic;
using UnityEngine;

public class FiniteStateMachine : MonoBehaviour
{
    [SerializeField] private State _firstState;
    [SerializeField] private List<Transition> _allTransitions;

    private State _currentState;
    private State _nextState;
    private Player _target;

    private void Start()
    {
        Reset(_firstState);

        foreach (var transition in _allTransitions)
        {
            transition.Init(_target);
            transition.enabled = true;
        }
    }

    private void Update()
    {
        if (_currentState == null)
            return;

        _nextState = _currentState.GetNextState();

        if (_nextState != null)
            Transit(_nextState);
    }

    public void Init(Player target)
    {
        _target = target;
    }

    private void Reset(State startState)
    {
        _currentState = startState;

        if (_currentState != null)
            _currentState.Enter(_target);
    }

    private void Transit(State nextState)
    {
        if (_currentState != null)
            _currentState.Exit();

        _currentState = nextState;

        if (_currentState != null)
            _currentState.Enter(_target);

        foreach (var transition in _allTransitions)
        {
            transition.SwitchOffNeedTransit();
        }
    }
}
