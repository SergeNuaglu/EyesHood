using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(FiniteStateMachine))]

public class Enemy : MonoBehaviour
{
    [SerializeField] private int _maxHealth;
    [SerializeField] private int _reward;
    [SerializeField] private Player _target;
    [SerializeField] private Foot _foot;
    [SerializeField] private HitPoint _hitPoint;
    [SerializeField] private int _damage;
    [SerializeField] private bool _isBoss;

    private int _currentHealth;
    private FiniteStateMachine _enemyStateMachine;

    public Player Target => _target;
    public Foot Foot => _foot;
    public bool IsKilled { get; private set; }

    public event UnityAction Died;
    public event UnityAction DamageApplied;
    public event UnityAction<int, int> HealthChanged;

    private void Awake()
    {
        _enemyStateMachine = GetComponent<FiniteStateMachine>();
        _enemyStateMachine.Init(_target);
        _currentHealth = _maxHealth;
    }

    private void OnEnable()
    {
        if (_hitPoint != null)
            _hitPoint.Hit += OnHit;
    }

    private void OnDisable()
    {
        if (_hitPoint != null)
            _hitPoint.Hit -= OnHit;
    }

    private void Update()
    {
        if (IsKilled)
            Died?.Invoke();
    }


    public void ApllyDamage(int damage)
    {
        int _minHealth = 0;

        _currentHealth -= damage;
        HealthChanged?.Invoke(_currentHealth, _maxHealth);

        if (_currentHealth <= _minHealth)
            Die();
        else
            DamageApplied?.Invoke();
    }

    private void OnHit()
    {
        Vector2 _hitDirection = transform.localScale.x > 0 ? Vector2.right : Vector2.left;
        Target.ApplyDamage(_damage, _hitDirection, _hitPoint.HitForce);
    }

    private void Die()
    {
        _target.OnEnemyDied(_reward, _isBoss);
        IsKilled = true;
    }
}
