using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreScreen : MonoBehaviour
{
	[SerializeField] Text[] scoreTexts;
	[SerializeField] Image[] shellSprites;
	[SerializeField] Image[] shellSpriteOverlays;

	[SerializeField] Color[] playerColors;
	[SerializeField] Sprite[] shellTiers;

	public void SetScore (int playerIndex, int score)
	{
		int realPlayerID = playerIndex - 1;

		scoreTexts[realPlayerID].text = score.ToString ();
		//set shell image

		//tier 1 -> score 0
		//tier 2 -> score 1
		//tier 3 -> score 2 (biggest shell)
		//tier 4 -> score 3
		//tier 5 -> score 4

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

		shellSprites[realPlayerID].sprite = sprite;
		shellSprites[realPlayerID].color = color;

		shellSpriteOverlays[realPlayerID].sprite = overlaySprite;

		if (overlaySprite != null)
			shellSpriteOverlays[realPlayerID].color = Color.white;
		else
			shellSpriteOverlays[realPlayerID].color = Color.clear;
	}
}
