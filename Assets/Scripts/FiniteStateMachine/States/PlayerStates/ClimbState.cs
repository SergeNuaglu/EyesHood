using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClimbState : State
{
    private Ladder _currentLadder;

    private void OnEnable()
    {
        _currentLadder = Target.ClimbController.CurrentLadder;

        if (_currentLadder != null)
        {
            Target.Rigidbody.isKinematic = true;
            Target.Rigidbody.velocity = Vector2.zero;
            Animator.SetFloat(AnimationNames.HashWalkSpeed, Vector2.zero.x);

            if (_currentLadder.TopZone.IsPlayerInside)
                Target.transform.position = new Vector3(_currentLadder.transform.position.x, _currentLadder.TopEnterPoint.position.y, Target.transform.position.z);
            else if (_currentLadder.BottomZone.IsPlayerInside)
                Target.transform.position = new Vector3(_currentLadder.transform.position.x, Target.transform.position.y, Target.transform.position.z);

            Animator.Play(AnimationNames.HashClimb);
        }
    }

    private void OnDisable()
    {
        Target.Rigidbody.isKinematic = false;
    }

    private void Update()
    {
        _currentLadder = Target.ClimbController.CurrentLadder;

        if (_currentLadder != null)
        {
            if (_currentLadder.TopZone.IsPlayerInside)
            {
                if (Target.MoveInput.y > 0)
                {
                    ExitLadder(true);
                }
            }
            else if (_currentLadder.BottomZone.IsPlayerInside)
            {
                if (Target.MoveInput.y < 0)
                {
                    ExitLadder(false);
                }
            }
        }
    }

    private void FixedUpdate()
    {
        Target.Rigidbody.velocity = new Vector2(Target.Rigidbody.velocity.x, Target.MoveInput.y * Target.PlayerData.ClimbSpeed);
        Animator.SetFloat(AnimationNames.HashClimbSpeed, Target.MoveInput.y);
    }

    private void ExitLadder(bool isTopZone)
    {
        Target.Rigidbody.isKinematic = false;
        _currentLadder.Exit(Target.transform, isTopZone);
    }
}
