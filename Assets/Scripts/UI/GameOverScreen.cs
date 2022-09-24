using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class GameOverScreen : FinalScreen
{
    public event UnityAction StartOverButtonClicked;
    public event UnityAction ExitButtonClicked;

    protected override void OnStartOverButtonClicked()
    {
        StartOverButtonClicked?.Invoke();
    }

    protected override void OnExitButtonClicked()
    {
        ExitButtonClicked?.Invoke();
    }
}
