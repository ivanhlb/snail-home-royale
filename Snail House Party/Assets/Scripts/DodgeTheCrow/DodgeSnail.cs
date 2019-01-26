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
    private KeyCode personalButton;
    private Vector3 newPos;
    private int animParamHash;
    private bool isInit = false;
    public bool isMoving { get; private set; }
    public PlayerIndex playerIndex { get; private set; }
    public bool ready { get; private set; }
    
    public void Init(PlayerIndex index)
    {
        AnimatorControllerParameter[] test = animator.parameters;
        animParamHash = System.Array.Find(test, x => { return x.name == "IsMoving"; }).nameHash;
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
        if (Input.GetKeyUp(personalButton) || Input.GetKeyUp(KeyCode.X))
        {
            if (DodgeTheCrowController.instance.inInstructions)
            {
                ready = true;
                DodgeTheCrowController.instance.OnReady(playerIndex);
            }
            else if (DodgeTheCrowController.instance.gameStarted)
            {
                isMoving = true;
                //move
                newPos = transform.position;
                newPos.x += 0.2f;
                transform.position = Vector3.MoveTowards(transform.position, newPos, 0.05f);
                animator.SetBool(animParamHash, true);
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
