using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ApplyDamageTransition : Transition
{
    protected override void OnEnable()
    {
        base.OnEnable();
        Target.SetCanApplyDamage(true);
        Target.DamageApplied += OnDamageApllied;
    }

    private void OnDisable()
    {
        Target.SetCanApplyDamage(false);
        Target.DamageApplied -= OnDamageApllied;
    }

    private void OnDamageApllied()
    {
        NeedTransit = true;
    }
}
