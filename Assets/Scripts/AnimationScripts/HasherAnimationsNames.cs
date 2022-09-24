using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HasherAnimationsNames: MonoBehaviour
{
    public int HashIdle { get; private set; }
    public int HashWalk { get; private set; }
    public int HashRun { get; private set; }
    public int HashRoll { get; private set; }
    public int HashClimb { get; private set; }
    public int HashJump { get; private set; }
    public int HashAttack { get; private set; }
    public int HashAttack2 { get; private set; }
    public int HashDash { get; private set; }
    public int HashDie{ get; private set; }
    public int HashApplyDamage{ get; private set; }
    public int HashSwing { get; private set; }
    public int HashPrepareToThrow{ get; private set; }
    public int HashWalkSpeed { get; private set; }
    public int HashClimbSpeed { get; private set; }
    public int HashSwingPower { get; private set; }

    private void Awake()
    {
        HashIdle = Animator.StringToHash(AnimatorPlayerController.States.Idle);
        HashWalk = Animator.StringToHash(AnimatorPlayerController.States.Walk);
        HashRun = Animator.StringToHash(AnimatorPlayerController.States.Run);
        HashRoll = Animator.StringToHash(AnimatorPlayerController.States.Roll);
        HashClimb = Animator.StringToHash(AnimatorPlayerController.States.Climb);
        HashJump = Animator.StringToHash(AnimatorPlayerController.States.Jump);
        HashAttack = Animator.StringToHash(AnimatorPlayerController.States.Attack);
        HashAttack2 = Animator.StringToHash(AnimatorPlayerController.States.Attack2);
        HashDash = Animator.StringToHash(AnimatorPlayerController.States.Dash);
        HashDie = Animator.StringToHash(AnimatorPlayerController.States.Die);
        HashApplyDamage = Animator.StringToHash(AnimatorPlayerController.States.ApplyDamage);
        HashSwing = Animator.StringToHash(AnimatorPlayerController.States.Swing);
        HashPrepareToThrow = Animator.StringToHash(AnimatorPlayerController.States.PrepareToThrow);
        HashWalkSpeed = Animator.StringToHash(AnimatorPlayerController.Params.WalkSpeed);
        HashClimbSpeed = Animator.StringToHash(AnimatorPlayerController.Params.ClimbSpeed);
        HashSwingPower = Animator.StringToHash(AnimatorPlayerController.Params.SwingPower);
    }
}
