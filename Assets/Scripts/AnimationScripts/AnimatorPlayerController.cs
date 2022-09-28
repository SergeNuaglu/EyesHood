public static class AnimatorPlayerController
{
    public static class Params
    {
        public const string WalkSpeed = nameof(WalkSpeed);
        public const string ClimbSpeed = nameof(ClimbSpeed);
        public const string SwingPower = nameof(SwingPower);
    }

    public static class States
    {
        public const string Idle = "Base Layer.Idle";
        public const string Walk = "Base Layer.Walk";
        public const string Run = "Base Layer.Run";
        public const string Roll = "Base Layer.Roll";
        public const string Climb = "Base Layer.Climb";
        public const string Jump = "Base Layer.Jump";
        public const string Attack = "Base Layer.Attack";
        public const string Attack2 = "Base Layer.Attack2";
        public const string Dash = "Base Layer.Dash";
        public const string Die = "Base Layer.Die";
        public const string ApplyDamage = "Base Layer.ApplyDamage";
        public const string Swing = "Base Layer.Swing";
        public const string PrepareToThrow = "Base Layer.PrepareToThrow";
    }
}
