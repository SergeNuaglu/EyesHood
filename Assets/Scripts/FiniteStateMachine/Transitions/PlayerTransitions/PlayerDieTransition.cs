public class PlayerDieTransition : Transition
{
    protected override void OnEnable()
    {
        base.OnEnable();
        Target.GameOver += OnGameOver;
    }

    private void OnDisable()
    {
        Target.GameOver -= OnGameOver;
    }

    private void OnGameOver()
    {
        NeedTransit = true;
    }
}
