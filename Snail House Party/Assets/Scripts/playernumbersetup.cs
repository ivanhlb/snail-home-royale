using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class playernumbersetup : MonoBehaviour
{
    GameManager gm;
    
    public Image playerone;
    public Image playertwo;
    public Image playerthree;
    public Image playerfour;


    // Start is called before the first frame update
    void Start()
    {
        gm = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (gm.playerone)
        {
            playerone.color = Color.white;
        }
        else
        {
            playerone.color = Color.red;
        }

        if (gm.playertwo)
        {
            playertwo.color = Color.white;
        }
        else
        {
            playertwo.color = Color.red;
        }

        if (gm.playerthree)
        {
            playerthree.color = Color.white;
        }
        else
        {
            playerthree.color = Color.red;
        }

        if (gm.playerfour)
        {
            playerfour.color = Color.white;
        }
        else
        {
            playerfour.color = Color.red;
        }


        if (Input.GetKeyUp(KeyCode.Joystick1Button1))
        {
            gm.playerone = !gm.playerone;
        }

        if (Input.GetKeyUp(KeyCode.Joystick2Button1))
        {
            gm.playertwo = !gm.playertwo;
        }

        if (Input.GetKeyUp(KeyCode.Joystick3Button1))
        {
            gm.playerthree = !gm.playerthree;
        }

        if (Input.GetKeyUp(KeyCode.Joystick4Button1))
        {
            gm.playerfour = !gm.playerfour;
        }

        if (gm.playerone && gm.playertwo || gm.playerone && gm.playerthree || gm.playerone && gm.playerfour || gm.playertwo && gm.playerthree || gm.playertwo && gm.playerfour || gm.playerthree && gm.playerfour || gm.playerone && gm.playertwo && gm.playerthree && gm.playerfour) {
            if (Input.GetKeyUp(KeyCode.Joystick1Button9) || Input.GetKeyUp(KeyCode.Joystick2Button9) || Input.GetKeyUp(KeyCode.Joystick3Button9) || Input.GetKeyUp(KeyCode.Joystick4Button9))
            {
                SceneManager.LoadScene(2);
            }
        }
    }
}
