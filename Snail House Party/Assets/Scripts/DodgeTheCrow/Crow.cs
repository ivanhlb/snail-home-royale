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
        AudioManager.instance.PlayCrowAlert();
        indicator.text = "!";
        isAlert = true;
        indicator.color = Color.red;
    }
    private void AttackSnail(DodgeSnail snail)
    {
        AudioManager.instance.PlayCrowAttack();   
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
        WaitForSecondsRealtime oneSecond = new WaitForSecondsRealtime(1);
        waittoTurnTimer = Random.Range(1, 3);
        while (enabled)
        {
            AudioManager.instance.PlayCrowCaw();
            yield return oneSecond;
            if (--waittoTurnTimer == 0)
            {
                animator.CrossFade(turnHash, 0.2f);
            }
        }
        yield return null;
    }
    private void OnDisable()
    {
        
    }
    private void Update()
    {
        if (DodgeTheCrowController.instance.gameWon)
            enabled = false;
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
        snail.deco.enabled = false;
        snail.shell.enabled = false;
        while (Vector3.SqrMagnitude(transform.position - destination) > 0.1f)
        {
            transform.position = Vector3.MoveTowards(transform.position, destination, 0.5f);
            yield return null;
        }
        float rng = Random.value;
        if (rng < 0.33f)
        {
            AudioManager.instance.PlayDeathOne();
        }
        else if (rng < 0.66f)
        {
            AudioManager.instance.PlayDeathTwo();
        }
        else
        {
            AudioManager.instance.PlayDeathThree();
        }

        snail.transform.position = snail.startPos;
        snail.spriteRenderer.enabled = true;
        snail.deco.enabled = true;
        snail.shell.enabled = true;
        while (Vector3.SqrMagnitude(transform.position - origPos) > 0.1f)
        {
            transform.position = Vector3.MoveTowards(transform.position, origPos, 0.5f);
            yield return null;
        }
        //done catching.
        yield return swoop = null;
    }
}
