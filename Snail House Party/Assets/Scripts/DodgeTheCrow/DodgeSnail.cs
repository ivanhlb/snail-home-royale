using System;
using UnityEngine;
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
public class DodgeSnail : AnimatedSprite
{
    [HideInInspector]
    public Vector3 startPos;
    private KeyCode personalButton;
    private Vector3 newPos;
    private int animParamHash;
    private bool isInit = false;
    public bool isMoving { get; private set; }
    public PlayerIndex playerIndex { get; private set; }
    public bool ready { get; private set; }

    
    public void Init(PlayerIndex index)
    {
        startPos = transform.position;
        AnimatorControllerParameter[] test = animator.parameters;
        animParamHash = Array.Find(test, x => { return x.name == "IsMoving"; }).nameHash;
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
        isInit = true;
    }

    private void Update()
    {
        if (!isInit)
            return;
        if (Input.GetKeyUp(personalButton))
        {
            if (DodgeTheCrowController.instance.inInstructions)
            {
                ready = true;
                DodgeTheCrowController.instance.OnReady(playerIndex);
            }
            else if (DodgeTheCrowController.instance.gameStarted)
            {
                isMoving = true;
                newPos = transform.position;
                newPos.x += 0.2f;
                transform.position = Vector3.MoveTowards(transform.position, newPos, 0.15f);
                if (transform.position.x >= DodgeTheCrowController.instance.finishingX)
                {
                    DodgeTheCrowController.instance.Win(this);
                }
                animator.SetBool(animParamHash, true);
                if(Crow.instance)
                {
                    Crow.instance.OnSnailMoved(this);
                }
            }
        }
        else
        {
            if (DodgeTheCrowController.instance.gameStarted)
            {
                isMoving = false;
                if(animator.GetBool(animParamHash))
                    animator.SetBool(animParamHash, false);
            }
        }

    }
}
