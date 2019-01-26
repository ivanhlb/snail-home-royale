using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaceGameManager : MonoBehaviour
{
    public static RaceGameManager Instance { get; private set; }

    private GameManager gm;
    [SerializeField] GameObject instructionScreen;
    bool p1Rdy = false;
    bool p2Rdy = false;
    bool p3Rdy = false;
    bool p4Rdy = false;

    public bool raceOver = false, raceStarted = false;
    // Start is called before the first frame update
    void Awake()
    {
        Instance = this;
        gm = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
    }

    private void Update()
    {
        if (!raceStarted)
        {
            setReady();
            checkReady();
        }
    }

    void setReady()
    {
        if (gm.playerone)
        {
            if (Input.GetKeyDown(KeyCode.Joystick1Button1)){
                p1Rdy = true;
            }
        }
        if (gm.playertwo)
        {
            if (Input.GetKeyDown(KeyCode.Joystick2Button1)){
                p2Rdy = true;
            }
        }
        if (gm.playerthree)
        {
            if (Input.GetKeyDown(KeyCode.Joystick3Button1)){
                p3Rdy = true;
            }
        }
        if (gm.playerfour)
        {
            if (Input.GetKeyDown(KeyCode.Joystick4Button1)){
                p4Rdy = true;
            }
        }
    }

    void checkReady()
    {
        int playerCount = 0;
        int playerReady = 0;

        if (gm.playerone)
        {
            playerCount++;
            if (p1Rdy)
            {
                playerReady++;
            }
        }
        if (gm.playertwo)
        {
            playerCount++;
            if (p2Rdy)
            {
                playerReady++;
            }
        }
        if (gm.playerthree)
        {
            playerCount++;
            if (p3Rdy)
            {
                playerReady++;
            }
        }
        if (gm.playerfour)
        {
            playerCount++;
            if (p4Rdy)
            {
                playerReady++;
            }
        }

        if(playerCount == playerReady)
        {
            instructionScreen.SetActive(false);
            raceStarted = true;
        }
    }
}
