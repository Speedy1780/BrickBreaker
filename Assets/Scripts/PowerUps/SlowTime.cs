using UnityEngine;

public class SlowTime : PowerUp
{
    [SerializeField] private float slowFactor;
    [SerializeField] private float duration;
    protected override void ActivatePowerUp()
    {
        EventManager.InvokeSlowTime(duration, slowFactor);
    }
}