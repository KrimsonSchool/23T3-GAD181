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
        if (FoodAmountOne == 0 && gameManager.isFoodEaten == false)
        {

            gameManager.playerOneFood.SetActive(false);
            Debug.Log("Food transfer");
            FoodAmountOne += 10;
            gameManager.playerOneFood.SetActive(true);
            Debug.Log("Food Delivered");
            gameManager.isFoodEaten = true;
        }
        else if (gameManager.isFoodEaten == true)
        {
            gameManager.isFoodEaten = false;

        }

        if (FoodAmountTwo == 0 && gameManager.isFoodEaten == false)
        {
            gameManager.playerTwoFood.SetActive(false);
            Debug.Log("Food transfer");
            FoodAmountTwo += 10;
            gameManager.playerTwoFood.SetActive(true);
            Debug.Log("Food Delivered");
            gameManager.isFoodEaten = true;
        }
        else if (gameManager.isFoodEaten == true)
        {
            gameManager.isFoodEaten = false;
        }

        if (FoodAmountThree == 0 && gameManager.isFoodEaten == false)
        {
            gameManager.playerThreeFood.SetActive(false);
            Debug.Log("Food transfer");
            FoodAmountThree += 10;
            gameManager.playerThreeFood.SetActive(true);
            Debug.Log("Food Delivered");
            gameManager.isFoodEaten = true;
        }
        else if (gameManager.isFoodEaten == true)
        {
            gameManager.isFoodEaten = false;
        }

        if (FoodAmountFour == 0 && gameManager.isFoodEaten == false)
        {
            gameManager.playerFourFood.SetActive(false);
            Debug.Log("Food transfer");
            FoodAmountFour += 10;
            gameManager.playerFourFood.SetActive(true);
            Debug.Log("Food Delivered");
            gameManager.isFoodEaten = true;
        }
        else if (gameManager.isFoodEaten == true)
        {
            gameManager.isFoodEaten = false;
        }
    }


}
