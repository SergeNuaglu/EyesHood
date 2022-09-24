using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class WeaponButtonsController : MonoBehaviour
{
    [SerializeField] private WeaponButton[] _buttons;
    [SerializeField] private AttackButton _attackButton;
    [SerializeField] private Player _player;

    private void OnEnable()
    {
        foreach (var button in _buttons)
        {
            button.Clicked += OnWeaponButtonClicked;
        }
    }

    private void OnDisable()
    {
        foreach (var button in _buttons)
        {
            button.Clicked -= OnWeaponButtonClicked;
        }
    }

    private void Awake()
    {
        _attackButton.gameObject.SetActive(false);
    }

    public void OnWeaponButtonClicked(Weapon weapon, Sprite attackTypeIcon)
    {
        _player.ChangeWeapon(weapon);

        UnselectActiveButton();

        if (_attackButton.gameObject.activeSelf == false)
        {
            _attackButton.gameObject.SetActive(true);
        }

        _attackButton.SetAttackTypeIcon(attackTypeIcon);
    }

    private void UnselectActiveButton()
    {
        foreach (var button in _buttons)
        {
            if (button.IsPressed)
                button.UnselectButton();
        }
    }
}
