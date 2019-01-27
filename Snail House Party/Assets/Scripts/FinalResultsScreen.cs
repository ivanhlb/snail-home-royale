using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FinalResultsScreen : MonoBehaviour
{
	[SerializeField] Image shellImage;
	[SerializeField] Image shellImageOverlay;
	
	[SerializeField] Text playerName;

	[SerializeField] Color[] playerColors;
	[SerializeField] Sprite[] shellTiers;

	GameManager gm;

	private void Awake ()
	{
		gm = GameObject.FindGameObjectWithTag ("GameManager").GetComponent<GameManager>();
	}

	private void Start ()
	{
		int playerID;
		int score = GetHighestScore (out playerID);
		ShowWinner (playerID, score);
	}

	int GetHighestScore (out int playerID)
	{
		int highestScore = -1;
		playerID = -1;


		if (gm.playeronescore > highestScore)
		{
			highestScore = gm.playeronescore;
			playerID = 1;
		}
		if (gm.playertwoscore > highestScore)
		{
			highestScore = gm.playertwoscore;
			playerID = 2;
		}
		if (gm.playerthreescore > highestScore)
		{
			highestScore = gm.playerthreescore;
			playerID = 3;
		}
		if (gm.playerfourscore > highestScore)
		{
			highestScore = gm.playerfourscore;
			playerID = 4;
		}

		return highestScore;
	}

	public void ShowWinner (int playerIndex, int score)
	{
		int realPlayerID = playerIndex - 1;

		playerName.text = "Player " + playerIndex.ToString();

		Color color = playerColors[realPlayerID];

		Sprite sprite = shellTiers[score];
		Sprite overlaySprite = null;

		if (score >= 3)
		{
			sprite = shellTiers[2];
			if (score == 4)
				overlaySprite = shellTiers[4];
			if (score == 5)
				overlaySprite = shellTiers[5];
		}

		shellImage.sprite = sprite;
		shellImage.color = color;

		shellImageOverlay.sprite = overlaySprite;

		if (overlaySprite != null)
			shellImageOverlay.color = Color.white;
		else
			shellImageOverlay.color = Color.clear;
	}
}
