using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public bool playerone = false;
    public bool playertwo = false;
    public bool playerthree = false;
    public bool playerfour = false;

    public int playeronescore;
    public int playertwoscore;
    public int playerthreescore;
    public int playerfourscore;

    public int gameone;
    int gametwo;
    int gamethree;
    int gamefour;

    int gamecount = 1;

	Coroutine scoreScreenCoroutine;

	[SerializeField] ScoreScreen scoreScreenPrefab;
	ScoreScreen scoreScreen;
    private void Awake()
    {
        GameObject[] objs = GameObject.FindGameObjectsWithTag("GameManager");

        if (objs.Length > 1)
        {
            Destroy(this.gameObject);
        }

        DontDestroyOnLoad(this.gameObject);
    }
    public void Addplayeronescore(int score)
    {
        playeronescore += score;
    }
    public void Addplayertwoscore(int score)
    {
        playertwoscore += score;
    }
    public void Addplayerthreescore(int score)
    {
        playerthreescore += score;
    }
    public void Addplayerfourscore(int score)
    {
        playerfourscore += score;
    }

    public void loadnextgame()
    {
		if (scoreScreenCoroutine != null)
			StopCoroutine (scoreScreenCoroutine);

		scoreScreenCoroutine = StartCoroutine (ScoreScreenCoroutine ());
	}

	IEnumerator ScoreScreenCoroutine ()
	{
		ShowScoreScreen ();
		yield return new WaitForSeconds (3);
		HideScoreScreen ();
        gamecount++;
		LoadGame ();

		scoreScreenCoroutine = null;
	}

	void ShowScoreScreen ()
	{
		scoreScreen = Instantiate (scoreScreenPrefab, Vector3.zero, Quaternion.identity);
		scoreScreen.SetScore (1, playeronescore);
		scoreScreen.SetScore (2, playertwoscore);
		scoreScreen.SetScore (3, playerthreescore);
		scoreScreen.SetScore (4, playerfourscore);
	}

    private void Start()
    {
        gameone = Random.Range(2,6);

        gametwo = Random.Range(2, 6);

        gamethree = Random.Range(2, 6);
        
        gamefour = Random.Range(2, 6);
    }

    private void Update()
    {
        if (gametwo == gameone)
        {
            gametwo = Random.Range(2, 6);
        }

        if (gamethree == gameone || gamethree == gametwo)
        {
            gamethree = Random.Range(2, 6);
        }

        if (gamefour == gameone || gamefour == gametwo || gamefour == gamethree)
        {
            gamefour = Random.Range(2, 6);
        }
    }

    void HideScoreScreen ()
	{
		Destroy (scoreScreen.gameObject);
	}

	void LoadGame ()
	{
        if (gamecount < 5)
        {
            if (gamecount == 2)
            {
                SceneManager.LoadScene(gametwo);
            }
            if (gamecount == 3)
            {
                SceneManager.LoadScene(gamethree);
            }
            if (gamecount == 4)
            {
                SceneManager.LoadScene(gamefour);
            }
        }
        else
        {
            SceneManager.LoadScene(6);
        }
	}
}
