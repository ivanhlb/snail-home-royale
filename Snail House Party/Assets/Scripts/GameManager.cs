﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public bool playerone = false;
    public bool playertwo = false;
    public bool playerthree = false;
    public bool playerfour = false;

    int playeronescore;
    int playertwoscore;
    int playerthreescore;
    int playerfourscore;

    private void Awake()
    {
        GameObject[] objs = GameObject.FindGameObjectsWithTag("GameManager");

        if (objs.Length > 1)
        {
            Destroy(this.gameObject);
        }

        DontDestroyOnLoad(this.gameObject);
    }
    public void Addplayeronescore(int score)
    {
        playeronescore += score;
    }
    public void Addplayertwoscore(int score)
    {
        playertwoscore += score;
    }
    public void Addplayerthreescore(int score)
    {
        playerthreescore += score;
    }
    public void Addplayerfourscore(int score)
    {
        playerfourscore += score;
    }

    public void loadnextgame()
    {

    }
}
