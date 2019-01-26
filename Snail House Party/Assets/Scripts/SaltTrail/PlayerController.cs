using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller : MonoBehaviour
{
    public float speed;
    public int playerid;
    private Rigidbody2D rb2d;

    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (playerid == 1)
        {
            float moveHorizontal = Input.GetAxisRaw("Horizontal");
            float moveVertical = Input.GetAxisRaw("Vertical");

            Vector3 movement = new Vector3(moveHorizontal, moveVertical, 0);
            rb2d.MovePosition(new Vector2((transform.position.x + movement.x * speed * Time.fixedDeltaTime),
                                (transform.position.y + movement.y * speed * Time.fixedDeltaTime)));
        }

        if (playerid == 2)
        {
            float moveHorizontal = Input.GetAxisRaw("Horizontal2");
            float moveVertical = Input.GetAxisRaw("Vertical2");

            Vector3 movement = new Vector3(moveHorizontal, moveVertical, 0);
            rb2d.MovePosition(new Vector2((transform.position.x + movement.x * speed * Time.fixedDeltaTime),
                                (transform.position.y + movement.y * speed * Time.fixedDeltaTime)));
        }

        if (playerid == 3)
        {
            float moveHorizontal = Input.GetAxisRaw("Horizontal3");
            float moveVertical = Input.GetAxisRaw("Vertical3");

            Vector3 movement = new Vector3(moveHorizontal, moveVertical, 0);
            rb2d.MovePosition(new Vector2((transform.position.x + movement.x * speed * Time.fixedDeltaTime),
                                (transform.position.y + movement.y * speed * Time.fixedDeltaTime)));
        }

        if (playerid == 4)
        {
            float moveHorizontal = Input.GetAxisRaw("Horizontal4");
            float moveVertical = Input.GetAxisRaw("Vertical4");

            Vector3 movement = new Vector3(moveHorizontal, moveVertical, 0);
            rb2d.MovePosition(new Vector2((transform.position.x + movement.x * speed * Time.fixedDeltaTime),
                                (transform.position.y + movement.y * speed * Time.fixedDeltaTime)));
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        
    }
}
