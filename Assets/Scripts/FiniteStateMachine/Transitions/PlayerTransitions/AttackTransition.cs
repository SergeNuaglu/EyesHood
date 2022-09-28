using UnityEngine;

public class AttackTransition : Transition
{
    [SerializeField] private AttackButton _attackButton;

    protected override void OnEnable()
    {
        base.OnEnable();
        _attackButton.AtackButtonPressed += OnAttackButtonPressed;
    }
    private void OnDisable()
    {
        _attackButton.AtackButtonPressed -= OnAttackButtonPressed;
    }

    private void OnAttackButtonPressed()
    {
        NeedTransit = true;
    }
}
