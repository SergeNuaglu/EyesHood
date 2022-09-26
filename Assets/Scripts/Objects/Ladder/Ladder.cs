using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Ladder : MonoBehaviour
{
    [SerializeField] private ZoneOfLadder _topZone;
    [SerializeField] private ZoneOfLadder _bottomZone;
    [SerializeField] private Transform _bottomExitPoint;
    [SerializeField] private Transform _topExitPoint;
    [SerializeField] private Transform _topEnterPoint;

    public ZoneOfLadder TopZone => _topZone;
    public ZoneOfLadder BottomZone => _bottomZone;
    public Transform TopEnterPoint => _topEnterPoint;

    public event UnityAction<Ladder> PlayerWentToLadder;
    public event UnityAction PlayerMovedAway;
    public event UnityAction PlayerGotOffLadder;

    private void OnEnable()
    {
        _topZone.PlayerEnteredZone += OnPlayerEnteredZone;
        _bottomZone.PlayerEnteredZone +=OnPlayerEnteredZone;
        _topZone.PlayerWentOutZone += OnPlayerWentOutZone;
        _bottomZone.PlayerWentOutZone += OnPlayerWentOutZone;
    }

    private void OnDisable()
    {
        _topZone.PlayerEnteredZone -= OnPlayerEnteredZone;
        _bottomZone.PlayerEnteredZone -= OnPlayerEnteredZone;
        _topZone.PlayerWentOutZone -= OnPlayerWentOutZone;
        _bottomZone.PlayerWentOutZone -= OnPlayerWentOutZone;
    }

    public void Exit()
    {
        PlayerGotOffLadder?.Invoke();
    }

    public void Exit(Transform target, bool isTopPosition)
    {
        if (isTopPosition)
            target.position = new Vector3(target.position.x, _topExitPoint.position.y, target.position.z);
        else
            target.position = new Vector3(target.position.x, _bottomExitPoint.position.y, target.position.z);

        PlayerGotOffLadder?.Invoke();
    }

    private void OnPlayerEnteredZone()
    {
        PlayerWentToLadder?.Invoke(this);
    }


   private void OnPlayerWentOutZone()
    {
        PlayerMovedAway?.Invoke();
    }
}
