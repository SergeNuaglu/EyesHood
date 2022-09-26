using System.Collections;
using System.Collections.Generic;
using System.Linq;
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
    [SerializeField] private PickUpItemsGenerator _coinGenerator;
    [SerializeField] private List<Weapon> _weapons;
    [SerializeField] private List<Heart> _hearts;

    private int _money;
    private int _currentHealth;
    private Rigidbody2D _rigidbody;
    private Weapon _currentWeapon;
    private bool _canApplyDamage;
    private bool _isDied;

    public Vector2 MoveInput { get; private set; }
    public int Money => _money;
    public Foot Foot => _foot;
    public Weapon CurrentWeapon => _currentWeapon;
    public ShootPoint ShootPoint => _shootPoint;
    public PlayerData PlayerData => _playerData;
    public Rigidbody2D Rigidbody => _rigidbody;
    public ClimbController ClimbController => _climbController;
    public int CurrentHealth => _currentHealth;

    public event UnityAction<int, int> HealthChanged;
    public event UnityAction<int> MoneyChanged;
    public event UnityAction DamageApplied;
    public event UnityAction GameOver;
    public event UnityAction BossKilled;

    private void Awake()
    {
        _playerStateMachine.Init(this);
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    private void Start()
    {
        foreach (var heart in _hearts)
        {
            heart.Init(this);
        }

        var currentHeart = _hearts.FirstOrDefault(h => h.IsEmpty == false);
        currentHeart.MakeCurrent();
    }

    private void OnEnable()
    {
        _healthPotionGenerator.ItemPickedUp += OnHealthPotionPickedUp;
        _coinGenerator.ItemPickedUp += OnCoinPickedUp;
    }

    private void OnDisable()
    {
        _healthPotionGenerator.ItemPickedUp -= OnHealthPotionPickedUp;

        if (_isDied == false)
            SaveLevelData();
    }

    private void Update()
    {
        MoveInput = _joystick.HandlePositionDelta;
    }

    public void ChangeWeapon(Weapon weapon)
    {
        if (_currentWeapon != null)
            _currentWeapon.ResetCurrentDamage();

        _currentWeapon = weapon;
        _currentWeapon.SetAnimation();
    }

    public void SetCanApplyDamage(bool canApplyDamage)
    {
        _canApplyDamage = canApplyDamage;
    }

    public void ApplyDamage(int damage, Vector2 hitDirection, float hitPower = 3)
    {
        int minHealth = 0;

        if (_canApplyDamage)
        {
            _rigidbody.velocity = Vector2.zero;
            _rigidbody.AddForce((hitDirection + Vector2.up) * hitPower, ForceMode2D.Impulse);
            _currentHealth -= damage;

            if (_currentHealth <= minHealth)
                Die();
            else
                DamageApplied?.Invoke();

            HealthChanged?.Invoke(_currentHealth, _playerData.MaxHealth);
        }
    }

    private void OnCoinPickedUp()
    {
        _money++;
        MoneyChanged?.Invoke(_money);
    }

    public void Pay(int price)
    {
        _money -= price;
        MoneyChanged?.Invoke(_money);
    }

    public void Die()
    {
        GameOver?.Invoke();
        _playerData.LastHealth.Set(_playerData.MaxHealth);
        _playerData.LastWeaponIndex.Reset();
        _isDied = true;
    }

    private void OnHealthPotionPickedUp()
    {
        int healthCount = 25;

        AddHealth(healthCount);
    }

    public void AddHealth(int healthCount)
    {
        if (_currentHealth + healthCount > _playerData.MaxHealth)
            _currentHealth = _playerData.MaxHealth;
        else
            _currentHealth += healthCount;

        HealthChanged?.Invoke(_currentHealth, _playerData.MaxHealth);
    }

    public void ReturnLastLevelData()
    {
        foreach (var weapon in _weapons)
        {
            if (weapon.Index == _playerData.LastWeaponIndex.Data)
                weapon.SetWeapon();
        }

        for (int i = _hearts.Count - 1; i >= 0; i--)
        {
            if (i >= _hearts.Count - _playerData.LastHeartCount.Data)
            {
                _hearts[i].SetIsEmptyFlag(false);
            }
            else
                _hearts[i].SetIsEmptyFlag(true);
        }

        _currentHealth = _playerData.LastHealth.Data;
        HealthChanged?.Invoke(_currentHealth, _playerData.MaxHealth);
        _money = _playerData.LastMoney.Data;
        MoneyChanged?.Invoke(_money);
    }

    public void ResetPlayer()
    {
        _playerData.LastHealth.Set(_playerData.MaxHealth);
        _playerData.LastMoney.Reset();
        _playerData.LastWeaponIndex.Reset();
    }

    public void OnEnemyDied(int reward, bool isBoss)
    {
        if (isBoss)
            BossKilled?.Invoke();
        else
            _money += reward;

        MoneyChanged?.Invoke(_money);
    }

    private void SaveLevelData()
    {
        _playerData.LastHealth.Set(_currentHealth);
        _playerData.LastMoney.Set(_money);

        if (_currentWeapon != null)
            _playerData.LastWeaponIndex.Set(_currentWeapon.Index);
    }
}