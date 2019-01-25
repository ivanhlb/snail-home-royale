using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SnailPace {

    public class PlayerController : MonoBehaviour
    {
        int buttonMash = 0;
        string prevButton;
        // Start is called before the first frame update
        void Start()
        {
            
        }

        // Update is called once per frame
        void Update()
        {
            if(Input.GetKeyDown(KeyCode.A)){
                buttonMash++;

            }
            if (Input.GetKeyDown(KeyCode.S))
            {
                buttonMash++;
            }
            if (Input.GetKeyDown(KeyCode.D))
            {
                buttonMash++;
            }
            if (Input.GetKeyDown(KeyCode.F))
            {
                buttonMash++;
            }

            if (buttonMash == 20){
                transform.Translate(Vector3.right);
                buttonMash = 0;
            }

        }
    }
}