using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerIdleState : State
{
    private void OnEnable()
    {
        Animator.SetFloat(AnimationNames.HashWalkSpeed, Vector2.zero.x);
        Animator.Play(AnimationNames.HashIdle);
    }
}
