using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveTransition : Transition
{
    [SerializeField] private float _walkThreshold = 0.15f;

    private void Update()
    {
        if (Target.Foot.IsGrounded && Target.Rigidbody.velocity.y == Vector2.zero.y)
        {
            if (Target.MoveInput.x < -_walkThreshold || Target.MoveInput.x > _walkThreshold)
            {
                NeedTransit = true;
            }
        }
    }
}
