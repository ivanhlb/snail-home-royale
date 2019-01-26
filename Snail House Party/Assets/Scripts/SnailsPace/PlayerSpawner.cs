﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SnailPace
{

    public class PlayerSpawner : MonoBehaviour
    {
        GameManager gm;

        public GameObject playeronePrefab;
        public GameObject playertwoPrefab;
        public GameObject playerthreePrefab;
        public GameObject playerfourPrefab;
        public PlayerController playerone;
        public PlayerController playertwo;
        public PlayerController playerthree;
        public PlayerController playerfour;
        public GameObject startPos, endPos;
        // Start is called before the first frame update
        void Start()
        {
            gm = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();

            if (gm.playerone)
            {
                playerone = Instantiate(playeronePrefab, new Vector3(-12, 8.5f,0), Quaternion.identity).GetComponent<PlayerController>();
                //playerone.GetComponent<MeshRenderer>().material.color = Color.red;
                playerone.startPos = startPos;
                playerone.endPos = endPos;
            }

            if (gm.playertwo)
            {
                playertwo = Instantiate(playertwoPrefab, new Vector3(-12, 3, 0), Quaternion.identity).GetComponent<PlayerController>();
                //playertwo.GetComponent<MeshRenderer>().material.color = Color.yellow;
                playertwo.startPos = startPos;
                playertwo.endPos = endPos;
            }

            if (gm.playerthree)
            {
                playerthree = Instantiate(playerthreePrefab, new Vector3(-12, -3, 0), Quaternion.identity).GetComponent<PlayerController>();
                //playerthree.GetComponent<MeshRenderer>().material.color = Color.blue;
                playerthree.startPos = startPos;
                playerthree.endPos = endPos;
            }

            if (gm.playerfour)
            {
                playerfour = Instantiate(playerfourPrefab, new Vector3(-12, -8.5f, 0), Quaternion.identity).GetComponent<PlayerController>();
                //playerfour.GetComponent<MeshRenderer>().material.color = Color.green;
                playerfour.startPos = startPos;
                playerfour.endPos = endPos;
            }
        }

        // Update is called once per frame
        void Update()
        {
            
        }
    }
}