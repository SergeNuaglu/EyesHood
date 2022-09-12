using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileGenerator : ObjectPool
{
    [SerializeField] Projectile _prefab;

    private void Start()
    {
        Initialize(_prefab.gameObject);
    }

    private void Update()
    {
        DisableObjectAbroadScreen();
    }

    public void SetProjectileToStartPoint(Vector3 installationPoint, Vector2 flyDirection)
    {
        if (TryGetObject(out GameObject item))
        {
            Projectile newProjectile;

            item.SetActive(true);
            item.transform.position = installationPoint;
            newProjectile = item.GetComponent<Projectile>();
            newProjectile.SetFlyDirection(flyDirection);
        }
    }
}
