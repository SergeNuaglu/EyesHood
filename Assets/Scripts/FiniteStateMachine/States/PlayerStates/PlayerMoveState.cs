using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMoveState : State
{
    [SerializeField] private float _walkThreshold = 0.15f;

    private void OnEnable()
    {
        Animator.Play(AnimationNames.HashRun);
    }

    private void Update()
    {
        if (Target.MoveInput.x < 0 && transform.localScale.x > 0)
            ChangeDirection();
        else if (Target.MoveInput.x > 0 && transform.localScale.x < 0)
            ChangeDirection();

        if (Target.MoveInput.x > 0)
            Animator.SetFloat(AnimationNames.HashWalkSpeed, Target.MoveInput.x);
        else
            Animator.SetFloat(AnimationNames.HashWalkSpeed, -Target.MoveInput.x);
    }

    private void FixedUpdate()
    {
        Target.Rigidbody.velocity = new Vector2(Target.MoveInput.x * Target.PlayerData.MoveSpeed, Target.Rigidbody.velocity.y);
    }

    private void ChangeDirection()
    {
        transform.localScale = new Vector3(-transform.localScale.x, transform.localScale.y, transform.localScale.z);
    }
}
