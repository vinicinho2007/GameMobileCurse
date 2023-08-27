using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class PlayerController : MonoBehaviour
{
    [Header("Lerp")]
    public Transform target;
    public float delayLerp;
    private Vector3 _pos;

    [Header("Player")]
    public Rigidbody rig;
    public float speed;
    public float jumpSpeed;
    private bool _run, _jump;

    [Header("PowerUp")]
    private float _currentSpeed;
    private bool _invencible;

    [Header("Animation")]
    public Ease ease;
    public float durationAnim;
    public AnimationBase animationBase;
    public SOStringAnim run, death, victory, jump;

    [Header("Animation Collect")]
    public BounceHelper bounceHelper;

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

    public void Bounce()
    {
        if (bounceHelper!=null)
        {
            bounceHelper.Bounce();
        }
    }

    public void Jump()
    {
        if (!_jump)
        {
            animationBase.AnimTrigger(jump);
            rig.useGravity = true;
            rig.AddForce(transform.up*jumpSpeed, ForceMode.Impulse);
            _jump = true;
        }
    }

    public void StopJump()
    {
        transform.position = new Vector3(transform.position.x, -.5f, transform.position.z);
        _jump = false;
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
        transform.localScale = Vector3.zero;
        _run = true;
        transform.DOScale(1, durationAnim).SetEase(ease);
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
        transform.position = new Vector3(transform.position.x, -.5f, transform.position.z);
        _invencible = setInvencible;
    }
}