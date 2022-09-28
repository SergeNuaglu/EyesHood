using UnityEngine;
using UnityEngine.UI;

public abstract class Door : MonoBehaviour
{
    [SerializeField] Button _button;
    [SerializeField] CanvasGroup _canvasGroup;

    protected Player Player;

    private void Awake()
    {
        _canvasGroup.alpha = 0;
        _button.interactable = false;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent<Player>(out Player player))
        {
            Player = player;
            _canvasGroup.alpha = 1;
            _button.interactable = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.TryGetComponent<Player>(out Player player))
        {
            _canvasGroup.alpha = 0;
            _button.interactable = false;
        }
    }
}
