using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Collections.Generic;

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
    public List<GameObject> playerplaying;
    // Start is called before the first frame update
    void Start()
    {
        gm = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();

        if (gm.playerone)
        {
            GameObject playerone = Instantiate(playeroneprefab, playeroneprefab.transform.position, Quaternion.identity);
            playerplaying.Add(playerone);
        }
        if (gm.playertwo)
        {
            GameObject playertwo = Instantiate(playertwoprefab, playertwoprefab.transform.position, Quaternion.identity);
            playerplaying.Add(playertwo);
        }
        if (gm.playerthree)
        {
            GameObject playerthree = Instantiate(playerthreeprefab, playerthreeprefab.transform.position, Quaternion.identity);
            playerplaying.Add(playerthree);
        }
        if (gm.playerfour)
        {
            GameObject playerfour = Instantiate(playerfourprefab, playerfourprefab.transform.position, Quaternion.identity);
            playerplaying.Add(playerfour);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
