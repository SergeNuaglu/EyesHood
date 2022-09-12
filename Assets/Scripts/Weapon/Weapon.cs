using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class Weapon : MonoBehaviour
{
    [SerializeField] private int _damage;

    private WeaponSwinger _weaponSwinger;
    protected int _currentDamage;

    public WeaponSwinger Swinger => _weaponSwinger;

    private void Awake()
    {
        if (TryGetComponent<WeaponSwinger>(out WeaponSwinger weaponswinger))
            _weaponSwinger = weaponswinger;

        _currentDamage = _damage;
    }

    private void OnEnable()
    {
        if (_weaponSwinger != null)
        {
            _weaponSwinger.StoppedSwinging += OnStoppedSwinging;
        }
    }

    private void OnDisable()
    {
        if (_weaponSwinger != null)
        {
            _weaponSwinger.StoppedSwinging -= OnStoppedSwinging;
        }
    }

    public void ResetCurrentDamage()
    {
        _currentDamage = _damage;
    }

    private void OnStoppedSwinging(float swingPower)
    {
        float halfSwingPower = 0.5f;
        int swingPowerRate = 2;

        ResetCurrentDamage();

        if (swingPower < halfSwingPower)
            _currentDamage *= swingPowerRate;
        else
            _currentDamage *= (swingPowerRate + swingPowerRate);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent<Enemy>(out Enemy enemy))
        {
            enemy.ApllyDamage(_currentDamage);
        }
        else if (collision.TryGetComponent<InteractionObject>(out InteractionObject interactionObject))
        {
            interactionObject.ApllyDamage(_currentDamage);
        }
    }
}


