using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpInvencible : PowerUpBase
{
    protected override void StartPowerUp()
    {
        base.StartPowerUp();
        base.playerController.SetPowerUpInvencible(true);
    }

    protected override void EndPowerUp()
    {
        base.EndPowerUp();
        base.playerController.SetPowerUpInvencible(false);
    }
}