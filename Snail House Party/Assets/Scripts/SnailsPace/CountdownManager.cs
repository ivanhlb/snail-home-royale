using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CountdownManager : MonoBehaviour
{
    AudioManager am;
    public bool gameStart = false, raceStartRevSound = false;
    float countdownTimer = 0.0f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!RaceGameManager.Instance.raceStarted)
        {
            return;
        }
        if (!raceStartRevSound)
        {
            AudioManager.instance.PlayRaceStart();
            raceStartRevSound = true;
        }
        if(countdownTimer < 3.0f)
        {
            countdownTimer += Time.deltaTime;
        }
        else
        {
            gameStart = true;
        }
        
       
    }
}
