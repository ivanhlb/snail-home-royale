using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    //AudioManager.instance.PlayRaceBgm(); //call this code in your program to play the sound

    public AudioSource audios;
    public AudioClip snailracebgm;
    public AudioClip startbgm;
    public AudioClip gobblerbgm;
    public AudioClip dodgethecrowbgm;
    public AudioClip passthesaltbgm;
    public AudioClip snailraceStart;
    public AudioClip snailraceWalkone;
    public AudioClip snailraceWalktwo;
    public AudioClip snailraceWalkthree;
    public AudioClip snailDeathOne;
    public AudioClip snailDeathTwo;
    public AudioClip snailDeathThree;
    public AudioClip LevelComplete;
    public AudioClip GameComplete;
    public AudioClip Munching;
    public AudioClip MunchWrong;
    public AudioClip PlayerJoin;
    public AudioClip SaltShaker;
    public AudioClip CrowCaw;
    public AudioClip CrowAlert;
    public AudioClip CrowAttack;
    public AudioClip SnailHurt;
    public static AudioManager instance = null;                  


    void Awake()
    {
        //Check if there is already an instance of SoundManager
        if (instance == null)
            //if not, set it to this.
            instance = this;
        //If instance already exists:
        else if (instance != this)
            //Destroy this, this enforces our singleton pattern so there can only be one instance of SoundManager.
            Destroy(gameObject);

        //Set SoundManager to DontDestroyOnLoad so that it won't be destroyed when reloading our scene.
        DontDestroyOnLoad(gameObject);
    }


    //Used to play single sound clips.
    public void PlayRaceBgm()
    {
        audios.clip = snailracebgm;
        //Play the clip.
        audios.Play();
    }
    public void PlayStartBgm()
    {
        audios.clip = startbgm;
        //Play the clip.
        audios.Play();
    }
    public void PlayGobblerBgm()
    {
        audios.clip = gobblerbgm;
        //Play the clip.
        audios.Play();
    }
    public void PlaySaltBgm()
    {
        audios.clip = passthesaltbgm;
        //Play the clip.
        audios.Play();
    }
    public void PlayBirbBgm()
    {
        audios.clip = dodgethecrowbgm;
        //Play the clip.
        audios.Play();
    }

    public void PlayRaceStart()
    {
        audios.PlayOneShot(snailraceStart);
    }
    public void PlayRaceWalkOne()
    {
        audios.PlayOneShot(snailraceWalkone);
    }
    public void PlayRaceWalkTwo()
    {
        audios.PlayOneShot(snailraceWalktwo);
    }
    public void PlayRaceWalkThree()
    {
        audios.PlayOneShot(snailraceWalkthree);
    }
    public void PlayDeathOne()
    {
        audios.PlayOneShot(snailDeathOne);
    }
    public void PlayDeathTwo()
    {
        audios.PlayOneShot(snailDeathTwo);
    }
    public void PlayDeathThree()
    {
        audios.PlayOneShot(snailDeathThree);
    }
    public void PlayLevelComplete()
    {
        audios.PlayOneShot(LevelComplete);
    }
    public void PlayGameComplete()
    {
        audios.PlayOneShot(GameComplete);
    }
    public void PlayEating()
    {
        audios.PlayOneShot(Munching);
    }
    public void PlayPlayerJoin()
    {
        audios.PlayOneShot(PlayerJoin);
    }
    public void PlaySaltShaker()
    {
        audios.PlayOneShot(SaltShaker);
    }
    public void PlayCrowCaw()
    {
        audios.PlayOneShot(CrowCaw);
    }
    public void PlayCrowAlert()
    {
        audios.PlayOneShot(CrowAlert);
    }
    public void PlayCrowAttack()
    {
        audios.PlayOneShot(CrowAttack);
    }
    public void PlaySnailHurt()
    {
        audios.PlayOneShot(SnailHurt);
    }
    public void PlayMunchWrong()
    {
        audios.PlayOneShot(MunchWrong);
    }
}
