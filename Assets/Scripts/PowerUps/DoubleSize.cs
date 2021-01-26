using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoubleSize : PowerUp
{
    [SerializeField] private float duration;
    protected override void ActivatePowerUp()
    {
        EventManager.InvokeDoubleSize(duration);
    }
}