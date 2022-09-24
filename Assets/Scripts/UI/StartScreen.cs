using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class StartScreen : Screen
{
    public event UnityAction PlayButtonClicked;
    public event UnityAction ShopButtonClicked;

    protected override void OnPlayButtonClicked()
    {
        PlayButtonClicked?.Invoke();
    }

    protected override void OnShopButtonClicked()
    {
        ShopButtonClicked?.Invoke();
    }
}
