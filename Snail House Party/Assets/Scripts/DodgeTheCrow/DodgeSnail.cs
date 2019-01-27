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
    public SpriteRenderer shell { get { return shellRenderer; } }
    [SerializeField]
    private SpriteRenderer shellRenderer;
    public SpriteRenderer deco { get { return decoRenderer; } }
    [SerializeField]
    private SpriteRenderer decoRenderer;
    [HideInInspector]
    public Vector3 startPos;
    private KeyCode personalButton;
    private Vector3 newPos;
    private int animParamHash;
    private bool isInit = false;
    public bool isMoving { get; private set; }
    public PlayerIndex playerIndex { get; private set; }
    public bool ready { get; private set; }

    
    public void Init(PlayerIndex index, int score)
    {
        startPos = transform.position;
        AnimatorControllerParameter[] test = animator.parameters;
        animParamHash = Array.Find(test, x => { return x.name == "IsMoving"; }).nameHash;
        playerIndex = index;
        shellRenderer.sprite = DodgeTheCrowController.instance.shellSprites[score];
        decoRenderer.sprite = null;
        if (score > 4)
        {
            decoRenderer.enabled = true;
            decoRenderer.sprite = DodgeTheCrowController.instance.decoSprites[score - 4];
        }
        switch (playerIndex)
        {
            case PlayerIndex.PlayerOne:
                personalButton = KeyCode.Joystick1Button1;
                shellRenderer.color = Color.red;
                personalButton = KeyCode.X;
                break;
            case PlayerIndex.PlayerTwo:
                personalButton = KeyCode.Joystick2Button1;
                shellRenderer.color = new Color32(154, 5, 161, 255);
                break;
            case PlayerIndex.PlayerThree:
                personalButton = KeyCode.Joystick3Button1;
                shellRenderer.color = new Color32(37, 255, 0, 255);
                break;
            case PlayerIndex.PlayerFour:
                personalButton = KeyCode.Joystick4Button1;
                shellRenderer.color = new Color32(255, 239, 0, 255);
                break;
            default:
                break;
        }
        sp.enabled = true;
        shellRenderer.enabled = true;
        isInit = true;
    }

    private void Update()
    {
        if (!isInit || DodgeTheCrowController.instance.gameWon)
            return;
        if (Input.GetKeyDown(personalButton))
        {
            if (DodgeTheCrowController.instance.inInstructions)
            {
                ready = true;
                DodgeTheCrowController.instance.OnReady(playerIndex);
            }
            else if (DodgeTheCrowController.instance.gameStarted)
            {
                isMoving = true;
                float rng = UnityEngine.Random.value;
                if (rng < 0.33f)
                {
                    AudioManager.instance.PlayRaceWalkOne();

                }
                else if (rng < 0.66f)
                {
                    AudioManager.instance.PlayRaceWalkTwo();

                }
                else
                {
                    AudioManager.instance.PlayRaceWalkThree();
                }

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
