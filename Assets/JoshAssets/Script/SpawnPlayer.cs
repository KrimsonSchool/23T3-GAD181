using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPlayer : MonoBehaviour
{
    public GameObject[] players; 
    // Start is called before the first frame update
    void Start()
    {
        for(int i = 0; i < PlayerPrefs.GetInt("Players"); i++)
        {
            players[i].SetActive(true);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
