using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class RightRollTransition : Transition
{
    public void Transit()
    {
        NeedTransit = true;
    }
}
