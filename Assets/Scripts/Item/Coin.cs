using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    public float lerp;
    public SOInt coins;
    private bool _collect;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Destroy();
        }
    }

    private void Destroy()
    {
        coins.value++;
        Destroy(gameObject);
    }

    private void Update()
    {
        if (_collect)
        {
            transform.position = Vector3.Lerp(transform.position, GameObject.FindObjectOfType<PlayerController>().transform.position, lerp * Time.deltaTime);

            if (Vector3.Distance(transform.position, GameObject.FindObjectOfType<PlayerController>().transform.position) < 2.5f)
            {
                Destroy();
            }
        }
    }

    public void Collect()
    {
        _collect = true;
    }
}