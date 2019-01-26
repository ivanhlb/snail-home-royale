using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaceAudioManager : MonoBehaviour
{
    public static RaceAudioManager Instance { get; private set; }

    float[] footstepSoundDelay = new float[4];

    float footstepCooldownTime = 0.5f;
    private void Awake()
    {
        Instance = this;
    }

    public void PlayFootstep(int playerID)
    {
        if (footstepSoundDelay[playerID - 1] > Time.time)
            return;

        PlayFootstepActual();
        footstepSoundDelay[playerID - 1] = Time.time + footstepCooldownTime;
    }

    void PlayFootstepActual()
    {
        int footstep = Random.Range(0, 3);

        switch (footstep)
        {
            case 0:
                AudioManager.instance.PlayRaceWalkOne();
                break;
            case 1:
                AudioManager.instance.PlayRaceWalkTwo();
                break;
            case 2:
                AudioManager.instance.PlayRaceWalkThree();
                break;
        }
    }
}
