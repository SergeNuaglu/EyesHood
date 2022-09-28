using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ClimbController : MonoBehaviour
{
    [SerializeField] private List<Ladder> _ladders;

    public Ladder CurrentLadder { get; private set; }

    public event UnityAction LadderUsed;

    private void OnEnable()
    {
        if (_ladders.Count > 0)
        {
            foreach (var ladder in _ladders)
            {
                ladder.PlayerWentToLadder += OnPlayerWentToLadder;
                ladder.PlayerGotOffLadder += OnPlayerGotOffLadder;
                ladder.PlayerMovedAway += OnPlayerMovedAway;
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
                    ladder.PlayerWentToLadder -= OnPlayerWentToLadder;
                    ladder.PlayerGotOffLadder -= OnPlayerGotOffLadder;
                    ladder.PlayerMovedAway -= OnPlayerMovedAway;
                }
            }
        }
    }

    private void OnPlayerWentToLadder(Ladder ladder)
    {
        CurrentLadder = ladder;
    }

    private void OnPlayerGotOffLadder()
    {
        LadderUsed?.Invoke();
    }

    private void OnPlayerMovedAway()
    {
        CurrentLadder = null;
    }
}
