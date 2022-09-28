using UnityEngine;

[CreateAssetMenu(fileName = "Data", menuName = "Data/Player Data", order = 51)]

public class PlayerData : ScriptableObject
{
    [SerializeField] private int _maxHealth;
    [SerializeField] private int _maxHeartCount;
    [SerializeField] private float _moveSpeed;
    [SerializeField] private float _climbSpeed;
    [SerializeField] private float _jumpForce;
    [SerializeField] private float _jumpHorizontalForce;
    [SerializeField] private float _rollForce;
    [SerializeField] private LastLevelData _lastHealth;
    [SerializeField] private LastLevelData _lastHeartCount;
    [SerializeField] private LastLevelData _lastMoney;
    [SerializeField] private LastLevelData _lastWeaponIndex;

    public int MaxHealth => _maxHealth;
    public int MaxHeartCount => _maxHeartCount;
    public float MoveSpeed => _moveSpeed;
    public float ClimbSpeed => _climbSpeed;
    public float JumpForce => _jumpForce;
    public float JumpHorizontalForce => _jumpHorizontalForce;
    public float RollForce => _rollForce;
    public LastLevelData LastHealth => _lastHealth;
    public LastLevelData LastHeartCount => _lastHeartCount;
    public LastLevelData LastMoney => _lastMoney;
    public LastLevelData LastWeaponIndex => _lastWeaponIndex;

    private void Awake()
    {
        _lastHealth.Set(_maxHealth);
        _lastHeartCount.Set(_maxHeartCount);
    }
}
