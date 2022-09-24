using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Enemy))]

public class GroundEndTransition : Transition
{
    private Foot _foot;

    private void Start()
    {
        if (GetComponent<Enemy>().Foot != null)
            _foot = GetComponent<Enemy>().Foot;
    }

    private void Update()
    {
        if (_foot != null)
            if (_foot.IsGrounded == false)
                NeedTransit = true;
    }
}
