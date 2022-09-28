using UnityEngine;

public class AnimatorOverrider : MonoBehaviour
{
    [SerializeField] private Animator _animator;

    public void SetAnimation(AnimatorOverrideController overrideController)
    {
        _animator.runtimeAnimatorController = overrideController;
    }
}
