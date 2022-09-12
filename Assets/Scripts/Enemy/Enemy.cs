using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(FiniteStateMachine))]

public class Enemy : MonoBehaviour
{
    [SerializeField] private int _health;
    [SerializeField] private int _reward;
    [SerializeField] private Player _target;
    [SerializeField] private Foot _foot;

    private FiniteStateMachine _enemyStateMachine;

    public Player Target => _target;
    public Foot Foot => _foot;

    public event UnityAction Died;
    public event UnityAction DamageApplied;

    private void Awake()
    {
        _enemyStateMachine = GetComponent<FiniteStateMachine>();
        _enemyStateMachine.Init(_target);
    }

    public void ApllyDamage(int damage)
    {
        int _minHealth = 0;

        _health -= damage;

        if (_health <= _minHealth)
            Die();
        else
            DamageApplied?.Invoke();
    }

    protected virtual void Die()
    {
        Died?.Invoke();
    }
}
