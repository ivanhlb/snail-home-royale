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
    public Image playeroneimg;
    public Image playertwoimg;
    public Image playerthreeimg;
    public Image playerfourimg;
    public Image playeronebutton;
    public Image playertwobutton;
    public Image playerthreebutton;
    public Image playerfourbutton;


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
            playeroneimg.enabled = true;
            playeronebutton.enabled = false;
        }
        else
        {
            playeroneimg.enabled = false;
            playeronebutton.enabled = true;
        }

        if (gm.playertwo)
        {
            playertwoimg.enabled = true;
            playertwobutton.enabled = false;
        }
        else
        {
            playertwoimg.enabled = false;
            playertwobutton.enabled = true;
        }

        if (gm.playerthree)
        {
            playerthreeimg.enabled = true;
            playerthreebutton.enabled = false;
        }
        else
        {
            playerthreeimg.enabled = false;
            playerthreebutton.enabled = true;
        }

        if (gm.playerfour)
        {
            playerfourimg.enabled = true;
            playerfourbutton.enabled = false;
        }
        else
        {
            playerfourimg.enabled = false;
            playerfourbutton.enabled = true;
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

        if (gm.playerone && gm.playertwo || gm.playerone && gm.playerthree || gm.playerone && gm.playerfour || gm.playertwo && gm.playerthree || gm.playertwo && gm.playerfour || gm.playerthree && gm.playerfour || gm.playerone && gm.playertwo && gm.playerthree && gm.playerfour)
        {
            if (Input.GetKeyUp(KeyCode.Joystick1Button9) || Input.GetKeyUp(KeyCode.Joystick2Button9) || Input.GetKeyUp(KeyCode.Joystick3Button9) || Input.GetKeyUp(KeyCode.Joystick4Button9))
            {
                SceneManager.LoadScene(gm.gameone);
            }
        }
    }
}
