using UnityEngine;

public class JumpState : State
{
    private Vector2 _totalJumpForce;

    private void OnEnable()
    {
        _totalJumpForce = Vector2.up * Target.PlayerData.JumpForce + new Vector2(Target.MoveInput.x, 0) * Target.PlayerData.JumpHorizontalForce;
        Target.Rigidbody.velocity = Vector2.zero;
        Target.Rigidbody.AddForce(_totalJumpForce, ForceMode2D.Impulse);
        Animator.Play(AnimationNames.HashJump);
    }
}
