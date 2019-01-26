using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Gobbler
{
    public class GameManager : MonoBehaviour
    {
        public static GameManager Instance
        {
            get; private set;
        }

        void Awake ()
        {
            Instance = this;
        }

        // Update is called once per frame
        void Update ()
        {

        }
    }
}