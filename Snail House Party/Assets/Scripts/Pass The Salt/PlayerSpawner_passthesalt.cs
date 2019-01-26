using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSpawner_passthesalt : MonoBehaviour
{
    GameManager gm;
    [SerializeField]
    GameObject playeroneprefab;
    [SerializeField]
    GameObject playertwoprefab;
    [SerializeField]
    GameObject playerthreeprefab;
    [SerializeField]
    GameObject playerfourprefab;
    // Start is called before the first frame update
    void Start()
    {
        gm = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (gm.playerone)
        {
            Instantiate(playeroneprefab, playeroneprefab.transform);
        }
        if (gm.playertwo)
        {
            Instantiate(playertwoprefab, playertwoprefab.transform);
        }
        if (gm.playerthree)
        {
            Instantiate(playerthreeprefab, playerthreeprefab.transform);
        }
        if (gm.playerfour)
        {
            Instantiate(playerfourprefab, playerfourprefab.transform);
        }
    }
}
