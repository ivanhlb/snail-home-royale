using System.Collections;
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
        public GameObject playerone;
        public GameObject playertwo;
        public GameObject playerthree;
        public GameObject playerfour;
        // Start is called before the first frame update
        void Start()
        {
            gm = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();

            if (gm.playerone)
            {
                playerone = Instantiate(playeronePrefab, new Vector3(-12, 8.5f,0), Quaternion.identity);
                playerone.GetComponent<MeshRenderer>().material.color = Color.red;
            }

            if (gm.playertwo)
            {
                playertwo = Instantiate(playertwoPrefab, new Vector3(-12, 3, 0), Quaternion.identity);
                playertwo.GetComponent<MeshRenderer>().material.color = Color.yellow;
            }

            if (gm.playerthree)
            {
                playerthree = Instantiate(playerthreePrefab, new Vector3(-12, -3, 0), Quaternion.identity);
                playerthree.GetComponent<MeshRenderer>().material.color = Color.blue;
            }

            if (gm.playerfour)
            {
                playerfour = Instantiate(playerfourPrefab, new Vector3(-12, -8.5f, 0), Quaternion.identity);
                playerfour.GetComponent<MeshRenderer>().material.color = Color.green;
            }
        }

        // Update is called once per frame
        void Update()
        {
            
        }
    }
}