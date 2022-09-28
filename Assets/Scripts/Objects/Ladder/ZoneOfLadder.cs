using UnityEngine;
using UnityEngine.Events;

public class ZoneOfLadder : MonoBehaviour
{
    public bool IsPlayerInside { get; private set; }

    public event UnityAction PlayerEnteredZone;
    public event UnityAction PlayerWentOutZone;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent<Player>(out Player player))
        {
            PlayerEnteredZone?.Invoke();
            IsPlayerInside = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.TryGetComponent<Player>(out Player player))
        {
            PlayerWentOutZone?.Invoke();
            IsPlayerInside = false;
        }
    }
}
