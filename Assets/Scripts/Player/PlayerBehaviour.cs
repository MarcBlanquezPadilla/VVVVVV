using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehaviour : MonoBehaviour
{
    private MovementBehaviour _move;
    private FlipBehaviour _flip;
    private GravityBehaviour _gravity;
    private Rigidbody2D _rb;
    private HealthBehaviour _health;
    private Animator _anim;

    [Header("REFERENCED")]
    [SerializeField] LayerMask floorLayer;
    [SerializeField] Transform groundChecker;
    [SerializeField] CheckPointsManager _cpManager;

    [Header("INFORMATION")]
    [SerializeField] private Vector3 dir;
    [SerializeField] private bool grounded;
    [SerializeField] private bool dead;
    [SerializeField] private bool infiniteInvert;

    void Awake()
    {
        _move = GetComponent<MovementBehaviour>();
        _flip = GetComponent<FlipBehaviour>();
        _gravity = GetComponent<GravityBehaviour>();
        _rb = GetComponent<Rigidbody2D>();
        _anim = GetComponent<Animator>();

        infiniteInvert = false;
        grounded = false;
        dead = false;

        transform.position = _cpManager.GetFirstCheckPointPos();
    }

    void Update()
    {

        if (!dead && !TimeManager.paused)
        {
            grounded = Physics2D.OverlapCircle(groundChecker.position, 0.01f, floorLayer);
            float hor = Input.GetAxis("Horizontal");
            dir = new Vector3(hor, _rb.velocity.y, 0);
            _move.MoveVelocity(dir);

            if (Input.GetKey(KeyCode.A) && !Input.GetKey(KeyCode.D))
            {
                _flip.FlipX(false);
            }
            else if (Input.GetKey(KeyCode.D) && !Input.GetKey(KeyCode.A))
            {
                _flip.FlipX(true);
            }

            if (Input.GetKeyDown(KeyCode.Space) && (grounded || infiniteInvert))
            {
                _gravity.FlipGravity();
            }
        }
    }

    public void Dead()
    {
        dead = true;
        SoundManager.Instance.PlayAudio("Die");
        _move.Freeze();
        _anim.SetInteger("state", 1);
        this.gameObject.layer = LayerMask.NameToLayer("Dead");
        transform.SetParent(null);
    }

    public void Revive()
    {
        dead = false;
        _move.FreezeRotation();
        _anim.SetInteger("state", 0);
        _gravity.SetDefaultGravity();
        TpToCheckPoint();
        this.gameObject.layer = LayerMask.NameToLayer("Player");
    }

    public void SetInfiniteInvert(bool b)
    {
        infiniteInvert = b;
    }

    public void TpToCheckPoint()
    {
        transform.position = _cpManager.GetCheckPointPos();
    }
}

