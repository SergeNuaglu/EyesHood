using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

[RequireComponent(typeof(Image))]

public class WeaponButton : MonoBehaviour
{
    [SerializeField] private Weapon _weapon;
    [SerializeField] private Button _button;
    [SerializeField] private Sprite _iconForAttackButton;
    [SerializeField] private Sprite _unselectedIcon;
    [SerializeField] private Sprite _selectedIcon;

    private Image _image;
    private bool _isPressed = false;

    public event UnityAction<Weapon, Sprite> Clicked;

    public Image Image => _image;
    public bool IsPressed => _isPressed;

    private void Awake()
    {
        _image = GetComponent<Image>();
    }

    private void OnEnable()
    {
        _button.onClick.AddListener(OnClickButton);
    }

    private void OnDisable()
    {
        _button.onClick.RemoveListener(OnClickButton);
    }

    public void UnselectButton()
    {
        _isPressed = false;
        _image.sprite = _unselectedIcon;
    }

    private void OnClickButton()
    {
        Clicked?.Invoke(_weapon, _iconForAttackButton);

        if (_image.sprite == _selectedIcon)
        {
            _isPressed = false;
            _image.sprite = _unselectedIcon;
        }
        else
        {
            _isPressed = true;
            _image.sprite = _selectedIcon;
        }
    }

}
