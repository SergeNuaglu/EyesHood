using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField] private int _damage;
    [SerializeField] private float _speed;

    private bool _canFly = true;
    private bool _canPickUp = false;
    private Vector2 _flyDirection;

    private void OnEnable()
    {
        if (_canPickUp == false)
            _canFly = true;
    }

    private void Update()
    {
        if (_canFly)
            transform.Translate(_flyDirection * _speed * Time.deltaTime, Space.World);
    }

    public void SetFlyDirection(Vector2 flyDirection)
    {
        _flyDirection = flyDirection;

        if (flyDirection.x < 0)
        {
            transform.localScale = new Vector3(-transform.localScale.x, transform.localScale.y, transform.localScale.z);
        }
    }

    private void HitTarget()
    {
        _canFly = false;

        if (transform.localScale.x < 0)
            transform.localScale = new Vector3(-transform.localScale.x, transform.localScale.y, transform.localScale.z);

        gameObject.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent<Enemy>(out Enemy enemy))
        {
            HitTarget();

            if (enemy.IsKilled == false)
                enemy.ApllyDamage(_damage);
        }
        else if (collision.TryGetComponent<InteractionObject>(out InteractionObject interactionObject))
        {
            HitTarget();
            interactionObject.ApllyDamage(_damage);
        }
        else if (collision.TryGetComponent<Player>(out Player player))
        {
            player.ApplyDamage(_damage, _flyDirection);
            HitTarget();
        }
    }
}
