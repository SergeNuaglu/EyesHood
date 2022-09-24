using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class RestartScreen : Screen
{
    public event UnityAction RestartButtonClicked;
    public event UnityAction ShopButtonClicked;

    protected override void OnPlayButtonClicked()
    {
        RestartButtonClicked?.Invoke();
    }

    protected override void OnShopButtonClicked()
    {
        ShopButtonClicked?.Invoke();
    }
}
