using UnityEngine;

public class HealthProduct : Product
{
    [SerializeField] private int _healthCount;

    private Player _player;

    public override bool TryBuy()
    {
        if (_player.CurrentHealth < _player.PlayerData.MaxHealth)
        {
            _player.AddHealth(_healthCount);
            return true;
        }

        return false;
    }

    public void Init(Player player)
    {
        _player = player;
    }
}
