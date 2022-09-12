using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Door : MonoBehaviour
{
    [SerializeField] Vector3 _insideButtonPoint;
    [SerializeField] Button _insideButton;

    private Camera _camera;
    private Vector3 _viewPosition;

    private void Start()
    {
        _camera = Camera.main;
       _viewPosition = _camera.WorldToViewportPoint(_insideButtonPoint);
        _insideButton.gameObject.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent<Player>(out Player player))
        {
            _insideButton.transform.position = _viewPosition;
            _insideButton.gameObject.SetActive(true);
        }
    }
}
