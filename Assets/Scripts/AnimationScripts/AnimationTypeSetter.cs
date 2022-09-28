using UnityEngine;

public class AnimationTypeSetter : MonoBehaviour
{
    [SerializeField] private AnimatorOverrideController[] _overrideControllers;
    [SerializeField] private AnimatorOverrider _overrider;

    public void Set(int value)
    {
        _overrider.SetAnimation(_overrideControllers[value]);
    }
}
