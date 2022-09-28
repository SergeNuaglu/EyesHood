using UnityEngine;

[RequireComponent(typeof(Enemy))]

public class EnemyApplyDamageTransition : Transition
{
    private Enemy _enemy;

    private void Awake()
    {
        _enemy = GetComponent<Enemy>();
    }

    protected override void OnEnable()
    {
        base.OnEnable();
        _enemy.DamageApplied += OnDamageApplyed;
    }

    private void OnDisable()
    {
        _enemy.DamageApplied -= OnDamageApplyed;
    }

    private void OnDamageApplyed()
    {
        NeedTransit = true;
    }
}
