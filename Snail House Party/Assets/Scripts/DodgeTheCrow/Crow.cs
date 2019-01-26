using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class Crow : AnimatedSprite
{
    public static Crow instance;

#pragma warning disable 0649
    [SerializeField]
    private Text indicator;
    [SerializeField]
    private AudioSource audiosource;
    [SerializeField]
    private AudioClip SquakAudio;
    [SerializeField]
    private AudioClip AttackAudio;
#pragma warning restore 0649

    private int attackHash, idleHash, turnHash;
    private bool isAlert = false;
    private Coroutine swoop;
    private int waittoTurnTimer;
    private float alertTimeLeft = 1.5f;
    private Vector3 origPos;
    override protected void Awake()
    {
        base.Awake();
        instance = this;
        origPos = transform.position;
    }
    private void Start()
    {
        idleHash = Animator.StringToHash("crowIdle");
        turnHash = Animator.StringToHash("crowTurn");
        attackHash = Animator.StringToHash("crowAttack");
    }
    public void Idle()
    {
        isAlert = false;
        sp.flipX = false;
        indicator.text = "...";
        indicator.color = Color.black;
    }
    public void Suspicious()
    {
        indicator.text = "?";
        indicator.color = Color.yellow;
    }
    public void Alert()
    {
        indicator.text = "!";
        isAlert = true;
        indicator.color = Color.red;
    }
    private void AttackSnail(DodgeSnail snail)
    {
        audiosource.clip = AttackAudio;
        animator.CrossFade(attackHash, 0.1f);
        sp.flipX = true;
        alertTimeLeft = 1.5f;
        if (swoop == null)
        {
            swoop = StartCoroutine(SwoopCoroutine(snail));
        }
    }
    public void OnSnailMoved(DodgeSnail snail)
    {
        if (isAlert)
        {
            AttackSnail(snail);
        }
    }

    internal void Init()
    {
        //start the audio.
        StartCoroutine(PlaySquaksCoroutine());
        indicator.color = Color.black;
    }
    IEnumerator PlaySquaksCoroutine()
    {
        waittoTurnTimer = Random.Range(2, 7);
        while (enabled)
        {
            if (audiosource.clip == SquakAudio)
            {
                audiosource.Play();
                yield return new WaitForSecondsRealtime(audiosource.clip.length);
                if (--waittoTurnTimer == 0)
                {
                    animator.CrossFade(turnHash, 0.2f);
                }
            }
            else yield return null;
        }
        yield return null;
    }
    private void Update()
    {
        if (isAlert)
        {
            alertTimeLeft -= Time.deltaTime;
        }
        if (alertTimeLeft <= 0)
        {
            Idle();
            alertTimeLeft = 1.5f;
            waittoTurnTimer = Random.Range(2, 7);
            animator.CrossFade(idleHash, 0.1f);
        }

    }
    IEnumerator SwoopCoroutine(DodgeSnail snail)
    {
        Vector3 destination = snail.transform.position;
        snail.spriteRenderer.enabled = false;
        while (Vector3.SqrMagnitude(transform.position - destination) > 0.1f)
        {
            transform.position = Vector3.MoveTowards(transform.position, destination, 0.5f);
            yield return null;
        }
        snail.transform.position = snail.startPos;
        snail.spriteRenderer.enabled = true;
        while (Vector3.SqrMagnitude(transform.position - origPos) > 0.1f)
        {
            transform.position = Vector3.MoveTowards(transform.position, origPos, 0.5f);
            yield return null;
        }
        //done catching.
        audiosource.clip = SquakAudio;
        yield return swoop = null;
    }
}
