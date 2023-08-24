using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpCoins : PowerUpBase
{
    public float distanceMaxCoins;

    protected override void StartPowerUp()
    {
        base.StartPowerUp();
        Coin[] coins = GameObject.FindObjectsOfType<Coin>();
        foreach (Coin coin in coins)
        {
            if (Vector3.Distance(coin.transform.position, base.playerController.transform.position) < distanceMaxCoins)
            {
                coin.Collect();
            }
        }
    }

    protected override void EndPowerUp()
    {
        base.EndPowerUp();
    }
}