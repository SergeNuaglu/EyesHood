using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClimbState : State
{
    private Ladder _currentLadder;
    private bool _canClimb;

    private void OnEnable()
    {
        Target.Rigidbody.isKinematic = true;
        _currentLadder = Target.ClimbController.CurrentLadder;
        _canClimb = true;

        if (Target.Rigidbody.velocity.x != 0)
        {
            Target.Rigidbody.velocity = Vector2.zero;
            Animator.SetFloat(AnimationNames.HashWalkSpeed, Vector2.zero.x);
        }

        if (_currentLadder != null)
        {
            if (_currentLadder.TopZone.IsPlayerInside)
                Target.transform.position = new Vector3(_currentLadder.transform.position.x, _currentLadder.TopEnterPoint.position.y, Target.transform.position.z);
            else if (_currentLadder.BottomZone.IsPlayerInside)
                Target.transform.position = new Vector3(_currentLadder.transform.position.x, Target.transform.position.y, Target.transform.position.z);
        }

        Animator.Play(AnimationNames.HashClimb);
    }

    private void OnDisable()
    {
        Target.Rigidbody.isKinematic = false;
    }

    private void Update()
    {
        if (_currentLadder != null)
        {
            if (_currentLadder.TopZone.IsPlayerInside)
            {
                if (Target.MoveInput.y > 0)
                {
                    StopClimb(true);
                }
            }
            else if (_currentLadder.BottomZone.IsPlayerInside)
            {
                if (Target.MoveInput.y < 0)
                {
                    StopClimb(false);
                }
            }
        }
    }

    private void FixedUpdate()
    {
        if (_canClimb)
        {
            Target.Rigidbody.velocity = new Vector2(Target.Rigidbody.velocity.x, Target.MoveInput.y * Target.PlayerData.ClimbSpeed);
            Animator.SetFloat(AnimationNames.HashClimbSpeed, Target.MoveInput.y);
        }
        else
        {
            Animator.SetFloat(AnimationNames.HashClimbSpeed, Vector2.zero.y);
            Target.Rigidbody.velocity = Vector2.zero;
            Animator.Play(AnimationNames.HashIdle);
        }
    }

    private void StopClimb(bool isTopZone)
    {
        _canClimb = false;
        _currentLadder.ExitLadder(Target.transform, isTopZone);
        Target.Rigidbody.isKinematic = false;
    }
}
