using UnityEngine;
using System.Collections.Generic;
using System.Collections;
using UnityEngine.UI;

public class DodgeTheCrowController : MonoBehaviour
{

    public static DodgeTheCrowController instance { get; private set; }
    public bool inInstructions { get { return InstructionPanel.activeSelf; } }
    public bool gameStarted { get; private set; } = false;
#pragma warning disable 0649
    [SerializeField]
    private Text countdownText;
    [SerializeField]
    private LineRenderer startingLine;
    [SerializeField]
    private Transform DodgeSnailsPool;
    [SerializeField]
    private GameObject InstructionPanel;
#pragma warning restore 0649

    private Dictionary<PlayerIndex, DodgeSnail> snails = new Dictionary<PlayerIndex, DodgeSnail>();
    private GameManager gm;
    private int secondsLeft = 5;
    private bool debug = true;
    private void Awake()
    {
        instance = this;
    }
    public void OnReady(PlayerIndex playerIndex)
    {
        Dictionary<PlayerIndex, DodgeSnail>.ValueCollection values = snails.Values;
        foreach (DodgeSnail snail in values)
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
        gm = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
        DodgeSnail[] d = DodgeSnailsPool.GetComponentsInChildren<DodgeSnail>();
        if (gm.playerone)
        {
            snails.Add(PlayerIndex.PlayerOne, d[0]);
            d[0].Init(PlayerIndex.PlayerOne);
        }
        if (gm.playertwo)
        {
            snails.Add(PlayerIndex.PlayerTwo, d[1]);
            d[1].Init(PlayerIndex.PlayerTwo);
        }
        if (gm.playerthree)
        {
            snails.Add(PlayerIndex.PlayerThree, d[2]);
            d[2].Init(PlayerIndex.PlayerThree);
        }
        if (gm.playerfour)
        {
            snails.Add(PlayerIndex.PlayerFour, d[3]);
            d[3].Init(PlayerIndex.PlayerFour);
        }
        //for debugging
        if (snails.Count == 0)
        {
            snails.Add(PlayerIndex.PlayerOne, d[0]);
            d[0].Init(PlayerIndex.PlayerOne);
        }
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
