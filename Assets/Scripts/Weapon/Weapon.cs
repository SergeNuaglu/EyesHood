using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class Weapon : MonoBehaviour
{
    [SerializeField] private int _damage;
    [SerializeField] private AnimationTypeSetter _animationTypeSetter;
    [SerializeField] private int _animationTypeNumber;
    [SerializeField] private WeaponButton _button;

    private WeaponSwinger _weaponSwinger;
    private WeaponsIndex _weaponsIndex;
    protected int _index;

    protected int _currentDamage;

    public WeaponSwinger Swinger => _weaponSwinger;
    public int Index => _index;

    private void Awake()
    {
        if (TryGetComponent<WeaponSwinger>(out WeaponSwinger weaponswinger))
            _weaponSwinger = weaponswinger;

        _currentDamage = _damage;
        _weaponsIndex = new WeaponsIndex();
        _index = _weaponsIndex.GetIndex(this);
        _button.Init(this);
    }

    private void OnEnable()
    {
        if (_weaponSwinger != null)
            _weaponSwinger.StoppedSwinging += OnStoppedSwinging;
    }

    private void OnDisable()
    {
        if (_weaponSwinger != null)
            _weaponSwinger.StoppedSwinging -= OnStoppedSwinging;
    }

    public void ResetCurrentDamage()
    {
        _currentDamage = _damage;
    }

    public void SetWeapon()
    {
        _button.OnClickButton();
    }

    public void SetAnimation()
    {
        _animationTypeSetter.Set(_animationTypeNumber);
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


