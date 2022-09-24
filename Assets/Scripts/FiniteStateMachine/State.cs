using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(HasherAnimationsNames))]

public class State : MonoBehaviour
{
    [SerializeField] private List<Transition> Transitions;

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

            foreach (var transition in Transitions)
            {
                transition.Init(Target);
                transition.enabled = true;
            }
        }
    }

    public void Exit()
    {
        if (enabled)
        {
            foreach (var transition in Transitions)
                transition.enabled = false;
        }

        enabled = false;
    }

    public State GetNextState()
    {
        foreach (var transition in Transitions)
        {
            if (transition.NeedTransit)
                return transition.TargetState;
        }

        return null;
    }
}
