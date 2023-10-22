using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public TextMeshProUGUI playerOnesScore;
    public TextMeshProUGUI playerTwosScore;
    public TextMeshProUGUI playerThreesScore;
    public TextMeshProUGUI playerFoursScore;
    public BrainsScript foodCounter;

    public int oneScore = 0;
    public int twoScore = 0;
    public int threeScore = 0;
    public int fourScore = 0;

    // Start is called before the first frame update
    void Start()
    {
        playerOnesScore.text = oneScore.ToString();
        playerTwosScore.text = twoScore.ToString();
        playerThreesScore.text = threeScore.ToString();
        playerFoursScore.text = fourScore.ToString();

    }

    // Update is called once per frame
    void Update()
    {
        updateScoreText();

    }
    public void updateScoreText()
    {
        if(foodCounter.FoodAmountOne == 0)
        {
            oneScore += 1;
            playerOnesScore.text = oneScore.ToString();
        }
        else if(foodCounter.FoodAmountTwo == 0)
        {
            twoScore += 1;
            playerTwosScore.text = twoScore.ToString();
        }
        else if (foodCounter.FoodAmountThree == 0)
        { 
            threeScore += 1;
            playerThreesScore.text = threeScore.ToString();

        }
        else if (foodCounter.FoodAmountFour == 0)
        {
            fourScore += 1;
            playerFoursScore.text = fourScore.ToString();
        }    
    }


}
