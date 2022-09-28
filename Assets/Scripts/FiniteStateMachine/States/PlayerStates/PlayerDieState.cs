using UnityEngine;

public class PlayerDieState : State
{
    private void OnEnable()
    {
        Animator.Play(AnimationNames.HashDie);
    }
}
