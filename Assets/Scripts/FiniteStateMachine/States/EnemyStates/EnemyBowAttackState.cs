using UnityEngine;

public class EnemyBowAttackState : State
{
    [SerializeField] private ProjectileGenerator _projectileGenerator;
    [SerializeField] private ShootPoint _shootPoint;
    [SerializeField] private float _shotsPerSecond;

    private Vector2 _shootDirection;
    private bool _canPrepareToThrow = true;
    private float _shotDuration;
    private float _runningTime;
    private float _startRunningTime = 0;

    private void Start()
    {
        _shotDuration = 1 / _shotsPerSecond;
    }

    private void OnEnable()
    {
        if (Target.transform.position.x < transform.position.x)
            _shootDirection = Vector2.left;
        else
            _shootDirection = Vector2.right;

        if(transform.position.x > Target.transform.position.x && transform.localScale.x > 0)
            ChangeDirection();
        else if (transform.position.x < Target.transform.position.x && transform.localScale.x < 0)
            ChangeDirection();
    }

    private void OnDisable()
    {
        _runningTime = _startRunningTime;
        _canPrepareToThrow = true;
    }

    private void Update()
    {
        if (_runningTime <= _shotDuration)
        {
            if (_canPrepareToThrow)
            {
                Animator.Play(AnimationNames.HashPrepareToThrow);
                _canPrepareToThrow = false;
            }
            _runningTime += Time.deltaTime;
        }
        else
        {
            Animator.Play(AnimationNames.HashAttack);
            _projectileGenerator.SetProjectileToStartPoint(_shootPoint.transform.position, _shootDirection);
            _canPrepareToThrow = true;
            _runningTime = _startRunningTime;
        }
    }

    private void ChangeDirection()
    {
        transform.localScale = new Vector3(-transform.localScale.x, transform.localScale.y, transform.localScale.z);
    }
}
