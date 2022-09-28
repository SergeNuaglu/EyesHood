using UnityEngine;

public class EnemyAttackState : State
{
    private void OnEnable()
    {
        if (transform.position.x > Target.transform.position.x && transform.localScale.x > 0)
            ChangeDirection();
        else if (transform.position.x < Target.transform.position.x && transform.localScale.x < 0)
            ChangeDirection();

        Attack();
    }

    private void ChangeDirection()
    {
        transform.localScale = new Vector3(-transform.localScale.x, transform.localScale.y, transform.localScale.z);
    }

    protected virtual void Attack()
    {
        Animator.Play(AnimationNames.HashAttack);
    }
}
