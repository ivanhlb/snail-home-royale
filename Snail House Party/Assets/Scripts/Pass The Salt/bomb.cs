﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class bomb : MonoBehaviour
{
    [SerializeField]
    Text timer;
    [SerializeField]
    GameObject playercontroller;
    PlayerSpawner_passthesalt controller;

    public GameObject target;
    public Double timetokill;
    public Double delay = 1;
    public float speed = 1.0f;
    // Start is called before the first frame update
    void Start()
    {
       controller = playercontroller.GetComponent<PlayerSpawner_passthesalt>();
    }

    // Update is called once per frame
    void Update()
    {

        delay = delay - Time.deltaTime;

        if (timetokill <= 0)
        {
            if (target != null)
            {
                controller.playerplaying.Remove(target);
                Destroy(target);
            }
            int randomtarget = UnityEngine.Random.Range(0, controller.playerplaying.Count - 1);
            target = controller.playerplaying[randomtarget];
            timetokill = 50;
        }

        if (target != null)
        {
            float step = speed * Time.deltaTime;
            this.transform.position = Vector3.MoveTowards(this.transform.position, new Vector3 (target.transform.position.x, this.transform.position.y, target.transform.position.z), step);
        }

        if (controller.playerplaying.Count > 1)
        {
            timer.text = Math.Round(timetokill, 0).ToString();
            timetokill = timetokill - Time.deltaTime;
        }

        

    }
}