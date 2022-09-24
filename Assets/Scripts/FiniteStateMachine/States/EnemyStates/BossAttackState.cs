using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossAttackState : EnemyAttackState
{
    private void OnDisable()
    {
        var minValue = 0;

        Animator.SetFloat(AnimationNames.HashSwingPower, minValue);
    }

    protected override void Attack()
    {
        if (Target.transform.position.y > transform.position.y)
        {
            Animator.Play(AnimationNames.HashAttack);
        }
        else
        {
            Animator.Play(AnimationNames.HashAttack2);
            Animator.SetFloat(AnimationNames.HashSwingPower, Random.value);
        }
    }
}
