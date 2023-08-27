using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject[] objsFalses;
    public GameObject endGame;
    public SOInt coins;

    private void Start()
    {
        coins.value = 0;
    }

    public void EndGame()
    {
        foreach(GameObject obj in objsFalses) { obj.SetActive(false); }
        endGame.SetActive(true);
    }
}