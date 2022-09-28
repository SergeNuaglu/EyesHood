using UnityEngine;

public class EnemyDieState : State
{
    [SerializeField] private float _dieDuration;

    private float _runningTime;

    private void OnEnable()
    {
        Animator.Play(AnimationNames.HashDie);
    }

    private void Update()
    {
        if (_runningTime <= _dieDuration)
            _runningTime += Time.deltaTime;
        else
            DestroyObjectAbroadScreen();
    }

    private void DestroyObjectAbroadScreen()
    {
        Camera camera = Camera.main;
        Vector3 disableLeftPoint = camera.ViewportToWorldPoint(new Vector3(0, 0.5f, camera.nearClipPlane));
        Vector3 disableRightPoint = camera.ViewportToWorldPoint(new Vector3(1, 0.5f, camera.nearClipPlane));

        if (transform.position.x < disableLeftPoint.x || transform.position.x > disableRightPoint.x)
        {
            Destroy(gameObject);
        }
    }
}
