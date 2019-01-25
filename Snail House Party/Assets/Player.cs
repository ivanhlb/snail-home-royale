using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    string[] joycontroller;

    // Start is called before the first frame update
    void Start()
    {
        if (Input.GetJoystickNames().Length == 0)
        {
            Debug.Log("no joysticks");
        }

        if (Input.GetJoystickNames().Length > 0)
        {
            joycontroller = Input.GetJoystickNames();
        }
    }

    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < joycontroller.Length; i++)
        {
            if (joycontroller[i] == "Wireless Controller") {
                Debug.Log(i);
            }

        }

        if (Input.GetKeyDown(KeyCode.Joystick1Button1))
        {
                Debug.Log("key press");
        }
        if (Input.GetKeyDown(KeyCode.Joystick2Button1))
        {
            Debug.Log("key2 press");
        }

        

    }
}
