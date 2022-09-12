using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDieState : State
{
    private void OnEnable()
    {
        Animator.Play(AnimationNames.HashDie);
    }
}
