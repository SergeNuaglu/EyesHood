using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "PlayerData", menuName = "Data/Player Data/Base Data")]

public class PlayerData : ScriptableObject
{
    [SerializeField] private int _health;
    [SerializeField] private float _moveSpeed;
    [SerializeField] private float _climbSpeed;
    [SerializeField] private float _jumpForce;
    [SerializeField] private float _jumpHorizontalForce;
    [SerializeField] private float _rollForce;

    public int Health => _health;
    public float MoveSpeed => _moveSpeed;
    public float ClimbSpeed => _climbSpeed;
    public float JumpForce => _jumpForce;
    public float JumpHorizontalForce => _jumpHorizontalForce;
    public float RollForce => _rollForce;
}
