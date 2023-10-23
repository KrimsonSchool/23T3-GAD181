using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrainsScript : MonoBehaviour
{
    public GameObject playerOneFood; // This is a reference to the gameObject in the scene of playerOnesfood
    public GameObject playerTwoFood; // This is a reference to the gameObject in the scene of playerTwosfood
    public GameObject playerThreeFood; // This is a reference to the gameObject in the scene of playerThreesfood
    public GameObject playerFourFood; // This is a reference to the gameObject in the scene of playerFoursfood

    public int FoodAmountOne = 10; // This holds the amount of food left to eat in 1 brain.
    public int FoodAmountTwo = 10; // This holds the amount of food left to eat in 1 brain.
    public int FoodAmountThree = 10; // This holds the amount of food left to eat in 1 brain.
    public int FoodAmountFour = 10; // This holds the amount of food left to eat in 1 brain.

    public bool isPoneFoodEaten = false; // This checks is the food has been eaten and it initalise is set to false
    public bool isPtwoFoodEaten = false; // This checks is the food has been eaten and it initalise is set to false
    public bool isPthreeFoodEaten = false; // This checks is the food has been eaten and it initalise is set to false
    public bool isPfourFoodEaten = false; // This checks is the food has been eaten and it initalise is set to false


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
        if (FoodAmountOne == 0 && isPoneFoodEaten == false)
        {

            playerOneFood.SetActive(false);
            Debug.Log("Food transfer");
            FoodAmountOne += 10;
            playerOneFood.SetActive(true);
            Debug.Log("Food Delivered");
            isPoneFoodEaten = true;
        }
        else if (isPoneFoodEaten == true)
        {
            isPoneFoodEaten = false;

        }

        if (FoodAmountTwo == 0 && isPtwoFoodEaten == false)
        {
            playerTwoFood.SetActive(false);
            Debug.Log("Food transfer");
            FoodAmountTwo += 10;
            playerTwoFood.SetActive(true);
            Debug.Log("Food Delivered");
            isPtwoFoodEaten = true;
        }
        else if (isPtwoFoodEaten == true)
        {
            isPtwoFoodEaten = false;
        }

        if (FoodAmountThree == 0 && isPthreeFoodEaten == false)
        {
            playerThreeFood.SetActive(false);
            Debug.Log("Food transfer");
            FoodAmountThree += 10;
            playerThreeFood.SetActive(true);
            Debug.Log("Food Delivered");
            isPthreeFoodEaten = true;
        }
        else if (isPthreeFoodEaten == true)
        {
            isPthreeFoodEaten = false;
        }

        if (FoodAmountFour == 0 && isPfourFoodEaten == false)
        {
            playerFourFood.SetActive(false);
            Debug.Log("Food transfer");
            FoodAmountFour += 10;
            playerFourFood.SetActive(true);
            Debug.Log("Food Delivered");
            isPfourFoodEaten = true;
        }
        else if (isPfourFoodEaten == true)
        {
            isPfourFoodEaten = false;
        }
    }

}
