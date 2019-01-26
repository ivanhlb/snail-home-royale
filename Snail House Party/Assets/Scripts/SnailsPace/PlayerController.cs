using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SnailPace
{

    public class PlayerController : MonoBehaviour
    {
        GameManager gm;
        public GameObject startPos, endPos;
        int buttonMash = 0, comboMeter = 0, idle_delay = 10, idle_counter = 0, boost_multiplier = 5;
        string prevButton, joystick;
        float pace = 0.0f, boost = 0.0f, fade = 0.2f;
        public int playerid, winCounter = 100;
        [SerializeField] private Animator animator;
        // Start is called before the first frame update
        void Start()
        {
            gm = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
            float diff = endPos.transform.position.x - startPos.transform.position.x;
            pace = diff / winCounter;
            boost = pace * boost_multiplier;
        }

        // Update is called once per frame
        void Update()
        {
            idle_counter--;
            if (idle_counter == 0)
            {
                animator.CrossFade("snail_idle", fade);
            }

            //to count if player won
            if (winCounter <= 0)
            {

                switch (playerid)
                {
                    case 1:
                        gm.Addplayeronescore(1);
                        break;
                    case 2:
                        gm.Addplayertwoscore(1);
                        break;
                    case 3:
                        gm.Addplayerthreescore(1);
                        break;
                    case 4:
                        gm.Addplayerfourscore(1);
                        break;
                }
                gm.loadnextgame();
                return;
            }

            //button mash calculation
            switch (playerid)
            {
                case 1:
                    if (Input.GetKeyDown(KeyCode.Joystick1Button0))
                    {
                        if (prevButton == null || prevButton == "t")
                        {
                            comboMeter++;
                        }
                        else
                        {
                            comboMeter = 0;
                        }
                        buttonMash++;
                        prevButton = "s";
                        transform.Translate(Vector3.right * pace);
                        animator.CrossFade("snail_walk", fade);
                        idle_counter = idle_delay;
                        winCounter--;
                    }
                    if (Input.GetKeyDown(KeyCode.Joystick1Button1))
                    {
                        if (prevButton == null || prevButton == "s")
                        {
                            comboMeter++;
                        }
                        else
                        {
                            comboMeter = 0;
                        }

                        buttonMash++;
                        prevButton = "x";
                        transform.Translate(Vector3.right * pace);
                        animator.CrossFade("snail_walk", fade);
                        idle_counter = idle_delay;
                        winCounter--;
                    }
                    if (Input.GetKeyDown(KeyCode.Joystick1Button2))
                    {
                        if (prevButton == null || prevButton == "x")
                        {
                            comboMeter++;
                        }
                        else
                        {
                            comboMeter = 0;
                        }
                        buttonMash++;
                        prevButton = "c";
                        transform.Translate(Vector3.right * pace);
                        animator.CrossFade("snail_walk", fade);
                        idle_counter = idle_delay;
                        winCounter--;
                    }
                    if (Input.GetKeyDown(KeyCode.Joystick1Button3))
                    {
                        if (prevButton == null || prevButton == "c")
                        {
                            comboMeter++;
                        }
                        else
                        {
                            comboMeter = 0;
                        }
                        buttonMash++;
                        prevButton = "t";
                        transform.Translate(Vector3.right * pace);
                        animator.CrossFade("snail_walk", fade);
                        idle_counter = idle_delay;
                        winCounter--;
                    }
                    break;
                case 2:
                    if (Input.GetKeyDown(KeyCode.Joystick2Button0))
                    {
                        if (prevButton == null || prevButton == "t")
                        {
                            comboMeter++;
                        }
                        else
                        {
                            comboMeter = 0;
                        }
                        buttonMash++;
                        prevButton = "s";
                        transform.Translate(Vector3.right * pace);
                        animator.CrossFade("snail_walk", fade);
                        idle_counter = idle_delay;
                        winCounter--;
                    }
                    if (Input.GetKeyDown(KeyCode.Joystick2Button1))
                    {
                        if (prevButton == null || prevButton == "s")
                        {
                            comboMeter++;
                        }
                        else
                        {
                            comboMeter = 0;
                        }
                        buttonMash++;
                        prevButton = "x";
                        transform.Translate(Vector3.right * pace);
                        animator.CrossFade("snail_walk", fade);
                        idle_counter = idle_delay;
                        winCounter--;
                    }
                    if (Input.GetKeyDown(KeyCode.Joystick2Button2))
                    {
                        if (prevButton == null || prevButton == "x")
                        {
                            comboMeter++;
                        }
                        else
                        {
                            comboMeter = 0;
                        }
                        buttonMash++;
                        prevButton = "c";
                        transform.Translate(Vector3.right * pace);
                        animator.CrossFade("snail_walk", fade);
                        idle_counter = idle_delay;
                        winCounter--;
                    }
                    if (Input.GetKeyDown(KeyCode.Joystick2Button3))
                    {
                        if (prevButton == null || prevButton == "c")
                        {
                            comboMeter++;
                        }
                        else
                        {
                            comboMeter = 0;
                        }
                        buttonMash++;
                        prevButton = "t";
                        transform.Translate(Vector3.right * pace);
                        animator.CrossFade("snail_walk", fade);
                        idle_counter = idle_delay;
                        winCounter--;
                    }
                    break;
                case 3:
                    if (Input.GetKeyDown(KeyCode.Joystick3Button0))
                    {
                        if (prevButton == null || prevButton == "s")
                        {
                            comboMeter++;
                        }
                        else
                        {
                            comboMeter = 0;
                        }
                        buttonMash++;
                        prevButton = "x";
                        transform.Translate(Vector3.right * pace);
                        animator.CrossFade("snail_walk", fade);
                        idle_counter = idle_delay;
                        winCounter--;
                    }
                    if (Input.GetKeyDown(KeyCode.Joystick3Button1))
                    {
                        if (prevButton == null || prevButton == "t")
                        {
                            comboMeter++;
                        }
                        else
                        {
                            comboMeter = 0;
                        }
                        buttonMash++;
                        prevButton = "s";
                        transform.Translate(Vector3.right * pace);
                        animator.CrossFade("snail_walk", fade);
                        idle_counter = idle_delay;
                        winCounter--;
                    }
                    if (Input.GetKeyDown(KeyCode.Joystick3Button2))
                    {
                        if (prevButton == null || prevButton == "x")
                        {
                            comboMeter++;
                        }
                        else
                        {
                            comboMeter = 0;
                        }
                        buttonMash++;
                        prevButton = "c";
                        transform.Translate(Vector3.right * pace);
                        animator.CrossFade("snail_walk", fade);
                        idle_counter = idle_delay;
                        winCounter--;
                    }
                    if (Input.GetKeyDown(KeyCode.Joystick3Button3))
                    {
                        if (prevButton == null || prevButton == "c")
                        {
                            comboMeter++;
                        }
                        else
                        {
                            comboMeter = 0;
                        }
                        buttonMash++;
                        prevButton = "t";
                        transform.Translate(Vector3.right * pace);
                        animator.CrossFade("snail_walk", fade);
                        idle_counter = idle_delay;
                        winCounter--;
                    }
                    break;
                case 4:
                    if (Input.GetKeyDown(KeyCode.Joystick4Button0))
                    {
                        if (prevButton == null || prevButton == "t")
                        {
                            comboMeter++;
                        }
                        else
                        {
                            comboMeter = 0;
                        }
                        buttonMash++;
                        prevButton = "s";
                        transform.Translate(Vector3.right * pace);
                        animator.CrossFade("snail_walk", fade);
                        idle_counter = idle_delay;
                        winCounter--;
                    }
                    if (Input.GetKeyDown(KeyCode.Joystick4Button1))
                    {
                        if (prevButton == null || prevButton == "s")
                        {
                            comboMeter++;
                        }
                        else
                        {
                            comboMeter = 0;
                        }
                        buttonMash++;
                        prevButton = "x";
                        transform.Translate(Vector3.right * pace);
                        animator.CrossFade("snail_walk", fade);
                        idle_counter = idle_delay;
                        winCounter--;
                    }
                    if (Input.GetKeyDown(KeyCode.Joystick4Button2))
                    {
                        if (prevButton == null || prevButton == "x")
                        {
                            comboMeter++;
                        }
                        else
                        {
                            comboMeter = 0;
                        }
                        buttonMash++;
                        prevButton = "c";
                        transform.Translate(Vector3.right * pace);
                        animator.CrossFade("snail_walk", fade);
                        idle_counter = idle_delay;
                        winCounter--;
                    }
                    if (Input.GetKeyDown(KeyCode.Joystick4Button3))
                    {
                        if (prevButton == null || prevButton == "c")
                        {
                            comboMeter++;
                        }
                        else
                        {
                            comboMeter = 0;
                        }
                        buttonMash++;
                        prevButton = "t";
                        transform.Translate(Vector3.right * pace);
                        animator.CrossFade("snail_walk", fade);
                        idle_counter = idle_delay;
                        winCounter--;
                    }
                    break;
            }



            //C-C-C-C-Combbbo Extra Move Speed
            if (comboMeter >= 4)
            {
                if (winCounter > boost_multiplier)
                {
                    transform.Translate(Vector3.right * boost);
                    winCounter -= boost_multiplier;
                }
                else
                {
                    transform.Translate(endPos.transform.position.x - this.transform.position.x, 0, 0);
                    winCounter = 0;
                }
                comboMeter = 0;

            }

        }

    }
}