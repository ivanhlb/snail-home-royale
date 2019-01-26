using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CountdownManager : MonoBehaviour
{
    public bool gameStart = false, firstSound = true, secondSound = true, thirdSound = true, fourthSound = true;
    float countdownTimer = 0.0f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (countdownTimer < 3.0f )
        {
            if (firstSound && countdownTimer <= 1.0f)
            {
                //play first sound
                firstSound = false;
            }
            if (secondSound && countdownTimer > 1.0f && countdownTimer <= 2.0f)
            {
                //play second sound
                secondSound = false;
            }
            if (thirdSound && countdownTimer > 2.0f && countdownTimer <= 3.0f)
            {
                //play third sound
                thirdSound = false;
            }
            countdownTimer += Time.deltaTime;
        }
        else
        {
            if (fourthSound && !gameStart) {
                //play fourth sound
                fourthSound = false;
                gameStart = true;
            }
        }
    }
}
