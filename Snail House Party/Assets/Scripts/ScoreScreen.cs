using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreScreen : MonoBehaviour
{
	[SerializeField] Text[] scoreTexts;
	[SerializeField] Image[] shellSprites;

	public void SetScore (int playerIndex, int score)
	{
		scoreTexts[playerIndex - 1].text = score.ToString ();
		//set shell image
	}
}
