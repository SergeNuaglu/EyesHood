using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundGenerator : ObjectPool
{
    [SerializeField] private Background _prefab;
    [SerializeField] private Vector3 _firstPosition;
    [SerializeField] private Player _player;

    private Background _newBackground;
    private Vector3 _leftXInstallationPoint;
    private Vector3 _rightXInstallationPoint;
    private float _minDistance;

    private void Awake()
    {
        Initialize(_prefab.gameObject);
        SetBackgrondToPoint(_firstPosition);

        if (_newBackground != null)
        {
            _minDistance = _newBackground.XSize;
            SetInstallationPoints(_newBackground);
        }
    }

    private void Update()
    {
        if (_player.transform.position.x - _leftXInstallationPoint.x < _minDistance)
        {
            SetBackgrondToPoint(_leftXInstallationPoint);
            _leftXInstallationPoint.x -= _minDistance;
        }
        else if (_rightXInstallationPoint.x - _player.transform.position.x < _minDistance)
        {
            SetBackgrondToPoint(_rightXInstallationPoint);
            _rightXInstallationPoint.x += _minDistance;
        }
    }

    private void SetBackgrondToPoint(Vector3 InstallationPoint)
    {
        if (TryGetObject(out GameObject item))
        {
            item.SetActive(true);
            item.transform.position = InstallationPoint;
            _newBackground = item.GetComponent<Background>();
            _newBackground.Init(_player);
            _newBackground.Disabled += OnDisabled;
        }
    }

    private void SetInstallationPoints(Background background)
    {
        Vector3 backgroundPosition = _newBackground.transform.position;
        _leftXInstallationPoint = new Vector3(backgroundPosition.x - _newBackground.XSize, backgroundPosition.y, backgroundPosition.z);
        _rightXInstallationPoint = new Vector3(backgroundPosition.x + _newBackground.XSize, backgroundPosition.y, backgroundPosition.z);
    }

    private void OnDisabled(Background disabledBackground)
    {
        disabledBackground.Disabled -= OnDisabled;

        if (_player.transform.position.x > disabledBackground.transform.position.x)
            _leftXInstallationPoint.x += _minDistance;
        else if (_player.transform.position.x < disabledBackground.transform.position.x)
            _rightXInstallationPoint.x -= _minDistance;
    }
}
