using UnityEngine;
using System;
/// <summary>
/// snail controller for dodge the crow minigame.
/// </summary>
public enum PlayerIndex
{
    PlayerOne = 1,
    PlayerTwo = 2,
    PlayerThree = 3,
    PlayerFour = 4
}
[RequireComponent(typeof(SpriteRenderer))]
public class DodgeSnail : MonoBehaviour
{
    private KeyCode personalButton;
    private Vector3 newPos;
    private SpriteRenderer sp;

    public PlayerIndex playerIndex { get; private set; }
    public bool ready { get; private set; }

    private void Awake()
    {
        sp = GetComponent<SpriteRenderer>();    
    }
    public void Init(PlayerIndex index)
    {
        playerIndex = index;
        switch (playerIndex)
        {
            case PlayerIndex.PlayerOne:
                personalButton = KeyCode.Joystick1Button1;
                break;
            case PlayerIndex.PlayerTwo:
                personalButton = KeyCode.Joystick2Button1;
                break;
            case PlayerIndex.PlayerThree:
                personalButton = KeyCode.Joystick3Button1;
                break;
            case PlayerIndex.PlayerFour:
                personalButton = KeyCode.Joystick4Button1;
                break;
            default:
                break;
        }
        sp.enabled = true;
    }
    private void Update()
    {
        if (Input.GetKeyUp(personalButton))
        {
            if (DodgeTheCrowController.instance.inInstructions)
            {
                ready = true;
                DodgeTheCrowController.instance.OnReady(playerIndex);
            }
            else
            {
                //move
                newPos = transform.position;
                newPos.x += 0.2f;
                transform.position = newPos;
            }
        }
        
    }
}
