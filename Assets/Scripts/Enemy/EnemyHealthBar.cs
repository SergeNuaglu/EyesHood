using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealthBar : Bar
{
    [SerializeField] Enemy _enemy;

    private void OnEnable()
    {
        _enemy.HealthChanged += OnValueChanged;
    }

    private void OnDisable()
    {
        _enemy.HealthChanged -= OnValueChanged;

    }
}
