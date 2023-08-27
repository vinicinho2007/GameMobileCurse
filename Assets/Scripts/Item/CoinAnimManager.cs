using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class CoinAnimManager : MonoBehaviour
{
    public List<Coin> coins;
    public Ease ease;
    public float duarationAnimScale, delayScale;

    public void AddCoin(Coin coin)
    {
        if (!coins.Contains(coin))
        {
            coins.Add(coin);
            coin.transform.localScale = Vector3.zero;
        }
    }

    public IEnumerator AnimCoinsCoroutine()
    {
        foreach(Coin c in coins)
        {
            c.transform.localScale = Vector3.zero;
        }

        yield return null;
        Organize();

        for(int i = 0; i < coins.Count; i++)
        {
            coins[i].transform.DOScale(1, duarationAnimScale).SetEase(ease);
            yield return new WaitForSeconds(delayScale);
        }
    }

    private void Organize()
    {
        coins = coins.OrderBy(x => Vector3.Distance(this.transform.position, x.transform.position)).ToList();
    }
}