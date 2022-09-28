using UnityEngine;
using UnityEngine.Events;

public class HitPoint : MonoBehaviour
{
    [SerializeField] private int _hitForce;

    public int HitForce => _hitForce;

    public event UnityAction Hit;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent<Player>(out Player player))
        {
            Hit?.Invoke();
        }
    }
}
