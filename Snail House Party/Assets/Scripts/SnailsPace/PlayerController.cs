using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SnailPace {

    public class PlayerController : MonoBehaviour
    {
        int buttonMash = 0;
        string prevButton, joystick;
        public int playerid;
        // Start is called before the first frame update
        void Start()
        {
            
        }

        // Update is called once per frame
        void Update()
        {
            switch (playerid)
            {
                case 1:
                    if (Input.GetKeyUp(KeyCode.Joystick1Button0))
                    {
                        buttonMash++;
                    }
                    if (Input.GetKeyUp(KeyCode.Joystick1Button1))
                    {
                        buttonMash++;
                    }
                    if (Input.GetKeyUp(KeyCode.Joystick1Button2))
                    {
                        buttonMash++;
                    }
                    if (Input.GetKeyUp(KeyCode.Joystick1Button3))
                    {
                        buttonMash++;
                    }
                    break;
                case 2:
                    if (Input.GetKeyUp(KeyCode.Joystick2Button0))
                    {
                        buttonMash++;
                    }
                    if (Input.GetKeyUp(KeyCode.Joystick2Button1))
                    {
                        buttonMash++;
                    }
                    if (Input.GetKeyUp(KeyCode.Joystick2Button2))
                    {
                        buttonMash++;
                    }
                    if (Input.GetKeyUp(KeyCode.Joystick2Button3))
                    {
                        buttonMash++;
                    }
                    break;
                case 3:
                    if (Input.GetKeyUp(KeyCode.Joystick3Button0))
                    {
                        buttonMash++;
                    }
                    if (Input.GetKeyUp(KeyCode.Joystick3Button1))
                    {
                        buttonMash++;
                    }
                    if (Input.GetKeyUp(KeyCode.Joystick3Button2))
                    {
                        buttonMash++;
                    }
                    if (Input.GetKeyUp(KeyCode.Joystick3Button3))
                    {
                        buttonMash++;
                    }
                    break;
                case 4:
                    if (Input.GetKeyUp(KeyCode.Joystick4Button0))
                    {
                        buttonMash++;
                    }
                    if (Input.GetKeyUp(KeyCode.Joystick4Button1))
                    {
                        buttonMash++;
                    }
                    if (Input.GetKeyUp(KeyCode.Joystick4Button2))
                    {
                        buttonMash++;
                    }
                    if (Input.GetKeyUp(KeyCode.Joystick4Button3))
                    {
                        buttonMash++;
                    }
                    break;
            }
            
            if (buttonMash >= 20){
                transform.Translate(Vector3.right);
                buttonMash = 0;
            }

        }
    }
}