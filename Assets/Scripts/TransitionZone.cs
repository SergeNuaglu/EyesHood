using UnityEngine;

public class TransitionZone : MonoBehaviour
{
    [SerializeField] Vector3 _spawnPoint;
    [SerializeField] Vector3 _cameraPosition;
    [SerializeField] float _targetFieldOfView;

    private Camera _camera;

    private void Start()
    {
        _camera = Camera.main;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent<Player>(out Player player))
        {
            player.ClimbController.CurrentLadder.Exit();
            player.transform.position = _spawnPoint;
            _camera.fieldOfView = _targetFieldOfView;
            _camera.transform.position = _cameraPosition;

            if (_camera.TryGetComponent<PlayerTracker>(out PlayerTracker playerTracker))
            {
                if (playerTracker.enabled == false)
                    playerTracker.enabled = true;
            }
        }
    }
}
