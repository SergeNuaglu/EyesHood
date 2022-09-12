using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDieTransition : Transition
{
    protected override void OnEnable()
    {
        base.OnEnable();
        Target.Died += OnDied;
    }

    private void OnDisable()
    {
        Target.Died -= OnDied;
    }

    private void OnDied()
    {
        NeedTransit = true;
    }
}
