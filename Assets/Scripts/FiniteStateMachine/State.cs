using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(HasherAnimationsNames))]

public class State : MonoBehaviour
{
    [SerializeField] private List<Transition> _stateTransitions;

    protected Animator Animator;
    protected HasherAnimationsNames AnimationNames;

    protected Player Target { get; set; }

    protected virtual void Awake()
    {
        Animator = GetComponent<Animator>();
        AnimationNames = GetComponent<HasherAnimationsNames>();
    }

    public void Enter(Player target)
    {
        if (enabled == false)
        {
            Target = target;
            enabled = true;
        }
    }

    public void Exit()
    {
        enabled = false;
    }

    public State GetNextState()
    {
        foreach (var transition in _stateTransitions)
        {
            if (transition.NeedTransit)
                return transition.TargetState;
        }

        return null;
    }
}
