using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpBase : MonoBehaviour
{
    [Header("PowerUp Base")]
    public GameObject imgPowerUp;
    public float duration;
    public PlayerController playerController;

    private void Start()
    {
        if(playerController == null) { playerController = GameObject.FindObjectOfType<PlayerController>(); }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            gameObject.SetActive(false);
            StartPowerUp();
        }
    }

    protected virtual void StartPowerUp()
    {
        imgPowerUp.SetActive(true);
        Invoke(nameof(EndPowerUp), duration);
    }

    protected virtual void EndPowerUp()
    {
        imgPowerUp.SetActive(false);
        Destroy(gameObject);
    }
}