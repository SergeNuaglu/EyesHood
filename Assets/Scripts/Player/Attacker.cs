using UnityEngine;

[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(HasherAnimationsNames))]

public class Attacker : MonoBehaviour
{
    private Animator _animator;
    private HasherAnimationsNames _animationNames;

    private void Start()
    {
        _animator = GetComponent<Animator>();
        _animationNames = GetComponent<HasherAnimationsNames>();
    }

    public void AttackWithSword(Sword sword)
    {
        sword.Swinger.StopSwinging();

        if (sword.Swinger.SwingPower >= sword.Swinger.SwingThreshhold)
        {
            _animator.SetFloat(_animationNames.HashSwingPower, sword.Swinger.SwingPower);
            _animator.Play(_animationNames.HashSwing);
        }
        else
        {
            sword.ResetCurrentDamage();
            _animator.Play(_animationNames.HashAttack);
        }

        sword.Swinger.ResetSwing();
    }

    public void AttackWithSpear(Spear spear, Vector2 throwDirection, Vector2 throwStartPoint)
    {
        spear.Swinger.StopSwinging();

        if (spear.CanThrow)
        {
            spear.Throw(throwStartPoint, throwDirection);
            _animator.Play(_animationNames.HashAttack);
        }
        else if (spear.Swinger.SwingPower >= spear.Swinger.SwingThreshhold)
        {
            spear.ResetCurrentDamage();
            _animator.SetFloat(_animationNames.HashSwingPower, spear.Swinger.SwingPower);
            _animator.Play(_animationNames.HashSwing);
        }

        spear.Swinger.ResetSwing();
    }

    public void AttackWithBow(Bow bow, Vector2 throwDirection, Vector2 throwStartPoint)
    {
        bow.Throw(throwStartPoint, throwDirection);
        _animator.Play(_animationNames.HashAttack);
    }
}
