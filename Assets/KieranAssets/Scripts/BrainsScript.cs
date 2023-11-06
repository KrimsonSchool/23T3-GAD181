using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrainsScript : MonoBehaviour
{
    public GameManager gameManager;

    public int FoodAmountOne = 10; // This holds the amount of food left to eat in 1 brain.
    public int FoodAmountTwo = 10; // This holds the amount of food left to eat in 1 brain.
    public int FoodAmountThree = 10; // This holds the amount of food left to eat in 1 brain.
    public int FoodAmountFour = 10; // This holds the amount of food left to eat in 1 brain.
    public int FoodAmount = 10;
    public int BrainID = 0;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        PlayersEating(); // This call the 
        
    }
    void PlayersEating()
    {
        if (FoodAmount == 0/* && gameManager.isFoodEaten == false*/)
        {
            FoodAmount += 10;
            switch (BrainID)
            {
                case 1:
                    gameManager.playerOneFood.SetActive(false);
                    Debug.Log("Food transfer");
                    gameManager.playerOneFood.SetActive(true);
                    gameManager.UpdateScoreTextOne();
                    Debug.Log("Food Delivered");
                    break;
                case 2:
                    gameManager.playerOneFood.SetActive(false);
                    Debug.Log("Food transfer");
                    gameManager.playerOneFood.SetActive(true);
                    gameManager.UpdateScoreTextTwo();
                    Debug.Log("Food Delivered");
                    break;
                case 3:
                    gameManager.playerOneFood.SetActive(false);
                    Debug.Log("Food transfer");
                    gameManager.playerOneFood.SetActive(true);
                    gameManager.UpdateScoreTextThree();
                    Debug.Log("Food Delivered");
                    break;
                case 4:
                    gameManager.playerOneFood.SetActive(false);
                    Debug.Log("Food transfer");
                    gameManager.playerOneFood.SetActive(true);
                    gameManager.UpdateScoreTextFour();
                    Debug.Log("Food Delivered");
                    break;

            }
            gameManager.isFoodEaten = true;
        }
        //if (FoodAmountOne == 0 && gameManager.isFoodEaten == false)
        //{

        //    gameManager.playerOneFood.SetActive(false);
        //    Debug.Log("Food transfer");
        //    FoodAmountOne += 10;
        //    gameManager.playerOneFood.SetActive(true);
        //    Debug.Log("Food Delivered");
        //    gameManager.isFoodEaten = true;
        //}
        //else if (gameManager.isFoodEaten == true)
        //{
        //    gameManager.isFoodEaten = false;

        //}

        //if (FoodAmountTwo == 0 && gameManager.isFoodEaten == false)
        //{
        //    gameManager.playerTwoFood.SetActive(false);
        //    Debug.Log("Food transfer");
        //    FoodAmountTwo += 10;
        //    gameManager.playerTwoFood.SetActive(true);
        //    Debug.Log("Food Delivered");
        //    gameManager.isFoodEaten = true;
        //}
        //else if (gameManager.isFoodEaten == true)
        //{
        //    gameManager.isFoodEaten = false;
        //}

        //if (FoodAmountThree == 0 && gameManager.isFoodEaten == false)
        //{
        //    gameManager.playerThreeFood.SetActive(false);
        //    Debug.Log("Food transfer");
        //    FoodAmountThree += 10;
        //    gameManager.playerThreeFood.SetActive(true);
        //    Debug.Log("Food Delivered");
        //    gameManager.isFoodEaten = true;
           
        //}
        //else if (gameManager.isFoodEaten == true)
        //{
        //    gameManager.isFoodEaten = false;
        //}

        //if (FoodAmountFour == 0 && gameManager.isFoodEaten == false)
        //{
        //    gameManager.playerFourFood.SetActive(false);
        //    Debug.Log("Food transfer");
        //    FoodAmountFour += 10;
        //    gameManager.playerFourFood.SetActive(true);
        //    Debug.Log("Food Delivered");
        //    gameManager.isFoodEaten = true;
        //}
        //else if (gameManager.isFoodEaten == true)
        //{
        //    gameManager.isFoodEaten = false;
        //}
    }


}
