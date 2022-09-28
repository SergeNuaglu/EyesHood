using UnityEngine;

public class ProjectileGenerator : ObjectPool
{
    [SerializeField] private Projectile _prefab;

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
