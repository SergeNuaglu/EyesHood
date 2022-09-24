using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class WinScreen : FinalScreen
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
