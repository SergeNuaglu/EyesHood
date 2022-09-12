using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RightRollState : State
{
    private void OnEnable()
    {
        if (Target.transform.localScale.x < 0)
            transform.localScale = new Vector3(-transform.localScale.x, transform.localScale.y, transform.localScale.z);

        Target.Rigidbody.AddForce(Vector2.right * Target.PlayerData.RollForce, ForceMode2D.Impulse);
        Animator.Play(AnimationNames.HashRoll);
    }
}
