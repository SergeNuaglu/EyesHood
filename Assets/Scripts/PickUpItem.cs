using UnityEngine;
using UnityEngine.Events;

public class PickUpItem : MonoBehaviour
{
    public event UnityAction<PickUpItem> PickedUp;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent<Player>(out Player player))
            PickedUp?.Invoke(this);
    }
}
