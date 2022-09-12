using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Transition : MonoBehaviour
{
    [SerializeField] private State _targetState;

    protected Player Target { get; private set; }

    public State TargetState => _targetState;
    public bool NeedTransit { get; protected set; }

    protected virtual void OnEnable()
    {
        NeedTransit = false;
    }

    public void Init(Player target)
    {
        Target = target;
    }
}
