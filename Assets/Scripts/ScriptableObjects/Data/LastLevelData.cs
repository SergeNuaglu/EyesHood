using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Data", menuName = "Data/Last Level Data", order = 51)]

public class LastLevelData: ScriptableObject
{
    public int Data { get; private set; }

    public void Set(int data)
    {
        Data = data;
    }

    public void Reset()
    {
        int defaultValue = 0;

        Data = defaultValue;
    }
}
