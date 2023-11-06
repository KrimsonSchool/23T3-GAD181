using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrainsScript : MonoBehaviour
{
    public GameManager gameManager;

   
    public int foodAmount = 10;
    public int brainID = 0;

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
        if (foodAmount == 0/* && gameManager.isFoodEaten == false*/)
        {
            foodAmount += 10;
            switch (brainID)
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
        //if (foodAmountOne == 0 && gameManager.isFoodEaten == false)
        //{

        //    gameManager.playerOneFood.SetActive(false);
        //    Debug.Log("Food transfer");
        //    foodAmountOne += 10;
        //    gameManager.playerOneFood.SetActive(true);
        //    Debug.Log("Food Delivered");
        //    gameManager.isFoodEaten = true;
        //}
        //else if (gameManager.isFoodEaten == true)
        //{
        //    gameManager.isFoodEaten = false;

        //}

        //if (foodAmountTwo == 0 && gameManager.isFoodEaten == false)
        //{
        //    gameManager.playerTwoFood.SetActive(false);
        //    Debug.Log("Food transfer");
        //    foodAmountTwo += 10;
        //    gameManager.playerTwoFood.SetActive(true);
        //    Debug.Log("Food Delivered");
        //    gameManager.isFoodEaten = true;
        //}
        //else if (gameManager.isFoodEaten == true)
        //{
        //    gameManager.isFoodEaten = false;
        //}

        //if (foodAmountThree == 0 && gameManager.isFoodEaten == false)
        //{
        //    gameManager.playerThreeFood.SetActive(false);
        //    Debug.Log("Food transfer");
        //    foodAmountThree += 10;
        //    gameManager.playerThreeFood.SetActive(true);
        //    Debug.Log("Food Delivered");
        //    gameManager.isFoodEaten = true;
           
        //}
        //else if (gameManager.isFoodEaten == true)
        //{
        //    gameManager.isFoodEaten = false;
        //}

        //if (foodAmountFour == 0 && gameManager.isFoodEaten == false)
        //{
        //    gameManager.playerFourFood.SetActive(false);
        //    Debug.Log("Food transfer");
        //    foodAmountFour += 10;
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
