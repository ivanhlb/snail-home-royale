using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Collections.Generic;

public class PlayerSpawner_passthesalt : MonoBehaviour
{
    GameManager gm;
    [SerializeField]
    GameObject playeroneprefab;
    [SerializeField]
    GameObject playertwoprefab;
    [SerializeField]
    GameObject playerthreeprefab;
    [SerializeField]
    GameObject playerfourprefab;
    public List<GameObject> playerplaying;

    [SerializeField] GameObject helpScreen;
    [SerializeField] GameObject bomb;
    bool ready = false;

    bool p1Ready = false;
    bool p2Ready = false;
    bool p3Ready = false;
    bool p4Ready = false;
    // Start is called before the first frame update
    void Start()
    {


        gm = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
        bomb.SetActive(false);
        AudioManager.instance.PlaySaltBgm();
        
    }

    void SetReady()
    {
        if (gm.playerone)
        {
            if (Input.GetKeyDown(KeyCode.Joystick1Button1))
                p1Ready = true;
        }

        if (gm.playertwo)
        {
            if (Input.GetKeyDown(KeyCode.Joystick2Button1))
                p2Ready = true;
        }

        if (gm.playerthree)
        {
            if (Input.GetKeyDown(KeyCode.Joystick3Button1))
                p3Ready = true;
        }

        if (gm.playerfour)
        {
            if (Input.GetKeyDown(KeyCode.Joystick4Button1))
                p4Ready = true;
        }

    }

    void CheckReady()
    {
        int reqCount = 0;
        int readyCount = 0;
        if (gm.playerone)
        {
            reqCount++;
            if (p1Ready)
                readyCount++;
        }

        if (gm.playertwo)
        {
            reqCount++;
            if (p2Ready)
                readyCount++;
        }

        if (gm.playerthree)
        {
            reqCount++;
            if (p3Ready)
                readyCount++;
        }

        if (gm.playerfour)
        {
            reqCount++;
            if (p4Ready)
                readyCount++;
        }

        if (readyCount >= reqCount)
        {
            ready = true;
            helpScreen.SetActive(false);

            Initialise();
        }
    }
        void Initialise()
        {
            if (gm.playerone)
            {
                GameObject playerone = Instantiate(playeroneprefab, playeroneprefab.transform.position, Quaternion.identity);
                playerplaying.Add(playerone);
            }
            if (gm.playertwo)
            {
                GameObject playertwo = Instantiate(playertwoprefab, playertwoprefab.transform.position, Quaternion.identity);
                playerplaying.Add(playertwo);
            }
            if (gm.playerthree)
            {
                GameObject playerthree = Instantiate(playerthreeprefab, playerthreeprefab.transform.position, Quaternion.identity);
                playerplaying.Add(playerthree);
            }
            if (gm.playerfour)
            {
                GameObject playerfour = Instantiate(playerfourprefab, playerfourprefab.transform.position, Quaternion.identity);
                playerplaying.Add(playerfour);
            }

        bomb.SetActive(true);
    }

        // Update is called once per frame
        void Update()
    {
        if (!ready)
        {
            SetReady();
            CheckReady();
        }

    }
}
