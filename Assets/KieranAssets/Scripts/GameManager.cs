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
    public BrainsScript foodCounter; // This is a script reference to brainscript.
    public TimerManager timer;
    public Playercontroller Playercontroller;

    // Create some Ints to hold the score
    // This should be for each player.

    public int oneScore = 0; // This is a placeholder for player ones points to update the text.
    public int twoScore = 0; // This is a placeholder for player twos points to update the text.
    public int threeScore = 0; // This is a placeholder for player threes points to update the text.
    public int fourScore = 0; // This is a placeholder for player four4s points to update the text.

    public bool isGameReady = false;

    #endregion

    #region Start Function
    // Start is called before the first frame update
    void Start()
    {
        playerOnesScore.text = oneScore.ToString(); // This sets the players scores to 0
        playerTwosScore.text = twoScore.ToString(); // This sets the players scores to 0
        playerThreesScore.text = threeScore.ToString(); // This sets the players scores to 0
        playerFoursScore.text = fourScore.ToString(); // This sets the players scores to 0

    }
    #endregion

    IEnumerator waitForGameReady()
    {
        yield return new WaitForSeconds(5f);

    }

    #region Update function
    // Update is called once per frame
    void Update()
    {
        updateScoreText(); // This call the function to update the scores.
        GameWinDecider(); 
       

    }
    #endregion

    #region Player scoring
    // Creater a function to update player scores when they have eaten their item.
    // This should increase by 1 point.
    // It will be based on the food health value and if it has reacehd 0.
    public void updateScoreText() // This is a function to add scores to a player everytime an item is eaten.
    {
        if(foodCounter.FoodAmountOne == 0) // This is an if statement for player one.
        {
            oneScore += 1;
            playerOnesScore.text = oneScore.ToString();
        }
        else if(foodCounter.FoodAmountTwo == 0) // This is an if statement for player two. 
        {
            twoScore += 1;
            playerTwosScore.text = twoScore.ToString();
        }
        else if (foodCounter.FoodAmountThree == 0) // This is an if statement for player three. 
        { 
            threeScore += 1;
            playerThreesScore.text = threeScore.ToString();

        }
        else if (foodCounter.FoodAmountFour == 0) // This is an if statement for player four.
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
                Debug.Log("Winner is player ONE!");
            }
            else if (twoScore > oneScore && twoScore > threeScore && twoScore > fourScore)
            {
                Debug.Log("Winner is player TWO!");
            }
            else if (threeScore > oneScore && threeScore > twoScore && threeScore > fourScore)
            {
                Debug.Log("Winner is player Three!");
            }
            else if (fourScore > oneScore && fourScore > twoScore && fourScore > threeScore)
            {
                Debug.Log("Winner is player Four!");
            }
        }
        



    }
    #endregion

}
