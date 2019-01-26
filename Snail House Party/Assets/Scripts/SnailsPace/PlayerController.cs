using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SnailPace
{

    public class PlayerController : MonoBehaviour
    {
        int buttonMash = 0, winCounter = 100, comboMeter = 0, idle_delay = 10, idle_counter = 0;
        string prevButton, joystick;
        float pace = 0.1f, boost = 0.5f;
        public int playerid;
        bool isWalking = false;
        [SerializeField] private Animator animator;
        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {
            idle_counter--;
            if (idle_counter == 0)
            {
                animator.CrossFade("snail_idle", 0.2f);
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
                        buttonMash++;
                        prevButton = "s";
                        transform.Translate(Vector3.right * pace);
                        animator.CrossFade("snail_walk", 0.2f);
                        idle_counter = idle_delay;
                    }
                    if (Input.GetKeyDown(KeyCode.Joystick1Button1))
                    {
                        if (prevButton == null || prevButton == "s")
                        {
                            comboMeter++;
                        }
                        buttonMash++;
                        prevButton = "x";
                        transform.Translate(Vector3.right * pace);
                        animator.CrossFade("snail_walk", 0.2f);
                        idle_counter = idle_delay;
                    }
                    if (Input.GetKeyDown(KeyCode.Joystick1Button2))
                    {
                        if (prevButton == null || prevButton == "x")
                        {
                            comboMeter++;
                        }
                        buttonMash++;
                        prevButton = "c";
                        transform.Translate(Vector3.right * pace);
                        animator.CrossFade("snail_walk", 0.2f);
                        idle_counter = idle_delay;
                    }
                    if (Input.GetKeyDown(KeyCode.Joystick1Button3))
                    {
                        if (prevButton == null || prevButton == "c")
                        {
                            comboMeter++;
                        }
                        buttonMash++;
                        prevButton = "t";
                        transform.Translate(Vector3.right * pace);
                        animator.CrossFade("snail_walk", 0.2f);
                        idle_counter = idle_delay;
                    }
                    break;
                case 2:
                    if (Input.GetKeyDown(KeyCode.Joystick2Button0))
                    {
                        if (prevButton == null || prevButton == "t")
                        {
                            comboMeter++;
                        }
                        buttonMash++;
                        prevButton = "s";
                        transform.Translate(Vector3.right * pace);
                        animator.CrossFade("snail_walk", 0.2f);
                        idle_counter = idle_delay;
                    }
                    if (Input.GetKeyDown(KeyCode.Joystick2Button1))
                    {
                        if (prevButton == null || prevButton == "s")
                        {
                            comboMeter++;
                        }
                        buttonMash++;
                        prevButton = "x";
                        transform.Translate(Vector3.right * pace);
                        animator.CrossFade("snail_walk", 0.2f);
                        idle_counter = idle_delay;
                    }
                    if (Input.GetKeyDown(KeyCode.Joystick2Button2))
                    {
                        if (prevButton == null || prevButton == "x")
                        {
                            comboMeter++;
                        }
                        buttonMash++;
                        prevButton = "c";
                        transform.Translate(Vector3.right * pace);
                        animator.CrossFade("snail_walk", 0.2f);
                        idle_counter = idle_delay;
                    }
                    if (Input.GetKeyDown(KeyCode.Joystick2Button3))
                    {
                        if (prevButton == null || prevButton == "c")
                        {
                            comboMeter++;
                        }
                        buttonMash++;
                        prevButton = "t";
                        transform.Translate(Vector3.right * pace);
                        animator.CrossFade("snail_walk", 0.2f);
                        idle_counter = idle_delay;
                    }
                    break;
                case 3:
                    if (Input.GetKeyDown(KeyCode.Joystick3Button0))
                    {
                        if (prevButton == null || prevButton == "s")
                        {
                            comboMeter++;
                        }
                        buttonMash++;
                        prevButton = "x";
                        transform.Translate(Vector3.right * pace);
                        animator.CrossFade("snail_walk", 0.2f);
                        idle_counter = idle_delay;
                    }
                    if (Input.GetKeyDown(KeyCode.Joystick3Button1))
                    {
                        if (prevButton == null || prevButton == "t")
                        {
                            comboMeter++;
                        }
                        buttonMash++;
                        prevButton = "s";
                        transform.Translate(Vector3.right * pace);
                        animator.CrossFade("snail_walk", 0.2f);
                        idle_counter = idle_delay;
                    }
                    if (Input.GetKeyDown(KeyCode.Joystick3Button2))
                    {
                        if (prevButton == null || prevButton == "x")
                        {
                            comboMeter++;
                        }
                        buttonMash++;
                        prevButton = "c";
                        transform.Translate(Vector3.right * pace);
                        animator.CrossFade("snail_walk", 0.2f);
                        idle_counter = idle_delay;
                    }
                    if (Input.GetKeyDown(KeyCode.Joystick3Button3))
                    {
                        if (prevButton == null || prevButton == "c")
                        {
                            comboMeter++;
                        }
                        buttonMash++;
                        prevButton = "t";
                        transform.Translate(Vector3.right * pace);
                        animator.CrossFade("snail_walk", 0.2f);
                        idle_counter = idle_delay;
                    }
                    break;
                case 4:
                    if (Input.GetKeyDown(KeyCode.Joystick4Button0))
                    {
                        if (prevButton == null || prevButton == "t")
                        {
                            comboMeter++;
                        }
                        buttonMash++;
                        prevButton = "s";
                        transform.Translate(Vector3.right * pace);
                        animator.CrossFade("snail_walk", 0.2f);
                        idle_counter = idle_delay;
                    }
                    if (Input.GetKeyDown(KeyCode.Joystick4Button1))
                    {
                        if (prevButton == null || prevButton == "s")
                        {
                            comboMeter++;
                        }
                        buttonMash++;
                        prevButton = "x";
                        transform.Translate(Vector3.right * pace);
                        animator.CrossFade("snail_walk", 0.2f);
                        idle_counter = idle_delay;
                    }
                    if (Input.GetKeyDown(KeyCode.Joystick4Button2))
                    {
                        if (prevButton == null || prevButton == "x")
                        {
                            comboMeter++;
                        }
                        buttonMash++;
                        prevButton = "c";
                        transform.Translate(Vector3.right * pace);
                        animator.CrossFade("snail_walk", 0.2f);
                        idle_counter = idle_delay;
                    }
                    if (Input.GetKeyDown(KeyCode.Joystick4Button3))
                    {
                        if (prevButton == null || prevButton == "c")
                        {
                            comboMeter++;
                        }
                        buttonMash++;
                        prevButton = "t";
                        transform.Translate(Vector3.right * pace);
                        animator.CrossFade("snail_walk", 0.2f);
                        idle_counter = idle_delay;
                    }
                    break;
            }

            //C-C-C-C-Combbbo
            if (comboMeter >= 4)
            {
                buttonMash += 20;
                comboMeter = 0;
            }

            //to move boost forward
            if (buttonMash >= 20)
            {
                transform.Translate(Vector3.right * boost);
                buttonMash = 0;
                winCounter--;
            }

            //to count if player won
            if (winCounter == 0)
            {
                //win function
            }
        }

    }
}