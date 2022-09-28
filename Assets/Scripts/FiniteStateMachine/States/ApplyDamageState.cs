using UnityEngine;

public class ApplyDamageState : State
{
    private void OnEnable()
    {
        Animator.Play(AnimationNames.HashApplyDamage);      
    }
}
