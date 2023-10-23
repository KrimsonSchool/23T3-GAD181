using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class debuggernatior : MonoBehaviour
{
    public int player1, player2, player3, player4;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        PlayerPrefs.SetInt("player1Score", player1);
        PlayerPrefs.SetInt("player2Score", player2);
        PlayerPrefs.SetInt("player3Score", player3);
        PlayerPrefs.SetInt("player4Score", player4);
    }
}
