using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController_passthesalt : MonoBehaviour
{
    GameManager gm;
    Rigidbody rb;
    
    public int playerid;
    bomb bm;
    public int speed;
    // Start is called before the first frame update
    void Start()
    {
        gm = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
        rb = GetComponent<Rigidbody>();
        bm = GameObject.FindGameObjectWithTag("bomb").GetComponent<bomb>();
    }

    // Update is called once per frame
    void Update()
    {

        if (bm.target == this.gameObject)
        {
            speed = 14;
        }

        if (playerid == 1)
        {
            float h = Input.GetAxisRaw("Horizontal");
            float v = Input.GetAxisRaw("Vertical");

            Vector3 tempVect = new Vector3(h, 0, v);
            tempVect = tempVect.normalized * speed * Time.deltaTime;
            rb.MovePosition(transform.position + tempVect);
        }

        if (playerid == 2)
        {
            float h = Input.GetAxisRaw("Horizontal2");
            float v = Input.GetAxisRaw("Vertical2");

            Vector3 tempVect = new Vector3(h, 0, v);
            tempVect = tempVect.normalized * speed * Time.deltaTime;
            rb.MovePosition(transform.position + tempVect);
        }
        if (playerid == 3)
        {
            float h = Input.GetAxisRaw("Horizontal3");
            float v = Input.GetAxisRaw("Vertical3");

            Vector3 tempVect = new Vector3(h, 0, v);
            tempVect = tempVect.normalized * speed * Time.deltaTime;
            rb.MovePosition(transform.position + tempVect);
        }
        if (playerid == 4)
        {
            float h = Input.GetAxisRaw("Horizontal4");
            float v = Input.GetAxisRaw("Vertical4");

            Vector3 tempVect = new Vector3(h, 0, v);
            tempVect = tempVect.normalized * speed * Time.deltaTime;
            rb.MovePosition(transform.position + tempVect);
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (bm.target == this.gameObject && bm.delay <= 0) {
            if (collision.gameObject.tag == "Player")
            {
                bm.target = collision.gameObject;
                bm.delay = 1;
            }
        }
    }
}
