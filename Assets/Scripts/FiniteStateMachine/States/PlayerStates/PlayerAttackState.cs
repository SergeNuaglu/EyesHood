using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttackState : State
{
    [SerializeField] private AttackButton _attackButton;
    [SerializeField] private Attacker _attacker;

    private bool _canAttack;
    private WeaponsIndex _weaponsIndex;

    protected override void Awake()
    {
        base.Awake();
        _weaponsIndex = new WeaponsIndex();
    }

    private void OnEnable()
    {
        _attackButton.AtackButtonReleased += OnAttackButtonReleased;
        _canAttack = true;
        ChooseAttackType(Target.CurrentWeapon.Index);
    }

    private void OnDisable()
    {
        _attackButton.AtackButtonReleased -= OnAttackButtonReleased;
        Target.CurrentWeapon.ResetCurrentDamage();

        if (Target.CurrentWeapon.Index != _weaponsIndex.BowIndex)
            Target.CurrentWeapon.Swinger.ResetSwing();
    }

    

    private void PrepareToSwordAttack()
    {
        if (Target.CurrentWeapon.TryGetComponent<Sword>(out Sword sword))
            sword.Swinger.Swing();
    }

    private void PrepareToSpearAttack()
    {
        if (Target.CurrentWeapon.TryGetComponent<Spear>(out Spear spear))
        {
            if (spear.CanThrow)
                Animator.Play(AnimationNames.HashPrepareToThrow);
            else
                spear.Swinger.Swing();
        }
    }

    private void PrepareToBowAttack()
    {
        if (Target.CurrentWeapon.TryGetComponent<Bow>(out Bow bow))
        {
            if (bow.CanThrow)
                Animator.Play(AnimationNames.HashPrepareToThrow);
            else
                _canAttack = false;
        }
    }

    private void OnAttackButtonReleased()
    {
        if (_canAttack)
            Attack();
        else
            _canAttack = true;
    }

    private void ChooseAttackType(int weaponIndex)
    {
        if (weaponIndex == _weaponsIndex.SwordIndex)
            PrepareToSwordAttack();
        else if (weaponIndex == _weaponsIndex.SpearIndex)
            PrepareToSpearAttack();
        else if (weaponIndex == _weaponsIndex.BowIndex)
            PrepareToBowAttack();
    }

    private void Attack()
    {
        Vector2 throwDirection = Vector2.zero;

        if (Target.transform.localScale.x < 0)
            throwDirection = Vector2.left;
        else if (Target.transform.localScale.x > 0)
            throwDirection = Vector2.right;

        if (Target.CurrentWeapon.TryGetComponent<Sword>(out Sword sword))
            _attacker.AttackWithSword(sword);
        else if (Target.CurrentWeapon.TryGetComponent<Spear>(out Spear spear))
            _attacker.AttackWithSpear(spear, throwDirection, Target.ShootPoint.transform.position);
        else if (Target.CurrentWeapon.TryGetComponent<Bow>(out Bow bow))
            _attacker.AttackWithBow(bow, throwDirection, Target.ShootPoint.transform.position);
    }
}
