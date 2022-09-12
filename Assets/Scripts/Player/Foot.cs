using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Foot : MonoBehaviour
{
    private bool _isGrounded;

    public bool IsGrounded => _isGrounded;

    public void SetIsGround(bool value)
    {
        _isGrounded = value;
    }
}
