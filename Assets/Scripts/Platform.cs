using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent<Foot>(out Foot foot))
        {
            foot.SetIsGround(true);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.TryGetComponent<Foot>(out Foot foot))
        {
            foot.SetIsGround(false);
            Debug.Log("Exit");
        }
    }
}
