using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class WinScreen : MonoBehaviour
{
    GameManager gm;

    [SerializeField]
    Text winnertxt;
    // Start is called before the first frame update
    void Start()
    {
        gm = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();

        if (gm.playeronescore > gm.playertwoscore && gm.playeronescore > gm.playerthreescore && gm.playeronescore > gm.playerfourscore)
        {
            winnertxt.text = "Player One won with score of " + gm.playeronescore;
        }

        if (gm.playertwoscore > gm.playeronescore && gm.playertwoscore > gm.playerthreescore && gm.playertwoscore > gm.playerfourscore)
        {
            winnertxt.text = "Player Two won with score of " + gm.playertwoscore;
        }

        if (gm.playerthreescore > gm.playeronescore && gm.playerthreescore > gm.playertwoscore && gm.playerthreescore > gm.playerfourscore)
        {
            winnertxt.text = "Player Three won with score of " + gm.playerthreescore;
        }

        if (gm.playerfourscore > gm.playeronescore && gm.playerfourscore > gm.playerthreescore && gm.playerfourscore > gm.playertwoscore)
        {
            winnertxt.text = "Player Four won with score of " + gm.playerfourscore;
        }
    }

    public void Restart()
    {
        Destroy(GameObject.FindGameObjectWithTag("GameManager"));
        SceneManager.LoadScene(1);
    }

    public void Exit()
    {
        Application.Quit();
    }

}
