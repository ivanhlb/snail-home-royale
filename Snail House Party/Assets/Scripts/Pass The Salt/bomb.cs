using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class bomb : MonoBehaviour
{
    /*[SerializeField]
    Text timer;*/
    [SerializeField]
    GameObject playercontroller;
    PlayerSpawner_passthesalt controller;
    GameManager gm;

    public GameObject target;
    public Double timetokill;
    float saltrotatetime;
    public Double delay = 1;
    public float speed = 1.0f;
    bool gameEnd = false;
    public GameObject blowup;
    float delaytimer = 3;
    // Start is called before the first frame update
    void Start()
    {
       controller = playercontroller.GetComponent<PlayerSpawner_passthesalt>();
       gm = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {

        delay = delay - Time.deltaTime;

        if (timetokill <= 0)
        {
            this.transform.rotation = Quaternion.Euler(0, 0, 0);
            if (target != null)
            {
                controller.playerplaying.Remove(target);
                Instantiate(blowup, target.transform.position, Quaternion.identity);
                AudioManager.instance.PlayDeathThree();
                Destroy(target);
            }
            int randomtarget = UnityEngine.Random.Range(0, controller.playerplaying.Count - 1);
            target = controller.playerplaying[randomtarget];
            timetokill = UnityEngine.Random.Range(5,9);
            saltrotatetime = (float)timetokill;


        }

        if (target != null)
        {
            float step = speed * Time.deltaTime;
            this.transform.position = Vector3.MoveTowards(this.transform.position, target.transform.position, step);
        }

        if (controller.playerplaying.Count > 1)
        {
            //timer.text = Math.Round(timetokill, 0).ToString();
            this.transform.Rotate(Vector3.forward * Time.deltaTime * 180 / saltrotatetime);
            timetokill = timetokill - Time.deltaTime;
        }
        else
        {
            
            delaytimer -= Time.deltaTime;
            if (delaytimer <= 0)
            {
                GameEnd();
            }
        }

        void GameEnd()
        {
            if (target.GetComponent<PlayerController1>().playerid == 1 && gameEnd == false)
            {
                gm.Addplayeronescore(1);
                gm.loadnextgame();
                gameEnd = true;
            }
            if (target.GetComponent<PlayerController1>().playerid == 2 && gameEnd == false)
            {
                gm.Addplayertwoscore(1);
                gm.loadnextgame();
                gameEnd = true;
            }
            if (target.GetComponent<PlayerController1>().playerid == 3 && gameEnd == false)
            {
                gm.Addplayerthreescore(1);
                gm.loadnextgame();
                gameEnd = true;
            }
            if (target.GetComponent<PlayerController1>().playerid == 4 && gameEnd == false)
            {
                gm.Addplayerfourscore(1);
                gm.loadnextgame();
                gameEnd = true;
            }


        }

    }
}
