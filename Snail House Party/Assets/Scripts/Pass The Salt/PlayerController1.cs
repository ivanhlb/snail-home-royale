using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController1 : MonoBehaviour
{
    public float speed;
    public int playerid;
    private Rigidbody2D rb2d;
    GameManager gm;
    bomb bm;
    public GameObject[] shell;
    Animator am;
    

    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        gm = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
        bm = GameObject.FindGameObjectWithTag("bomb").GetComponent<bomb>();
        am = this.GetComponent<Animator>();
        if (playerid == 1)
        {
            if (gm.playeronescore <= 0)
            {
                shell[0].SetActive(true);
            }
            else if (gm.playeronescore == 1)
            {
                shell[1].SetActive(true);
            }
            else if (gm.playeronescore == 2)
            {
                shell[2].SetActive(true);
            }
            else if (gm.playeronescore == 3)
            {
                shell[2].SetActive(true);
                shell[3].SetActive(true);
            }
            else if (gm.playeronescore == 4)
            {
                shell[2].SetActive(true);
                shell[4].SetActive(true);
            }
        }
        if (playerid == 2)
        {
            if (gm.playertwoscore <= 0)
            {
                shell[0].SetActive(true);
            }
            else if (gm.playertwoscore == 1)
            {
                shell[1].SetActive(true);
            }
            else if (gm.playertwoscore == 2)
            {
                shell[2].SetActive(true);
            }
            else if (gm.playertwoscore == 3)
            {
                shell[2].SetActive(true);
                shell[3].SetActive(true);
            }
            else if (gm.playertwoscore == 4)
            {
                shell[2].SetActive(true);
                shell[4].SetActive(true);
            }
        }
        if (playerid == 3)
        {
            if (gm.playerthreescore <= 0)
            {
                shell[0].SetActive(true);
            }
            else if (gm.playerthreescore == 1)
            {
                shell[1].SetActive(true);
            }
            else if (gm.playerthreescore == 2)
            {
                shell[2].SetActive(true);
            }
            else if (gm.playerthreescore == 3)
            {
                shell[2].SetActive(true);
                shell[3].SetActive(true);
            }
            else if (gm.playerthreescore == 4)
            {
                shell[2].SetActive(true);
                shell[4].SetActive(true);
            }
        }
        if (playerid == 4)
        {
            if (gm.playerfourscore <= 0)
            {
                shell[0].SetActive(true);
            }
            else if (gm.playerfourscore == 1)
            {
                shell[1].SetActive(true);
            }
            else if (gm.playerfourscore == 2)
            {
                shell[2].SetActive(true);
            }
            else if (gm.playerfourscore == 3)
            {
                shell[2].SetActive(true);
                shell[3].SetActive(true);
            }
            else if (gm.playerfourscore == 4)
            {
                shell[2].SetActive(true);
                shell[4].SetActive(true);
            }
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (bm.target == this.gameObject)
        {
            speed = 8;
        }

        if (playerid == 1)
        {
            float moveHorizontal = Input.GetAxisRaw("Horizontal");
            float moveVertical = Input.GetAxisRaw("Vertical");

            Vector3 movement = new Vector3(moveHorizontal, moveVertical, 0);
            rb2d.MovePosition(new Vector2((transform.position.x + movement.x * speed * Time.fixedDeltaTime),
                                (transform.position.y + movement.y * speed * Time.fixedDeltaTime)));
            transform.rotation = Quaternion.LookRotation(Vector3.forward, movement);

            if (movement.x > 0 || movement.y > 0 || movement.z > 0)
            {
                am.SetBool("Iswalking", true);
            }
            else
            {
                am.SetBool("Iswalking", false);
            }
        }

        if (playerid == 2)
        {
            float moveHorizontal = Input.GetAxisRaw("Horizontal2");
            float moveVertical = Input.GetAxisRaw("Vertical2");

            Vector3 movement = new Vector3(moveHorizontal, moveVertical, 0);
            rb2d.MovePosition(new Vector2((transform.position.x + movement.x * speed * Time.fixedDeltaTime),
                                (transform.position.y + movement.y * speed * Time.fixedDeltaTime)));
            transform.rotation = Quaternion.LookRotation(Vector3.forward, movement);
            if (movement.x > 0 || movement.y > 0 || movement.z > 0)
            {
                am.SetBool("Iswalking", true);
            }
            else
            {
                am.SetBool("Iswalking", false);
            }
        }

        if (playerid == 3)
        {
            float moveHorizontal = Input.GetAxisRaw("Horizontal3");
            float moveVertical = Input.GetAxisRaw("Vertical3");

            Vector3 movement = new Vector3(moveHorizontal, moveVertical, 0);
            rb2d.MovePosition(new Vector2((transform.position.x + movement.x * speed * Time.fixedDeltaTime),
                                (transform.position.y + movement.y * speed * Time.fixedDeltaTime)));
            transform.rotation = Quaternion.LookRotation(Vector3.forward, movement);
            if (movement.x > 0 || movement.y > 0 || movement.z > 0)
            {
                am.SetBool("Iswalking", true);
            }
            else
            {
                am.SetBool("Iswalking", false);
            }
        }

        if (playerid == 4)
        {
            float moveHorizontal = Input.GetAxisRaw("Horizontal4");
            float moveVertical = Input.GetAxisRaw("Vertical4");

            Vector3 movement = new Vector3(moveHorizontal, moveVertical, 0);
            rb2d.MovePosition(new Vector2((transform.position.x + movement.x * speed * Time.fixedDeltaTime),
                                (transform.position.y + movement.y * speed * Time.fixedDeltaTime)));
            transform.rotation = Quaternion.LookRotation(Vector3.forward, movement);
            if (movement.x > 0 || movement.y > 0 || movement.z > 0)
            {
                am.SetBool("Iswalking", true);
            }
            else
            {
                am.SetBool("Iswalking", false);
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (bm.target == this.gameObject && bm.delay <= 0)
        {
            if (collision.gameObject.tag == "Player")
            {
                bm.target = collision.gameObject;
                bm.delay = 1;
            }
        }
    }
}
