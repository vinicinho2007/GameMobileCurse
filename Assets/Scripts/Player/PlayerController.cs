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

    [Header("Animation")]
    public AnimationBase animationBase;
    public SOStringAnim run, death, victory;

    private void Start()
    {
        _currentSpeed = speed;
    }

    private void Update()
    {
        if (!_run) { animationBase.AnimBool(false, run); return; }

        animationBase.AnimBool(true,run);
        _pos = target.position;
        _pos.y = transform.position.y;
        _pos.z = transform.position.z;

        transform.position = Vector3.Lerp(transform.position, _pos, delayLerp);
        transform.Translate(transform.forward * speed * Time.deltaTime);
    }

    private void OnCollisionEnter(Collision collision)
    {
        var t = transform.position;
        if (collision.gameObject.CompareTag("Enemy"))
        {
            if (!_invencible)
            {
                t.z -= 1f;
                animationBase.AnimTrigger(death);
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
            t.z -= 1f;
            animationBase.AnimTrigger(victory);
            _run = false;
            GameObject.FindObjectOfType<GameManager>().EndGame();
        }
        transform.position = t;
    }

    public void StartGame()
    {
        _run = true;
    }

    public void PowerUpSpeed(float newSpeed)
    {
        animationBase.AnimSpeed(1.5f);
        speed = newSpeed;
    }

    public void ResetPowerUpSpeed()
    {
        animationBase.AnimSpeed(1.2f);
        speed = _currentSpeed;
    }

    public void SetPowerUpInvencible(bool setInvencible)
    {
        _invencible = setInvencible;
    }
}