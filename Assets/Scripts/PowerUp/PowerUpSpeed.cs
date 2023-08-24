using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpSpeed : PowerUpBase
{
    [Header("PowerUp Speed")]
    public float newSpeed;

    protected override void StartPowerUp()
    {
        base.StartPowerUp();
        base.playerController.PowerUpSpeed(newSpeed);
    }

    protected override void EndPowerUp()
    {
        base.EndPowerUp();
        base.playerController.ResetPowerUpSpeed();
    }
}