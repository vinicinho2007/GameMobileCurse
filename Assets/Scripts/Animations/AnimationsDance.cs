using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationsDance : MonoBehaviour
{
    public Animator anim;
    public SOStringAnim[] soStringAnims;
    public float delay;
    private int dance;

    public void NewDance()
    {
        dance++;
        if(dance>= soStringAnims.Length)
        {
            dance = 0;
        }
        Invoke(nameof(AnimTrigger), delay);
    }

    public void AnimTrigger()
    {
        anim.SetTrigger(soStringAnims[dance].anim);
    }
}