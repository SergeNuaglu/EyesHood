using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HouseDoor : Door
{
    [SerializeField] Vector3 _playerSpawnPoint;
    [SerializeField] Vector3 _cameraPosition;
    [SerializeField] float _targetFieldOfView;

    private Camera _camera;

    private void Start()
    {
        _camera = Camera.main;
    }

    public void Enter()
    {
        if (Player != null)
        {
            Player.transform.position = _playerSpawnPoint;
            _camera.fieldOfView = _targetFieldOfView;
            _camera.transform.position = _cameraPosition;

            if (_camera.TryGetComponent<PlayerTracker>(out PlayerTracker playerTracker))
            {
                if (playerTracker.enabled)
                    playerTracker.enabled = false;
                else
                    playerTracker.enabled = true;
            }
        }
    }
}
