using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Enemy))]

public class EnemyDieTransition : Transition
{
    private Enemy _enemy;

    private void Awake()
    {
        _enemy = GetComponent<Enemy>();
    }

    protected override void OnEnable()
    {
        base.OnEnable();
        _enemy.Died += OnDied;
        Debug.Log("On" + gameObject.name);
    }

    private void OnDisable()
    {
        Debug.Log("Off" + gameObject.name);
        _enemy.Died -= OnDied;
    }

    private void OnDied()
    {
        Debug.Log("Enemy Died");
        NeedTransit = true;
    }
}
