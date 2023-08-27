using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpPlayer : MonoBehaviour
{
    public PlayerController playerController;

    public void StopJump()
    {
        playerController.StopJump();
    }
}