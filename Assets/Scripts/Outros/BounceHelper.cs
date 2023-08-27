using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class BounceHelper : MonoBehaviour
{
    public Ease ease;
    public float duarationAnimScale, scaleDistance;

    public void Bounce()
    {
        transform.DOScale(scaleDistance, duarationAnimScale).SetEase(ease).SetLoops(2, LoopType.Yoyo);
    }
}