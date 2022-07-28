using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

[RequireComponent(typeof(Rigidbody2D))] 
[RequireComponent(typeof(Animator))]

public class Player : MonoBehaviour
{
    [SerializeField] private float _runSpeed;
    [SerializeField] private float _jumpForce;

    private Rigidbody2D _rigidbody;
    private Animator _animator;
    private Vector2 _moveDirection;
    private bool _isMove;
    private bool _isGround;

    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
    }

    private void Update()
    {
        if (_isMove)
            transform.Translate(_moveDirection * _runSpeed * Time.deltaTime);
    }

    public void MoveToRight()
    {

    }

    public void MoveToLeft()
    {

    }

    public void StopMove()
    {
        _isMove = false;
        _moveDirection = Vector2.zero;
    }

    public void Jump()
    {
        if (_isGround && _rigidbody.velocity.y == 0)
            _rigidbody.AddForce(Vector2.up * _jumpForce, ForceMode2D.Impulse);
    }

    public void Roll()
    {

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.TryGetComponent<Ground>(out Ground ground))
            _isGround = true;
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.collider.TryGetComponent<Ground>(out Ground ground))
            _isGround = false;
    }
}
