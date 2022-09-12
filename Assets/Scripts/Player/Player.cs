using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Rigidbody2D))]

public class Player : MonoBehaviour
{
    [SerializeField] private PlayerData _playerData;
    [SerializeField] private FiniteStateMachine _playerStateMachine;
    [SerializeField] private Foot _foot;
    [SerializeField] private ClimbController _climbController;
    [SerializeField] private ShootPoint _shootPoint;
    [SerializeField] private Joystick _joystick;
    [SerializeField] private PickUpItemsGenerator _healthPotionGenerator;

    private int _currentHealth;
    private Rigidbody2D _rigidbody;
    private Weapon _currentWeapon;
    private bool _canApplyDamage;

    public int Money { get; private set; }
    public Vector2 MoveInput { get; private set; }
    public Foot Foot => _foot;
    public Weapon CurrentWeapon => _currentWeapon;
    public ShootPoint ShootPoint => _shootPoint;
    public PlayerData PlayerData => _playerData;
    public Rigidbody2D Rigidbody => _rigidbody;
    public ClimbController ClimbController => _climbController;

    public event UnityAction HealthChanged;
    public event UnityAction DamageApplied;
    public event UnityAction Died;
    public event UnityAction WeaponChanged;

    private void Awake()
    {
        _playerStateMachine.Init(this);
        _rigidbody = GetComponent<Rigidbody2D>();
        _currentHealth = _playerData.Health;
    }

    private void OnEnable()
    {
        _healthPotionGenerator.ItemPickedUp += OnHealthPotionPickedUp;
    }

    private void OnDisable()
    {
        _healthPotionGenerator.ItemPickedUp -= OnHealthPotionPickedUp;

    }
    private void Update()
    {
        MoveInput = _joystick.HandlePositionDelta;
    }

    public void ChangeWeapon(Weapon weapon)
    {
        WeaponChanged?.Invoke();
        if (_currentWeapon != null)
            _currentWeapon.ResetCurrentDamage();

        _currentWeapon = weapon;
    }

    public void SetCanApplyDamage(bool canApplyDamage)
    {
        _canApplyDamage = canApplyDamage;
    }

    public void ApplyDamage(int damage, Vector2 hitDirection, float hitPower = 3)
    {
        if (_canApplyDamage)
        {
            _rigidbody.velocity = Vector2.zero;
            _rigidbody.AddForce((hitDirection + Vector2.up) * hitPower, ForceMode2D.Impulse);
            _currentHealth -= damage;

            if (_currentHealth <= 0)
            {
                Died?.Invoke();
            }
            else
            {
                DamageApplied?.Invoke();
                HealthChanged?.Invoke();
            }
        }
    }

    public void Die()
    {
        Died?.Invoke();
    }

    public void OnHealthPotionPickedUp()
    {
        int healthCount = 25;

        if (_currentHealth + healthCount > _playerData.Health)
            _currentHealth = _playerData.Health;
        else
            _currentHealth += healthCount;

        HealthChanged?.Invoke();
    }

    private void OnEnemyDied(int reward)
    {
        Money += reward;
    }
}