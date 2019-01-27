using UnityEngine;
using System.Collections.Generic;
using System.Collections;
using UnityEngine.UI;

public class DodgeTheCrowController : MonoBehaviour
{

    public static DodgeTheCrowController instance { get; private set; }
    public float finishingX;
    public bool inInstructions { get { return InstructionPanel.activeSelf; } }
    public bool gameStarted { get; private set; } = false;
#pragma warning disable 0649
    [SerializeField]
    private Sprite[] sprites;
    public Sprite[] shellSprites;
    public Sprite[] decoSprites;
    [Space]
    [SerializeField]
    private Image countdownImage;
    [SerializeField]
    private LineRenderer startingLine;
    [SerializeField]
    private LineRenderer finishLine;
    [SerializeField]
    private Transform DodgeSnailsPool;
    [SerializeField]
    private GameObject InstructionPanel;
#pragma warning restore 0649
    public bool gameWon { get; private set; } = false;
    private DodgeSnail[] snails;
    private GameManager gm;
    private int secondsLeft = 3;

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
            d[0].Init(PlayerIndex.PlayerOne, gm.playeronescore);
        }
        if (gm.playertwo)
        {
            s.Add(d[1]);
            d[1].Init(PlayerIndex.PlayerTwo, gm.playertwoscore);
        }
        if (gm.playerthree)
        {
            s.Add(d[2]);
            d[2].Init(PlayerIndex.PlayerThree, gm.playerthreescore);
        }
        if (gm.playerfour)
        {
            s.Add(d[3]);
            d[3].Init(PlayerIndex.PlayerFour, gm.playerfourscore);
        }
        snails = s.ToArray();
        if (snails.Length == 0)
        {
            s.Add(d[0]);
            d[0].Init(PlayerIndex.PlayerOne, gm.playeronescore);
            snails = new DodgeSnail[1] { d[0] };
        }
    }

    internal void Win(DodgeSnail snail)
    {
        AudioManager.instance.PlayLevelComplete();
        Debug.LogFormat("{0} won!", snail.playerIndex.ToString());
        gameWon = true;
        switch (snail.playerIndex)
        {
            case PlayerIndex.PlayerOne:
                gm.Addplayeronescore(1);
                break;
            case PlayerIndex.PlayerTwo:
                gm.Addplayertwoscore(1);
                break;
            case PlayerIndex.PlayerThree:
                gm.Addplayerthreescore(1);
                break;
            case PlayerIndex.PlayerFour:
                gm.Addplayerfourscore(1);
                break;
            default:
                //gg
                break;
        }

        gm.loadnextgame();
    }

    IEnumerator CountDownCorountine()
    {
        WaitForSecondsRealtime waitOneSec = new WaitForSecondsRealtime(1f);
        countdownImage.gameObject.SetActive(true);
        AudioManager.instance.PlayRaceStart();
        do
        {
            yield return waitOneSec;
            countdownImage.sprite = sprites[--secondsLeft];
        }
        while (secondsLeft > 0);
        //start game officially.
        countdownImage.gameObject.SetActive(false);
        gameStarted = true;
        Crow.instance.Init();
        AudioManager.instance.PlayBirbBgm();
        yield return null;
    }
}
