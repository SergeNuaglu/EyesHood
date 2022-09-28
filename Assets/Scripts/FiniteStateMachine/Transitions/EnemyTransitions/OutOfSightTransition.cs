using UnityEngine;

[RequireComponent(typeof(LineOfSightChecker))]

public class OutOfSightTransition : Transition
{
    private LineOfSightChecker _lineOfSideChecker;

    private void Awake()
    {
        _lineOfSideChecker = GetComponent<LineOfSightChecker>();
    }

    private void Update()
    {
        Vector3 movementDirection = transform.localScale.x > 0 ? Vector2.right : Vector2.left;
        NeedTransit = _lineOfSideChecker.Check(movementDirection, Target.transform.position) == false;
    }
}
