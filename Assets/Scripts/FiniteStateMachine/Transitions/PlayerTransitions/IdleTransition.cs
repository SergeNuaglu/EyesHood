using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdleTransition : Transition
{
    protected override void OnEnable()
    {
        base.OnEnable();
        Target.ClimbController.LadderUsed += OnLadderUsed;
    }

    private void OnDisable()
    {
        Target.ClimbController.LadderUsed -= OnLadderUsed;
    }

    private void Update()
    {
        if (Target.Foot.IsGrounded)
        {
            if (Target.Rigidbody.velocity == Vector2.zero && Target.MoveInput.x == 0)
            {
                NeedTransit = true;
            }
        }
    }

    private void OnLadderUsed()
    {
        Target.ClimbController.CurrentLadder.PlayerGotOffLadder += OnPlayerGotOffLadder;
    }

    private void OnPlayerGotOffLadder()
    {
        Target.ClimbController.CurrentLadder.PlayerGotOffLadder -= OnPlayerGotOffLadder;
        NeedTransit = true;
    }
}
