using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor.SceneManagement;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    #region References and score placeholder

    // Create some refernece points.
    // This is for texts UI
    // And a script reference
    public TextMeshProUGUI playerOnesScore; //This is a text reference to player ones score text.
    public TextMeshProUGUI playerTwosScore; //This is a text reference to player twos score text.
    public TextMeshProUGUI playerThreesScore; //This is a text reference to player three score text.
    public TextMeshProUGUI playerFoursScore; //This is a text reference to player fours score text.
    public TextMeshProUGUI Winner;
    public Image controlsUI;
    public TextMeshProUGUI goalText;
    public TextMeshProUGUI timerText;
    
    

    /*public BrainsScript foodCounterTwo; // This is a script reference to brainscript.
    public BrainsScript foodCounterThree; // This is a script reference to brainscript.
    public BrainsScript foodCounterFour; // This is a script reference to brainscript.*/

    public GameObject playerOneFood; // This is a reference to the gameObject in the scene of playerOnesfood
    public GameObject playerTwoFood; // This is a reference to the gameObject in the scene of playerTwosfood
    public GameObject playerThreeFood; // This is a reference to the gameObject in the scene of playerThreesfood
    public GameObject playerFourFood; // This is a reference to the gameObject in the scene of playerFoursfood
    [SerializeField] private BrainsScript foodUpdate01;
    [SerializeField] private BrainsScript foodUpdate02;
    [SerializeField] private BrainsScript foodUpdate03;
    [SerializeField] private BrainsScript foodUpdate04;
    public TimerManager timer;
    public AudioManager audioManager;
    public AudioSource spaceShipAlarm;


    // Create some Ints to hold the score
    // This should be for each player.

    public int oneScore = 0; // This is a placeholder for player ones points to update the text.
    public int twoScore = 0; // This is a placeholder for player twos points to update the text.
    public int threeScore = 0; // This is a placeholder for player threes points to update the text.
    public int fourScore = 0; // This is a placeholder for player four4s points to update the text.

    public bool isGameReady = false;
    public bool canPlayerMove = false;
    public bool isFoodEaten = false;

    public bool playerOneWin = false;
    public bool playerTwoWin = false;
    public bool playerThreeWin = false;
    public bool playerFourWin = false;

    #endregion

    #region Start Function
    // Start is called before the first frame update
    void Start()
    {
        spaceShipAlarm.Play();
        controlsUI.enabled = true;
        Winner.enabled = false;
        playerOnesScore.text = oneScore.ToString(); // This sets the players scores to 0
        playerTwosScore.text = twoScore.ToString(); // This sets the players scores to 0
        playerThreesScore.text = threeScore.ToString(); // This sets the players scores to 0
        playerFoursScore.text = fourScore.ToString(); // This sets the players scores to 0
        StartCoroutine(WaitForGameReady());
        PlayerPrefs.GetInt("Players");

    }
    #endregion

    IEnumerator WaitForGameReady()
    {
        yield return new WaitForSeconds(10f);
        
        canPlayerMove = true;
        timer.isTimerOn = true;
        controlsUI.enabled = false;
        goalText.enabled = false;
        timerText.enabled = false;
        
        
    }

    IEnumerator WaitToFinishGame()
    {
        yield return new WaitForSeconds(1f);
        if(playerOneWin == true)
        {
            PlayerPrefs.SetInt("player1Score", PlayerPrefs.GetInt("player1Score") + 50);
        }
        else if(playerTwoWin == true) 
        {
            PlayerPrefs.SetInt("player2Score", PlayerPrefs.GetInt("player2Score") + 50);
        }
        else if(playerThreeWin == true) 
        {
            PlayerPrefs.SetInt("player3Score", PlayerPrefs.GetInt("player3Score") + 50);
        }
        else if(playerFourWin == true)
        {
            PlayerPrefs.SetInt("player4Score", PlayerPrefs.GetInt("player4Score") + 50);
        }
        SceneManager.LoadScene("GamePick");

    }


    #region Update function
    // Update is called once per frame
    void Update()
    {
       // UpdateScoreText();
        GameWinDecider();
        
       

    }
    #endregion

    #region Player scoring
    // Creater a function to update player scores when they have eaten their item.
    // This should increase by 1 point.
    // It will be based on the food health value and if it has reacehd 0.
    public void UpdateScoreTextOne()
    {
        oneScore += 1;
        playerOnesScore.text = oneScore.ToString();
    }
    public void UpdateScoreTextTwo()
    {
        twoScore += 1;
        playerTwosScore.text = twoScore.ToString();
    }
    public void UpdateScoreTextThree()
    {
        threeScore += 1;
        playerThreesScore.text = threeScore.ToString();
    }
    public void UpdateScoreTextFour()
    {
        fourScore += 1;
        playerFoursScore.text = fourScore.ToString();
    }
    //public void UpdateScoreText() // This is a function to add scores to a player everytime an item is eaten.
    //{
    //    if (foodUpdate01.FoodAmountOne == 0) // This is an if statement for player one.
    //    {
    //        oneScore += 1;
    //        playerOnesScore.text = oneScore.ToString();
    //    }
    //    if (foodUpdate02.FoodAmountTwo == 0) // This is an if statement for player two. 
    //    {
    //        twoScore += 1;
    //        playerTwosScore.text = twoScore.ToString();
    //    }
    //    // if (foodUpdate03.FoodAmountThree == 0) // This is an if statement for player three. 
    //    //{
    //    //    threeScore += 1;
    //    //    playerThreesScore.text = threeScore.ToString();

    //    //}
    //    if (foodUpdate04.FoodAmountFour == 0) // This is an if statement for player four.
    //    {
    //        fourScore += 1;
    //        playerFoursScore.text = fourScore.ToString();
    //    }
    //}
    #endregion

    #region Winning
    public void GameWinDecider()
    {
        if(timer.remainingTime == 0)
        {
            if (oneScore > twoScore && oneScore > threeScore && oneScore > fourScore)
            {
                playerOneWin = true;
                Debug.Log("Winner is player ONE!");
                Winner.enabled = true;
                Winner.text = oneScore.ToString("Player 1 Wins!");
            }
            else if (twoScore > oneScore && twoScore > threeScore && twoScore > fourScore)
            {
                playerTwoWin = true;
                Debug.Log("Winner is player TWO!");
                Winner.enabled = true;
                Winner.text = twoScore.ToString("Player 2 Wins!");
            }
            else if (threeScore > oneScore && threeScore > twoScore && threeScore > fourScore)
            {
                playerThreeWin = true;
                Debug.Log("Winner is player Three!");
                Winner.enabled = true;
                Winner.text = threeScore.ToString("Player 3 Wins!");
            }
            else if (fourScore > oneScore && fourScore > twoScore && fourScore > threeScore)
            {
                playerFourWin = true;
                Debug.Log("Winner is player Four!");
                Winner.enabled = true;
                Winner.text = fourScore.ToString("Player 4 Wins!");
            }
            canPlayerMove = false;
            timer.isTimerOn = false;
            StartCoroutine(WaitToFinishGame());

        }
        // Split points for equal score

        
        


    }
    #endregion

}
