using System;
using System.Collections;
using System.Collections.Generic;
using System.Xml.Schema;
using UnityEngine;
using TMPro;

public class GlobalScore : MonoBehaviour
{
    [Header("Score")]
    public int player1Score;
    public int player2Score;
    public int player3Score;
    public int player4Score;

    public TextMeshProUGUI player1ScoreText;
    public TextMeshProUGUI player2ScoreText;
    public TextMeshProUGUI player3ScoreText;
    public TextMeshProUGUI player4ScoreText;

    [Header("Winner")]
    public TextMeshProUGUI roundsText;

    public GameObject winnerMenu;
    public TextMeshProUGUI winNameText;
    public TextMeshProUGUI winScoresText;

    public int currentRound;
    // Start is called before the first frame update
    void Start()
    {
        player1Score = PlayerPrefs.GetInt("player1Score");
        player2Score = PlayerPrefs.GetInt("player2Score");
        player3Score = PlayerPrefs.GetInt("player3Score");
        player4Score = PlayerPrefs.GetInt("player4Score");

        int[] playerScores = new int[4]{ player1Score, player2Score, player3Score, player4Score};
        int winPlayer;
        Array.Sort(playerScores);

        
        //PlayerPrefs.SetInt("NoOfRounds", PlayerPrefs.GetInt("NoOfRounds") - 1);
        currentRound += 1;
        roundsText.text = currentRound + " / " + PlayerPrefs.GetInt("NoOfRounds");

        if (currentRound > PlayerPrefs.GetInt("NoOfRounds"))
        {
            print("Game Over!");
            winnerMenu.SetActive(true);

            if (player1Score == playerScores[playerScores.Length - 1])
            {
                winPlayer = 1;
            }
            else if(player2Score == playerScores[playerScores.Length - 1])
            {
                winPlayer = 2;
            }
            else if(player3Score == playerScores[playerScores.Length - 1])
            {
                winPlayer= 3;
            }
            else if(player4Score == playerScores[playerScores.Length - 1])
            {
                winPlayer = 4;
            }
            else
            {
                winPlayer = 0;
            }
            winNameText.text = "Player " + winPlayer + " wins!!!";

            winScoresText.text = "player 1: " + player1Score + "   player 2: " + player2Score + "   player 3: " + player3Score + "   player 4: " + player4Score;
        }
    }

    // Update is called once per frame
    void Update()
    {
        player1ScoreText.text = player1Score.ToString();
        player2ScoreText.text = player2Score.ToString();
        player3ScoreText.text = player3Score.ToString();
        player4ScoreText.text = player4Score.ToString();
    }
}
