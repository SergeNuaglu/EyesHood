using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttackState : State
{
    [SerializeField] private int _damage;
    [SerializeField] private int _hitForce;
    [SerializeField] private HitPoint _hitPoint;

    private void OnEnable()
    {
        _hitPoint.Hit += OnHit;

        if (transform.position.x > Target.transform.position.x && transform.localScale.x > 0)
            ChangeDirection();
        else if (transform.position.x < Target.transform.position.x && transform.localScale.x < 0)
            ChangeDirection();

        Animator.Play(AnimationNames.HashAttack);
    }

    private void OnDisable()
    {
        _hitPoint.Hit -= OnHit;
    }

    private void OnHit()
    {
        Vector2 _hitDirection = transform.localScale.x > 0 ? Vector2.right : Vector2.left;
        Target.ApplyDamage(_damage, _hitDirection, _hitForce);
    }

    private void ChangeDirection()
    {
        transform.localScale = new Vector3(-transform.localScale.x, transform.localScale.y, transform.localScale.z);
    }
}
