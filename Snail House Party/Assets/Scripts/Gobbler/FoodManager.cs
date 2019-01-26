using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Gobbler
{
	public enum InputRow
	{
		Left,
		Center,
		Right
	}

	public class FoodManager : MonoBehaviour
	{
		[SerializeField] int foodSequenceLength = 50;
		[SerializeField] int differentFoods = 3;
		[SerializeField] float stunDuration = 0.3f;

		int[] foodSequence;

		int[] playerProgress = new int[4] { 0, 0, 0, 0 };

		bool[] playerStunned = new bool[4] { false, false, false, false };

		Coroutine[] playerStunTimers = new Coroutine[4] { null, null, null, null };

		// Start is called before the first frame update
		void Awake ()
		{
			GenerateFoodSequence ();
		}

		// Update is called once per frame
		void Update ()
		{
			DetectInputs ();
		}

		void GenerateFoodSequence ()
		{
			Random.InitState ((int)System.DateTime.Now.ToBinary ());

			foodSequence = new int[foodSequenceLength];

			for (int i = 0; i < foodSequenceLength; i++)
			{
				foodSequence[i] = Random.Range (0, differentFoods);
			}
		}

		void GenerateFoodObjects ()
		{
		
		}

		void DetectInputs ()
		{
			//check horizontal and vertical axes
			for (int i = 0; i < 4; i++)
			{
				string hAxis = "Horizontal";
				string vAxis = "Vertical";

				string hCheckedAxis = hAxis;
				string vCheckedAxis = vAxis;

				if (i != 0)
				{
					hCheckedAxis += i.ToString ();
					vCheckedAxis += i.ToString ();
				}

				float hAxisValue = Input.GetAxisRaw (hCheckedAxis);
				float vAxisValue = Input.GetAxisRaw (vCheckedAxis);

				if (hAxisValue != 0)
				{
					//horizontal axis is -1 or 1
					if (hAxisValue > 0)
					{
						//left row
						TryEatFood (InputRow.Left, i);
					}
					else
					{
						//right row
						TryEatFood (InputRow.Right, i);
					}
				}

				if (vAxisValue != 0)
				{
					//vertical axis is -1 or 1
					TryEatFood (InputRow.Center, i);
				}
			}
		}

		int GetInputValue (InputRow inputRow)
		{
			switch (inputRow)
			{
				case InputRow.Left:
					return 0;
				case InputRow.Center:
					return 1;
				case InputRow.Right:
					return 2;
				default:
					return -1;
			}
		}

		void TryEatFood (InputRow inputRow, int playerIndex)
		{
			bool isStunned = playerStunned[playerIndex];

			//unable to consume food while stunned
			if (isStunned)
				return;

			int playerProg = playerProgress[playerIndex];

			int expectedValue = foodSequence[playerProg];

			int inputValue = GetInputValue (inputRow);

			if (inputValue == expectedValue)
			{
				//correct value given
				playerProgress[playerIndex]++;

				//play eating animation
			}
			else
			{
				//incorrect value given

				//stun player
				playerStunned[playerIndex] = true;
				Coroutine stunTimer = playerStunTimers[playerIndex];

				if (stunTimer != null)
					StopCoroutine (stunTimer);

				stunTimer = StartCoroutine (UnstunPlayer (playerIndex));

				//play stun animation
			}
		}

		IEnumerator UnstunPlayer (int playerIndex)
		{
			yield return new WaitForSeconds (stunDuration);
			playerStunned[playerIndex] = false;
			playerStunTimers[playerIndex] = null;

			//stop stun animation
			
		}
	}
}