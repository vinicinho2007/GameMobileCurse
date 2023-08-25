using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationBase : MonoBehaviour
{
    public Animator anim;

    public void AnimBool(bool animActive, SOStringAnim soStringAnim)
    {
        anim.SetBool(soStringAnim.anim, animActive);
    }

    public void AnimTrigger(SOStringAnim soStringAnim)
    {
        anim.SetTrigger(soStringAnim.anim);
    }

    public void AnimSpeed(float speed)
    {
        anim.speed = speed;
    }
}