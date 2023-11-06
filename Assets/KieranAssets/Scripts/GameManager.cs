using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
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
    

    // Create some Ints to hold the score
    // This should be for each player.

    public int oneScore = 0; // This is a placeholder for player ones points to update the text.
    public int twoScore = 0; // This is a placeholder for player twos points to update the text.
    public int threeScore = 0; // This is a placeholder for player threes points to update the text.
    public int fourScore = 0; // This is a placeholder for player four4s points to update the text.

    public bool isGameReady = false;
    public bool canPlayerMove = false;
    public bool isFoodEaten = false;

    #endregion

    #region Start Function
    // Start is called before the first frame update
    void Start()
    {
        Winner.enabled = false;
        playerOnesScore.text = oneScore.ToString(); // This sets the players scores to 0
        playerTwosScore.text = twoScore.ToString(); // This sets the players scores to 0
        playerThreesScore.text = threeScore.ToString(); // This sets the players scores to 0
        playerFoursScore.text = fourScore.ToString(); // This sets the players scores to 0

        StartCoroutine(WaitForGameReady());

    }
    #endregion

    IEnumerator WaitForGameReady()
    {
        yield return new WaitForSeconds(5f);
        canPlayerMove = true;
        timer.isTimerOn = true;
    }

    

    #region Update function
    // Update is called once per frame
    void Update()
    {
        
       GameWinDecider(); 
       UpdateScoreText();

    }
    #endregion

    #region Player scoring
    // Creater a function to update player scores when they have eaten their item.
    // This should increase by 1 point.
    // It will be based on the food health value and if it has reacehd 0.
    public void UpdateScoreText() // This is a function to add scores to a player everytime an item is eaten.
    {
        if (foodUpdate01.FoodAmountOne == 0) // This is an if statement for player one.
        {
            oneScore += 1;
            playerOnesScore.text = oneScore.ToString();
        }
        else if (foodUpdate02.FoodAmountTwo == 0) // This is an if statement for player two. 
        {
            twoScore += 1;
            playerTwosScore.text = twoScore.ToString();
        }
        else if (foodUpdate03.FoodAmountThree == 0) // This is an if statement for player three. 
        {
            threeScore += 1;
            playerThreesScore.text = threeScore.ToString();

        }
        else if (foodUpdate04.FoodAmountFour == 0) // This is an if statement for player four.
        {
            fourScore += 1;
            playerFoursScore.text = fourScore.ToString();
        }
    }
    #endregion

    #region Winning
    public void GameWinDecider()
    {
        if(timer.remainingTime == 0)
        {
            if (oneScore > twoScore && oneScore > threeScore && oneScore > fourScore)
            {
                PlayerPrefs.SetInt("player1Score", PlayerPrefs.GetInt("player1Score") + 50);
                Debug.Log("Winner is player ONE!");
                Winner.enabled = true;
                Winner.text = oneScore.ToString("Player 1 Wins!");
                
            }
            else if (twoScore > oneScore && twoScore > threeScore && twoScore > fourScore)
            {
                PlayerPrefs.SetInt("player2Score", PlayerPrefs.GetInt("player2Score") + 50);
                Debug.Log("Winner is player TWO!");
                Winner.enabled = true;
                Winner.text = twoScore.ToString("Player 2 Wins!");
            }
            else if (threeScore > oneScore && threeScore > twoScore && threeScore > fourScore)
            {
                PlayerPrefs.SetInt("player3Score", PlayerPrefs.GetInt("player3Score") + 50);
                Debug.Log("Winner is player Three!");
                Winner.enabled = true;
                Winner.text = threeScore.ToString("Player 1 Wins!");
            }
            else if (fourScore > oneScore && fourScore > twoScore && fourScore > threeScore)
            {
                PlayerPrefs.SetInt("playe41Score", PlayerPrefs.GetInt("player4Score") + 50);
                Debug.Log("Winner is player Four!");
                Winner.enabled = true;
                Winner.text = fourScore.ToString("Player 1 Wins!");
            }
            canPlayerMove = false;
            timer.isTimerOn = false;
        }
        // Split points for equal score

        



    }
    #endregion

}
