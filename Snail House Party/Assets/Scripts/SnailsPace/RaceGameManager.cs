using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaceGameManager : MonoBehaviour
{
    public static RaceGameManager Instance { get; private set; }

    public bool raceOver = false, raceStarted = false;
    // Start is called before the first frame update
    void Awake()
    {
        Instance = this;
    }
}
