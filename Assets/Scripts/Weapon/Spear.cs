using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spear : ThrowingWeapon
{
    [Range(0,1)]
    [SerializeField] private float _throwTreshhold;

    public float ThrowTreshhold => _throwTreshhold;
}
