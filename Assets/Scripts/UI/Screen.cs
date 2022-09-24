using UnityEngine;
using UnityEngine.UI;

public abstract class Screen : MonoBehaviour
{
    [SerializeField] private CanvasGroup _canvasGroup;
    [SerializeField] private Button _playButton;
    [SerializeField] private Button _shopButton;

    private void OnEnable()
    {
        _playButton.onClick.AddListener(OnPlayButtonClicked);
        _shopButton.onClick.AddListener(OnShopButtonClicked);
    }

    private void OnDisable()
    {
        _playButton.onClick.RemoveListener(OnPlayButtonClicked);
        _shopButton.onClick.RemoveListener(OnShopButtonClicked);
    }

    public void Open()
    {
        _canvasGroup.alpha = 1;
        _canvasGroup.blocksRaycasts = true;
        _playButton.interactable = true;
        _shopButton.interactable = true;
    }

    public void Close()
    {
        _canvasGroup.alpha = 0;
        _canvasGroup.blocksRaycasts = false;
        _playButton.interactable = false;
        _shopButton.interactable = false;
    }

    protected abstract void OnPlayButtonClicked();
    protected abstract void OnShopButtonClicked();
}
