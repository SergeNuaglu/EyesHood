using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBowAttackState : State
{
    [SerializeField] private ProjectileGenerator _projectileGenerator;
    [SerializeField] private ShootPoint _shootPoint;
    [SerializeField] private float _shotsPerSecond;

    private Vector2 _shootDirection;
    private WaitForSeconds _timeBeforeShooting;
    private bool _canShoot = true;
    private float _shotDuration;
    private float _runningTime;
    private float _startRunningTime = 0;

    private void Start()
    {
        _shotDuration = 1 / _shotsPerSecond;
        _timeBeforeShooting = new WaitForSeconds(_shotDuration);
    }

    private void OnEnable()
    {
        if (Target.transform.position.x < transform.position.x)
            _shootDirection = Vector2.left;
        else
            _shootDirection = Vector2.right;
    }

    private void OnDisable()
    {
        StopCoroutine(Shoot());
    }

    private void Update()
    {
        if (_runningTime <= _shotDuration)
        {
            if (_canShoot)
            {
                Animator.Play(AnimationNames.HashPrepareToThrow);
                StartCoroutine(Shoot());
                _canShoot = false;
            }
            _runningTime += Time.deltaTime;
        }
        else
        {
            _runningTime = _startRunningTime;
            StopCoroutine(Shoot());
        }
    }

    private IEnumerator Shoot()
    {
        yield return _timeBeforeShooting;
        Animator.Play(AnimationNames.HashAttack);
        _projectileGenerator.SetProjectileToStartPoint(_shootPoint.transform.position, _shootDirection);
        _canShoot = true;
    }
}
