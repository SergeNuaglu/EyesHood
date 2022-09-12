using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThrowingWeapon : Weapon
{
    [SerializeField] private ProjectileGenerator projectileGenerator;
    [SerializeField] private Quiver _quiver;

    public bool CanThrow { get; private set; }

    private void OnEnable()
    {
        _quiver.ItemsCountChanged += OnAProjectilesCountChanged;
    }

    private void OnDisable()
    {
        _quiver.ItemsCountChanged -= OnAProjectilesCountChanged;
    }

    public void Throw(Vector3 shootPoint, Vector2 flyDirection)
    {
        projectileGenerator.SetProjectileToStartPoint(shootPoint, flyDirection);
        _quiver.UseItem();
    }

    private void OnAProjectilesCountChanged(int count)
    {
        if (count > 0)
            CanThrow = true;
        else
            CanThrow = false;
    }
}