using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class FinalScreen : Screen
{
    [SerializeField] private Button _startOverButton;
    [SerializeField] private Button _exitButton;

    public event UnityAction StartOverButtonClicked;
    public event UnityAction ExitButtonClicked;

    private void OnEnable()
    {
        _startOverButton.onClick.AddListener(OnStartOverButtonClicked);
        _exitButton.onClick.AddListener(OnExitButtonClicked);
    }

    private void OnDisable()
    {
        _startOverButton.onClick.RemoveListener(OnStartOverButtonClicked);
        _exitButton.onClick.RemoveListener(OnExitButtonClicked);
    }

    public override void Open()
    {
        base.Open();
        _startOverButton.interactable = true;
        _exitButton.interactable = true;
    }

    public override void Close()
    {
        base.Close();
        _startOverButton.interactable = false;
        _exitButton.interactable = false;
    }

    private void OnStartOverButtonClicked()
    {
        StartOverButtonClicked?.Invoke();
    }

    private void OnExitButtonClicked()
    {
        ExitButtonClicked?.Invoke();
    }
}
