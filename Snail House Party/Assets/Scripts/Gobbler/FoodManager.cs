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

		[SerializeField] float rowHeightOffset = 2;
		[SerializeField] float laneOffset = 1.5f;
		[SerializeField] Transform[] playerLanePositions;
		[SerializeField] GameObject[] foodPrefabs;

		[SerializeField] float foodMoveSpeed = 1;

		GameManager gm;

		int[] foodSequence;

		int[] playerProgress = new int[4] { 0, 0, 0, 0 };

		bool[] playerStunned = new bool[4] { false, false, false, false };

		Coroutine[] playerStunTimers = new Coroutine[4] { null, null, null, null };

		// Start is called before the first frame update
		void Awake ()
		{
			gm = GameObject.FindGameObjectWithTag ("GameManager").GetComponent<GameManager> ();
			GenerateFoodSequence ();
		}

		void Start ()
		{
			if (gm.playerone)
				GenerateFoodObjects (0);
			if (gm.playertwo)
				GenerateFoodObjects (1);
			if (gm.playerthree)
				GenerateFoodObjects (2);
			if (gm.playerfour)
				GenerateFoodObjects (3);
		}

		// Update is called once per frame
		void Update ()
		{
			DetectInputs ();
			//MoveFood ();
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

		void GenerateFoodObjects (int playerIndex)
		{
			Transform lane = playerLanePositions[playerIndex];
			float yOffset = 0;

			for (int i = 0; i < foodSequenceLength; i++)
			{
				int foodIndex = foodSequence[i];
				GameObject foodObject = Instantiate (foodPrefabs[foodIndex], lane);

				foodObject.transform.Translate (Vector3.up * yOffset);

				InputRow inputRow = (InputRow)foodIndex;
				switch (inputRow)
				{
					case InputRow.Left:
						foodObject.transform.Translate (-Vector3.right * laneOffset);
						break;
					case InputRow.Right:
						foodObject.transform.Translate (Vector3.right * laneOffset);
						break;
					case InputRow.Center:
						break;
				}

				yOffset += rowHeightOffset;
			}
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
					hCheckedAxis += (i + 1).ToString ();
					vCheckedAxis += (i + 1).ToString ();
				}

				float hAxisValue = Input.GetAxisRaw (hCheckedAxis);
				float vAxisValue = Input.GetAxisRaw (vCheckedAxis);

				Debug.Log (hCheckedAxis + " " + hAxisValue);
				Debug.Log (vCheckedAxis + " " + vAxisValue);

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

				//remove food from lane
				Destroy (playerLanePositions[playerIndex].GetChild (0).gameObject);
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
				Debug.Log ("stunned");
			}
		}

		IEnumerator UnstunPlayer (int playerIndex)
		{
			yield return new WaitForSeconds (stunDuration);
			playerStunned[playerIndex] = false;
			playerStunTimers[playerIndex] = null;

			//stop stun animation

		}

		void MoveFood ()
		{
			for (int i = 0; i < 4; i++)
			{
				Transform lane = playerLanePositions[i];

				if (lane.childCount == 0)
					continue;

				Transform lowestFood = lane.GetChild (0);

				if (lowestFood.transform.localPosition.y != 0)
				{
					lowestFood.transform.Translate (-Vector3.up * lowestFood.transform.localPosition.y * foodMoveSpeed * Time.deltaTime);
				}

				//foreach (Transform child in lane)
				for (int j = 0; j < lane.childCount; j++)
				{
					Transform child = lane.GetChild (j);

					if (child == lowestFood)
						continue;

					float heightDiff = lane.GetChild (j - 1).transform.localPosition.y + rowHeightOffset;

					if (Mathf.Abs(heightDiff) > 0.05f)
					{
						child.transform.Translate (-Vector3.up * heightDiff * foodMoveSpeed * Time.deltaTime);
					}
				}
			}
		}
	}
}