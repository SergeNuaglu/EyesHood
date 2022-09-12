using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(SpriteRenderer))]

public class Background : MonoBehaviour
{
    private Player _player;
    private SpriteRenderer _spriteRenderer;
    private bool _canDisable;

    public float XSize { get; private set; }

    public event UnityAction<Background> Disabled;

    private void Awake()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
        XSize = _spriteRenderer.bounds.size.x;
    }

    private void Update()
    {
        _canDisable = _player.transform.position.x - transform.position.x > XSize || transform.position.x - _player.transform.position.x > XSize;

        if (_canDisable)
        {
            Disabled?.Invoke(this);
            gameObject.SetActive(false);
        }
    }

    public void Init(Player player)
    {
        _player = player;
    }
}
