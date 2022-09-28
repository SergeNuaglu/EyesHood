using TMPro;
using UnityEngine;

public class MoneyBalance : MonoBehaviour
{
    [SerializeField] private Player _player;
    [SerializeField] private TMP_Text _score;

    private void OnEnable()
    {
        OnMoneyChanged(_player.Money);
        _player.MoneyChanged += OnMoneyChanged;
    }

    private void OnDisable()
    {
        _player.MoneyChanged -= OnMoneyChanged;
    }

    private void OnMoneyChanged(int money)
    {
        _score.text = money.ToString();
    }
}
