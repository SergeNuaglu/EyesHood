using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stakes : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.TryGetComponent<Player>(out Player player))
        {
            player.Die();
        }
    }
}
