using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]

public class AnimatorOverrider : MonoBehaviour
{
    private Animator _animator;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }

    public void SetAnimation(AnimatorOverrideController overrideController)
    {
        _animator.runtimeAnimatorController = overrideController;
    }
}
