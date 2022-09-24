using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClimbController : MonoBehaviour
{
    [SerializeField] private List<Ladder> _ladders;

    public Ladder CurrentLadder { get; private set; }

    private void OnEnable()
    {
        if (_ladders.Count > 0)
        {
            foreach (var ladder in _ladders)
            {
                ladder.PlayerWentIn += OnPlayerWentIn;
                ladder.PlayerWentOut += OnPlayerWentOut;
            }
        }
    }

    private void OnDisable()
    {
        if (_ladders.Count > 0)
        {
            if (_ladders.Count != 0)
            {
                foreach (var ladder in _ladders)
                {
                    ladder.PlayerWentIn -= OnPlayerWentIn;
                    ladder.PlayerWentOut -= OnPlayerWentOut;
                }
            }
        }
    }

    private void OnPlayerWentIn(Ladder ladder)
    {
        CurrentLadder = ladder;
    }

    private void OnPlayerWentOut()
    {
        CurrentLadder = null;
    }
}
