using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject endGame;
    public SOInt coins;

    private void Start()
    {
        coins.value = 0;
    }

    public void EndGame()
    {
        endGame.SetActive(true);
    }
}