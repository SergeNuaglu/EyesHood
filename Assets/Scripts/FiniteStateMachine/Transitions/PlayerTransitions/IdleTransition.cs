using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdleTransition : Transition
{
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
}
