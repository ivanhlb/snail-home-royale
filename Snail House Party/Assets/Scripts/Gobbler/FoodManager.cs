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

		[SerializeField] int[] foodSequence;

		[SerializeField] int[] playerProgress = new int[4] { 0, 0, 0, 0 };

		bool[] playerStunned = new bool[4] { false, false, false, false };

		Coroutine[] playerStunTimers = new Coroutine[4] { null, null, null, null };

		[SerializeField] PlayerController playerControllerPrefab;
		PlayerController[] playerControllers = new PlayerController[4];

		[SerializeField] Color[] playerColors;

		[SerializeField] float playerVerticalOffset = -0.3f;

		[SerializeField] GameObject helpScreen;
		bool ready = false;

		bool p1Ready = false;
		bool p2Ready = false;
		bool p3Ready = false;
		bool p4Ready = false;

		float p1HorPrev;
		float p1VertPrev;

		float p2HorPrev;
		float p2VertPrev;

		float p3HorPrev;
		float p3VertPrev;

		float p4HorPrev;
		float p4VertPrev;

		bool gameWon = false;

		// Start is called before the first frame update
		void Awake ()
		{
			gm = GameObject.FindGameObjectWithTag ("GameManager").GetComponent<GameManager> ();
			GenerateFoodSequence ();
		}

		// Update is called once per frame
		void Update ()
		{
			if (gameWon)
				return;

			if (!ready)
			{
				SetReady ();
				CheckReady ();
			}
			else
			{
				DetectInputs ();
				MoveFood ();
			}
		}

		void Initialise ()
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

		void SetReady ()
		{
			if (gm.playerone)
			{
				if (Input.GetKeyDown (KeyCode.Joystick1Button1))
					p1Ready = true;
			}

			if (gm.playertwo)
			{
				if (Input.GetKeyDown (KeyCode.Joystick2Button1))
					p2Ready = true;
			}

			if (gm.playerthree)
			{
				if (Input.GetKeyDown (KeyCode.Joystick3Button1))
					p3Ready = true;
			}

			if (gm.playerfour)
			{
				if (Input.GetKeyDown (KeyCode.Joystick4Button1))
					p4Ready = true;
			}

		}

		void CheckReady ()
		{
			int reqCount = 0;
			int readyCount = 0;
			if (gm.playerone)
			{
				reqCount++;
				if (p1Ready)
					readyCount++;
			}

			if (gm.playertwo)
			{
				reqCount++;
				if (p2Ready)
					readyCount++;
			}

			if (gm.playerthree)
			{
				reqCount++;
				if (p3Ready)
					readyCount++;
			}

			if (gm.playerfour)
			{
				reqCount++;
				if (p4Ready)
					readyCount++;
			}

			if (readyCount >= reqCount)
			{
				ready = true;
				helpScreen.SetActive (false);

				CreatePlayers ();
				Initialise ();
			}
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

		void CreatePlayers ()
		{
			if (gm.playerone)
				playerControllers[0] = Instantiate (playerControllerPrefab);

			if (gm.playertwo)
				playerControllers[1] = Instantiate (playerControllerPrefab);

			if (gm.playerthree)
				playerControllers[2] = Instantiate (playerControllerPrefab);

			if (gm.playerfour)
				playerControllers[3] = Instantiate (playerControllerPrefab);

			//position players
			for (int i = 0; i < 4; i++)
			{
				if (playerControllers[i] == null)
					continue;

				Vector3 playerPos = playerLanePositions[i].transform.position;
				playerPos.y += playerVerticalOffset;
				playerControllers[i].transform.position = playerPos;

				playerControllers[i].SetShellColour (playerColors[i]);
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

				float prevHorInput = 0;
				float prevVertInput = 0;

				switch (i)
				{
					case 0:
						prevHorInput = p1HorPrev;
						prevVertInput = p1VertPrev;
						break;
					case 1:
						prevHorInput = p2HorPrev;
						prevVertInput = p2VertPrev;
						break;
					case 2:
						prevHorInput = p3HorPrev;
						prevVertInput = p3VertPrev;
						break;
					case 3:
						prevHorInput = p4HorPrev;
						prevVertInput = p4VertPrev;
						break;
				}

				if (hAxisValue == 0 && prevHorInput != 0)
				{
					//horizontal axis is -1 or 1
					if (prevHorInput > 0)
					{
						//left row
						TryEatFood (InputRow.Right, i);
					}
					else
					{
						//right row
						TryEatFood (InputRow.Left, i);
					}
				}

				if (vAxisValue == 0 && prevVertInput != 0)
				{
					//vertical axis is -1 or 1
					TryEatFood (InputRow.Center, i);
				}


				switch (i)
				{
					case 0:
						p1HorPrev = hAxisValue;
						p1VertPrev = vAxisValue;
						break;
					case 1:
						p2HorPrev = hAxisValue;
						p2VertPrev = vAxisValue;
						break;
					case 2:
						p3HorPrev = hAxisValue;
						p3VertPrev = vAxisValue;
						break;
					case 3:
						p4HorPrev = hAxisValue;
						p4VertPrev = vAxisValue;
						break;
				}
			}

			//p1
			//p1 square (left)
			if (Input.GetKeyDown (KeyCode.Joystick1Button0))
			{
				TryEatFood (InputRow.Left, 0);
			}

			//p1 cross and triangle (center)
			if (Input.GetKeyDown (KeyCode.Joystick1Button1) || Input.GetKeyDown (KeyCode.Joystick1Button3))
			{
				TryEatFood (InputRow.Center, 0);
			}

			//p1 circle (right)
			if (Input.GetKeyDown (KeyCode.Joystick1Button2))
			{
				TryEatFood (InputRow.Right, 0);
			}



			//p2
			//p2 square (left)
			if (Input.GetKeyDown (KeyCode.Joystick2Button0))
			{
				TryEatFood (InputRow.Left, 1);
			}

			//p2 cross and triangle (center)
			if (Input.GetKeyDown (KeyCode.Joystick2Button1) || Input.GetKeyDown (KeyCode.Joystick2Button3))
			{
				TryEatFood (InputRow.Center, 1);
			}

			//p2 circle (right)
			if (Input.GetKeyDown (KeyCode.Joystick2Button2))
			{
				TryEatFood (InputRow.Right, 1);
			}



			//p3
			//p3 square (left)
			if (Input.GetKeyDown (KeyCode.Joystick3Button0))
			{
				TryEatFood (InputRow.Left, 2);
			}

			//p3 cross and triangle (center)
			if (Input.GetKeyDown (KeyCode.Joystick3Button1) || Input.GetKeyDown (KeyCode.Joystick3Button3))
			{
				TryEatFood (InputRow.Center, 2);
			}

			//p3 circle (right)
			if (Input.GetKeyDown (KeyCode.Joystick3Button2))
			{
				TryEatFood (InputRow.Right, 2);
			}



			//p4
			//p4 square (left)
			if (Input.GetKeyDown (KeyCode.Joystick4Button0))
			{
				TryEatFood (InputRow.Left, 3);
			}

			//p4 cross and triangle (center)
			if (Input.GetKeyDown (KeyCode.Joystick4Button1) || Input.GetKeyDown (KeyCode.Joystick4Button3))
			{
				TryEatFood (InputRow.Center, 3);
			}

			//p4 circle (right)
			if (Input.GetKeyDown (KeyCode.Joystick4Button2))
			{
				TryEatFood (InputRow.Right, 3);
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

			if (playerProg == foodSequenceLength)
				return; //finished eating

			int expectedValue = foodSequence[playerProg];

			int inputValue = GetInputValue (inputRow);

			if (inputValue == expectedValue)
			{
				//correct value given
				playerProgress[playerIndex]++;

				//play eating animation
				playerControllers[playerIndex].Gobble ();
				Vector3 playerPos = playerLanePositions[playerIndex].transform.position;
				playerPos.y += playerVerticalOffset;

				switch (inputRow)
				{
					case InputRow.Left:
						playerPos.x += -laneOffset;
						break;
					default:
					case InputRow.Center:
						break;
					case InputRow.Right:
						playerPos.x += laneOffset;
						break;
				}

				playerControllers[playerIndex].transform.position = playerPos;

				//remove food from lane
				Transform toRemove = playerLanePositions[playerIndex].GetChild (0);
				toRemove.SetParent (null);
				Destroy (toRemove.gameObject);

				//check for game win
				if (playerLanePositions[playerIndex].childCount == 0)
				{
					gameWon = true;
					switch (playerIndex)
					{
						case 0:
							gm.Addplayeronescore (1);
							break;
						case 1:
							gm.Addplayertwoscore (1);
							break;
						case 2:
							gm.Addplayerthreescore (1);
							break;
						case 3:
							gm.Addplayerfourscore (1);
							break;
					}

					gm.loadnextgame ();
				}
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
				playerControllers[playerIndex].GetStunned ();
			}
		}

		IEnumerator UnstunPlayer (int playerIndex)
		{
			yield return new WaitForSeconds (stunDuration);
			playerStunned[playerIndex] = false;
			playerStunTimers[playerIndex] = null;

			//stop stun animation
			playerControllers[playerIndex].GetUnstunned ();
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
					float newY = Mathf.MoveTowards (lowestFood.transform.localPosition.y, 0, foodMoveSpeed * Time.deltaTime);
					Vector3 localPos = lowestFood.transform.localPosition;
					localPos.y = newY;
					lowestFood.transform.localPosition = localPos;
				}

				//foreach (Transform child in lane)
				for (int j = 0; j < lane.childCount; j++)
				{
					Transform child = lane.GetChild (j);

					if (child == lowestFood)
						continue;

					float newY = Mathf.MoveTowards (child.localPosition.y, (lane.GetChild (j - 1).transform.localPosition.y + rowHeightOffset), foodMoveSpeed * Time.deltaTime);
					Vector3 localPos = child.localPosition;
					localPos.y = newY;
					child.transform.localPosition = localPos;
				}
			}
		}
	}
}