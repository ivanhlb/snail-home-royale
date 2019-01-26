using System;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class Crow : AnimatedSprite
{
    public static Crow instance;

    [SerializeField]
    private Text indicator;
    [SerializeField]
    private AudioSource audiosource;
    [SerializeField]
    private AudioClip SquakAudio;
    [SerializeField]
    private AudioClip AttackAudio;
    private int attackHash, idleHash, turnHash;
    private float timeLeft = 1.5f;
    private bool isLooking;

    override protected void Awake()
    {
        base.Awake();
        instance = this;
    }
    private void Start()
    {
        idleHash = Animator.StringToHash("crowIdle");
        turnHash = Animator.StringToHash("crowTurn");
        attackHash = Animator.StringToHash("crowAttack");
    }
    public void Idle()
    {
        isLooking = false;
        indicator.text = "...";
        indicator.color = Color.black;
    }
    public void Suspicious()
    {
        indicator.text = "?";
        indicator.color = Color.yellow;
    }
    public void Look()
    {
        indicator.text = "!";
        isLooking = true;
        indicator.color = Color.red;
    }
    private void AttackSnail()
    {

    }
    public void OnSnailMoved(DodgeSnail snail)
    {
        if (isLooking)
        {
            snail.resetPosition();
        }
    }

    internal void Init()
    {
        //start the audio.
        audiosource.Play();
        indicator.color = Color.black;
    }
    private void Update()
    {
        Vector3 v = indicator.transform.position;
        v.y = (transform.position.y * 10) + 160;
        indicator.transform.position = v;
        if(Random.value < 0.1)
        {
            animator.CrossFade("Attack", 0.2f);
        }
    }
}
