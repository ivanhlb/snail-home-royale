using UnityEngine;
using System.Collections.Generic;
public class DodgeTheCrowController : MonoBehaviour
{
    public static DodgeTheCrowController instance { get; private set; }
    public bool inInstructions { get { return InstructionPanel.activeSelf; } }
#pragma warning disable 0649
    [SerializeField]
    private LineRenderer startingLine;
    [SerializeField]
    private Transform DodgeSnailsPool;
    [SerializeField]
    private GameObject InstructionPanel;
    private Dictionary<PlayerIndex, DodgeSnail> snails = new Dictionary<PlayerIndex, DodgeSnail>();
#pragma warning restore 0649

    private GameManager gm;

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
        //line them up.
        LineUp();
    }
    private void LineUp()
    {
        int padding = 2;
        Vector3 pointA = startingLine.GetPosition(0);
        Vector3 pointB = startingLine.GetPosition(1);
        Vector3 currPos = pointA;

        float disSpread = (Vector3.Distance(pointA, pointB) - padding) / snails.Count;
        Dictionary<PlayerIndex, DodgeSnail>.ValueCollection values = snails.Values;

        foreach (DodgeSnail s in values)
        {
            currPos.y += disSpread;
            s.transform.position = currPos;
        }
    }
}
