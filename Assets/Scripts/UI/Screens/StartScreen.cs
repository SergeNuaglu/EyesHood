using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class StartScreen : Screen
{
    [SerializeField] private Button _startButton;
    [SerializeField] private Button _shopButton;

    public event UnityAction StartButtonClicked;
    public event UnityAction ShopButtonClicked;

    private void OnEnable()
    {
        _startButton.onClick.AddListener(OnPlayButtonClicked);
        _shopButton.onClick.AddListener(OnShopButtonClicked);
    }

    private void OnDisable()
    {
        _startButton.onClick.RemoveListener(OnPlayButtonClicked);
        _shopButton.onClick.RemoveListener(OnShopButtonClicked);
    }

    public override void Open()
    {
        base.Open();
        _startButton.interactable = true;
        _shopButton.interactable = true;
    }

    public override void Close()
    {
        base.Close();
        _startButton.interactable = false;
        _shopButton.interactable = false;
    }

    private void OnPlayButtonClicked()
    {
        StartButtonClicked?.Invoke();
    }

    private void OnShopButtonClicked()
    {
        ShopButtonClicked?.Invoke();
    }
}
