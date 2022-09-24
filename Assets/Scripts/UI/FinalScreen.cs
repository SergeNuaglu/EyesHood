using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public abstract class FinalScreen : MonoBehaviour
{
    [SerializeField] private Button _startOverButton;
    [SerializeField] private Button _exitButton;
    [SerializeField] private CanvasGroup _canvasGroup;

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

    public void Open()
    {
        _canvasGroup.alpha = 1;
        _canvasGroup.blocksRaycasts = true;
        _startOverButton.interactable = true;
        _exitButton.interactable = true;
    }

    public void Close()
    {
        _canvasGroup.alpha = 0;
        _canvasGroup.blocksRaycasts = false;
        _startOverButton.interactable = false;
        _exitButton.interactable = false;
    }

    protected abstract void OnStartOverButtonClicked();
    protected abstract void OnExitButtonClicked();
}
