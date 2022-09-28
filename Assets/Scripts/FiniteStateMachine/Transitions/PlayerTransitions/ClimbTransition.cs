using UnityEngine;

public class ClimbTransition : Transition
{
    [SerializeField] private float climbThreshold = 0.2f;

    private Ladder _currentLadder;

    private void Update()
    {
        _currentLadder = Target.ClimbController.CurrentLadder;

        if (_currentLadder != null)
        {
            if (Target.Foot.IsGrounded)
            {
                if (_currentLadder.TopZone.IsPlayerInside)
                {
                    if (Target.MoveInput.y < -climbThreshold)
                    {
                        NeedTransit = true;
                    }
                }
                else if (_currentLadder.BottomZone.IsPlayerInside)
                {
                    if (Target.MoveInput.y > climbThreshold)
                    {
                        NeedTransit = true;
                    }
                }
            }
        }
    }
}
