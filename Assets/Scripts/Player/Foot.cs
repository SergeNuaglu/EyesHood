using UnityEngine;

public class Foot : MonoBehaviour
{
    public bool IsGrounded { get; private set; }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent<Platform>(out Platform platform))
            IsGrounded = true;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.TryGetComponent<Platform>(out Platform platform))
            IsGrounded = false;
    }
}
