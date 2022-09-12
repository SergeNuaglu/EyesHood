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

    public event UnityAction<Ladder> PlayerWentIn;
    public event UnityAction PlayerWentOut;

    public void ExitLadder(Transform target, bool isTopPosition)
    {
        if (isTopPosition)
            target.position = new Vector3(target.position.x, _topExitPoint.position.y, target.position.z);
        else
            target.position = new Vector3(target.position.x, _bottomExitPoint.position.y, target.position.z);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent<Player>(out Player player))
            PlayerWentIn?.Invoke(this);
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.TryGetComponent<Player>(out Player player))
            PlayerWentOut?.Invoke();
    }
}
