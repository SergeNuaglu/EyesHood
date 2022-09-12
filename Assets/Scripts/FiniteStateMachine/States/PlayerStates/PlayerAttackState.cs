using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttackState : State
{
    [SerializeField] private AttackButton _attackButton;
    [SerializeField] private Attacker _attacker;

    private bool _canAttack;
    private bool _isSwingingWeapon;

    private void OnEnable()
    {
        _attackButton.AtackButtonReleased += OnAttackButtonReleased;
        _canAttack = true;
        _isSwingingWeapon = false;
        PrepareToAttack();
    }

    private void OnDisable()
    {
        _attackButton.AtackButtonReleased -= OnAttackButtonReleased;
        Target.CurrentWeapon.ResetCurrentDamage();

        if (_isSwingingWeapon)
            Target.CurrentWeapon.Swinger.ResetSwing();
    }

    private void PrepareToAttack()
    {
        if (Target.CurrentWeapon.TryGetComponent<Sword>(out Sword sword))
        {
            sword.Swinger.Swing();
            _isSwingingWeapon = true;
        }
        else if (Target.CurrentWeapon.TryGetComponent<Spear>(out Spear spear))
        {
            _isSwingingWeapon = true;

            if (spear.CanThrow)
            {
                Animator.Play(AnimationNames.HashPrepareToThrow);
            }
            else
            {
                spear.Swinger.Swing();
            }
        }
        else if (Target.CurrentWeapon.TryGetComponent<Bow>(out Bow bow))
        {
            if (bow.CanThrow)
            {
                Animator.Play(AnimationNames.HashPrepareToThrow);
            }
            else
            {
                _canAttack = false;
            }
        }
    }

    private void OnAttackButtonReleased()
    {
        if (_canAttack)
            Attack();
        else
            _canAttack = true;
    }

    private void Attack()
    {
        Vector2 throwDirection = Vector2.zero;

        if (Target.transform.localScale.x < 0)
            throwDirection = Vector2.left;
        else if(Target.transform.localScale.x > 0)
            throwDirection = Vector2.right;

        if (Target.CurrentWeapon.TryGetComponent<Sword>(out Sword sword))
        {
            _attacker.AttackWithSword(sword);
        }
        else if (Target.CurrentWeapon.TryGetComponent<Spear>(out Spear spear))
        {
            _attacker.AttackWithSpear(spear, throwDirection, Target.ShootPoint.transform.position);
        }
        else if (Target.CurrentWeapon.TryGetComponent<Bow>(out Bow bow))
        {
            _attacker.AttackWithBow(bow, throwDirection, Target.ShootPoint.transform.position);
        }

    }
}
