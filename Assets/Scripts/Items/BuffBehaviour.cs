using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BuffBehaviour : MonoBehaviour
{
    private SpriteRenderer _sprite;
    private Collider2D _collider2D;

    [Header("REFERENCES")]
    [SerializeField] protected GameObject Buff_FX;

    [Header("PROPERTIES")]
    [SerializeField] private float durationTime;

    [Header("INFORMATION")]
    [SerializeField] private float timer;
    [SerializeField] private bool active;
    [SerializeField] protected GameObject player;

    private void Awake()
    {
        _sprite = GetComponent<SpriteRenderer>();
        _collider2D = GetComponent<Collider2D>();

        Buff_FX.SetActive(false);
        timer = 0;
    }

    private void Update()
    {
        if (!TimeManager.paused)
        {
            if (active)
            {
                timer += Time.unscaledDeltaTime;

                if (timer > durationTime)
                {

                    timer = 0;
                    active = false;
                    SoundManager.Instance.PlayAudio("Debuff");
                    Deactivate();
                }
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        player = collision.gameObject;
        _collider2D.enabled = false;
        _sprite.enabled = false;
        active = true;
        SoundManager.Instance.PlayAudio("Buff");
        Activate();
    }

    public abstract void Activate();

    public abstract void Deactivate();
}
