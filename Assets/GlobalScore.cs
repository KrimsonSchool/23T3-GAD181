using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlobalScore : MonoBehaviour
{
    public int player1Score;
    public int player2Score;
    public int player3Score;
    public int player4Score;

    public TMPro.TextMeshProUGUI scoreText;
    public TMPro.TextMeshProUGUI roundsText;
    // Start is called before the first frame update
    void Start()
    {
        player1Score = PlayerPrefs.GetInt("player1Score");
        player2Score = PlayerPrefs.GetInt("player2Score");
        player3Score = PlayerPrefs.GetInt("player3Score");
        player4Score = PlayerPrefs.GetInt("player4Score");

        PlayerPrefs.SetInt("player1Score", PlayerPrefs.GetInt("player1Score") + 50);

        roundsText.text = ""+PlayerPrefs.GetInt("NoOfRounds");
    }

    // Update is called once per frame
    void Update()
    {
        scoreText.text = "· Player 1: " + player1Score + "\n\n· Player 2: " + player2Score + "\n\n· Player 3:" + player3Score + "\n\n· Player 4:" + player4Score + "\n\n";
    }
}
