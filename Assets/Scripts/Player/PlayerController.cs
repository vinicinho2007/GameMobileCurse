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

    [Header("PowerUp")]
    private float _currentSpeed;
    private bool _invencible;

    private void Start()
    {
        _currentSpeed = speed;
    }

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
            if (!_invencible)
            {
                _run = false;
                GameObject.FindObjectOfType<GameManager>().EndGame();
            }
            else
            {
                Destroy(collision.gameObject);
            }
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

    public void PowerUpSpeed(float newSpeed)
    {
        speed = newSpeed;
    }

    public void ResetPowerUpSpeed()
    {
        speed = _currentSpeed;
    }

    public void SetPowerUpInvencible(bool setInvencible)
    {
        _invencible = setInvencible;
    }
}