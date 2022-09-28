using UnityEngine;
using UnityEngine.UI;

public class Heart : MonoBehaviour
{
    [SerializeField] private Image _fillState;

    private Player _player;
    private bool _isEmpty = true;
    private bool _isCurrent;
    private float _fillMaxValue = 1;
    private float _fillMinValue = 0;

    public bool IsEmpty => _isEmpty;

    private void OnDisable()
    {
        if (_player != null)
            _player.HealthChanged -= OnHealthChanged;
    }

    private void Start()
    {
        SetFilling();
    }

    public void Init(Player player)
    {
        _player = player;
        _player.HealthChanged += OnHealthChanged;
        _player.GameOver += OnGameOver;
    }

    public void MakeCurrent()
    {
        _isCurrent = true;
    }

    public void SetIsEmptyFlag(bool flag)
    {
        _isEmpty = flag;
        SetFilling();
    }

    private void SetFilling()
    {
        if (_isEmpty)
            _fillState.fillAmount = _fillMinValue;
        else
            _fillState.fillAmount = _fillMaxValue;
    }

    private void OnHealthChanged(int health, int maxHealth)
    {
        if (_isCurrent)
            _fillState.fillAmount = (float)health / maxHealth;
    }

    private void OnGameOver()
    {
        _player.HealthChanged -= OnHealthChanged;
    }
}
