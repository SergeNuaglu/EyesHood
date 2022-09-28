using UnityEngine;

public class ChaseState : State
{
    [SerializeField] private float _chaseSpeed;

    private Vector3 _target;

    private void OnEnable()
    {
        float startSpeedValue = 0;

        Animator.SetFloat(AnimationNames.HashWalkSpeed, startSpeedValue);

        if (transform.position.x > Target.transform.position.x && transform.localScale.x > 0)
            ChangeDirection();
        else if (transform.position.x < Target.transform.position.x && transform.localScale.x < 0)
            ChangeDirection();
    }

    private void Update()
    {
        _target = new Vector3(Target.transform.position.x, transform.position.y, transform.position.z);
        transform.position = Vector3.MoveTowards(transform.position, _target, _chaseSpeed * Time.deltaTime);
        Animator.Play(AnimationNames.HashRun);
    }

    private void ChangeDirection()
    {
        transform.localScale = new Vector3(-transform.localScale.x, transform.localScale.y, transform.localScale.z);
    }
}
