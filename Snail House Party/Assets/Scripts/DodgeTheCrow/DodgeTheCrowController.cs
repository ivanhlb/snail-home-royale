using UnityEngine;
using System.Collections.Generic;
using System.Collections;
using UnityEngine.UI;
using System;

public class DodgeTheCrowController : MonoBehaviour
{

    public static DodgeTheCrowController instance { get; private set; }
    public float finishingX;
    public bool inInstructions { get { return InstructionPanel.activeSelf; } }
    public bool gameStarted { get; private set; } = false;
#pragma warning disable 0649
    [SerializeField]
    private Text countdownText;
    [SerializeField]
    private LineRenderer startingLine;
    [SerializeField]
    private LineRenderer finishLine;
    [SerializeField]
    private Transform DodgeSnailsPool;
    [SerializeField]
    private GameObject InstructionPanel;
#pragma warning restore 0649

    private DodgeSnail[] snails;
    private GameManager gm;
    private int secondsLeft = 5;

    private void Awake()
    {
        instance = this;
    }
    public void OnReady(PlayerIndex playerIndex)
    {
        foreach (DodgeSnail snail in snails)
        {
            if (!snail.ready)
            {
                return;
            }
        }
        //clear instruction screen
        InstructionPanel.SetActive(false);
        StartCoroutine(CountDownCorountine());
    }
    private void Start()
    {
        //display instructions
        finishingX = finishLine.GetPosition(0).x;
        gm = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
        DodgeSnail[] d = DodgeSnailsPool.GetComponentsInChildren<DodgeSnail>();
        List<DodgeSnail> s = new List<DodgeSnail>();
        if (gm.playerone)
        {
            s.Add(d[0]);
            d[0].Init(PlayerIndex.PlayerOne);
        }
        if (gm.playertwo)
        {
            s.Add(d[1]);
            d[1].Init(PlayerIndex.PlayerTwo);
        }
        if (gm.playerthree)
        {
            s.Add(d[2]);
            d[2].Init(PlayerIndex.PlayerThree);
        }
        if (gm.playerfour)
        {
            s.Add(d[3]);
            d[3].Init(PlayerIndex.PlayerFour);
        }
        snails = s.ToArray();
    }

    internal void Win(DodgeSnail snail)
    {
        Debug.LogFormat("{0} won!", snail.playerIndex.ToString());
    }

    IEnumerator CountDownCorountine()
    {
        WaitForSecondsRealtime waitOneSec = new WaitForSecondsRealtime(1f);
        countdownText.gameObject.SetActive(true);
        while (secondsLeft > 0)
        {
            yield return waitOneSec;
            countdownText.text = (--secondsLeft).ToString();
        }
        //start game officially.
        countdownText.gameObject.SetActive(false);
        gameStarted = true;
        Crow.instance.Init();
        yield return null;
    }
}
