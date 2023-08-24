using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header("Lerp")]
    public Transform target;
    public float delayLerp;
    private Vector3 _pos;

    [Header("Player")]
    public float speed;
    private bool _run;

    private void Update()
    {
        if (!_run) { return; }

        _pos = target.position;
        _pos.y = transform.position.y;
        _pos.z = transform.position.z;

        transform.position = Vector3.Lerp(transform.position, _pos, delayLerp);
        transform.Translate(transform.forward * speed * Time.deltaTime);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            _run = false;
            GameObject.FindObjectOfType<GameManager>().EndGame();
        }

        if (collision.gameObject.CompareTag("End"))
        {
            _run = false;
            GameObject.FindObjectOfType<GameManager>().EndGame();
        }
    }

    public void StartGame()
    {
        _run = true;
    }
}