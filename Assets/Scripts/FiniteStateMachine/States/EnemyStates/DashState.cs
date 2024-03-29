using UnityEngine;

public class DashState : State
{
    [SerializeField] private float _dashSpeed;

    private Vector2 _direction;

    private void OnEnable()
    {
        if (transform.position.x >= Target.transform.position.x)
            _direction = Vector2.left;
        else
            _direction = Vector2.right;

        if (transform.position.x > Target.transform.position.x && transform.localScale.x > 0)
            ChangeDirection();
        else if (transform.position.x < Target.transform.position.x && transform.localScale.x < 0)
            ChangeDirection();
    }

    private void Update()
    {
        transform.Translate(_direction * _dashSpeed * Time.deltaTime);
        Animator.Play(AnimationNames.HashDash);
    }

    private void ChangeDirection()
    {
        transform.localScale = new Vector3(-transform.localScale.x, transform.localScale.y, transform.localScale.z);
    }
}
