using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

	void HideScoreScreen ()
	{
		Destroy (scoreScreen.gameObject);
	}

	void LoadGame ()
	{
		
	}
}
