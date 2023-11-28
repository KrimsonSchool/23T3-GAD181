using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParKon : MonoBehaviour
{
    /*[HideInInspector]*/ public KeyCode[] jumpInput;
    public GameObject[] players;
    // Start is called before the first frame update
    void Start()
    {
        jumpInput[0] = KeyCode.LeftControl;
        jumpInput[1] = KeyCode.LeftAlt;
        jumpInput[2] = KeyCode.RightControl;
        jumpInput[3] = KeyCode.RightAlt;

        for (int i = 0; i < PlayerPrefs.GetInt("Players"); i++)
        {
            players[i].SetActive(true);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
