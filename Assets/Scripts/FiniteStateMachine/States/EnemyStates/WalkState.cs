using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Enemy))]

public class WalkState : State
{
    [Range(1, 10)]
    [SerializeField] private float _movingDuration;
    [SerializeField] private float _moveSpeed;
    [SerializeField] private int _idleDuration;

    private Foot _foot;
    private float _runningTime;
    private float _startRunningTime = 0;
    private float _speedIndex;
    private float _maxSpeedIndex = 1;
    private bool _isMoving = true;

    private void Start()
    {
        if (GetComponent<Enemy>().Foot != null)
            _foot = GetComponent<Enemy>().Foot;
        //GameObject.FindObjectsOfType(typeof(MonoBehaviour));
    }


    private void Update()
    {
        if (_foot != null)
            if (_foot.IsGrounded == false)
                _isMoving = false;

        if (_isMoving)
        {
            if (_runningTime <= _movingDuration)
            {
                Animator.Play(AnimationNames.HashWalk);
                _speedIndex = _maxSpeedIndex - _runningTime / _movingDuration;
                _runningTime += Time.deltaTime;
                Animator.SetFloat(AnimationNames.HashWalkSpeed, _speedIndex);
                transform.Translate((transform.localScale.x > 0 ? Vector3.right : Vector3.left) * _moveSpeed * _speedIndex * Time.deltaTime);
            }
            else
            {
                float startSpeed = 0;

                Animator.SetFloat(AnimationNames.HashWalkSpeed, startSpeed);
                _runningTime = _startRunningTime;
                _isMoving = false;
            }
        }
        else
        {
            if (_runningTime <= _idleDuration)
            {
                Animator.Play(AnimationNames.HashIdle);
                _runningTime += Time.deltaTime;
            }
            else
            {
                _isMoving = true;
                _runningTime = _startRunningTime;
                transform.localScale = new Vector3(-transform.localScale.x, transform.localScale.y, transform.localScale.z);
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.TryGetComponent<Player>(out Player player) && enabled)
        {
            _runningTime = _startRunningTime;
            _isMoving = true;
            transform.localScale = new Vector3(-transform.localScale.x, transform.localScale.y, transform.localScale.z);
        }
        else if (collision.collider.TryGetComponent<Platform>(out Platform platform) == false)
        {
            _runningTime = _startRunningTime;
            _isMoving = false;
        }
    }
}


