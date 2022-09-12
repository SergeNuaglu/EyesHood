using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpTransition : Transition
{
    [SerializeField] private float jumpThreshold = 0.5f;

    private void Update()
    {
        if (Target.MoveInput.y >= jumpThreshold)
        {
            if (Target.Foot.IsGrounded)
            {
                if (Target.ClimbController.CurrentLadder == null)
                {
                    NeedTransit = true;
                }
                else
                {
                    if (Target.ClimbController.CurrentLadder.TopZone.IsPlayerInside)
                    {
                        NeedTransit = true;
                    }
                }
            }
        }
    }
}
