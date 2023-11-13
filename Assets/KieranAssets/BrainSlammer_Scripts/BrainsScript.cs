using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrainsScript : MonoBehaviour
{
    #region reference and classes
    public GameManager gameManager; // This is a reference to the Gamemanager

    public int foodAmount = 10; // This holds an int under foodAmount of 10
    public int burgerID = 0; // This holds an int under burgerID of 0
    #endregion

    #region Update
    // Update is called once per frame
    void Update()
    {
        PlayersEating(); // This call the function PlayersEating()  
    }
    #endregion

    #region PlayerEating Function 
    void PlayersEating() // This is a function to manage the burgers
    {
        if (foodAmount == 0) // checks if the foodAmount is 0
        {
            foodAmount += 10; // Adds 10 to the foodAmount
            switch (burgerID) // Creates a variation of conditions assigned to different case
            {
                case 1: // This assigns 1 to this case
                    gameManager.playerOneFood.SetActive(false); // This sets the gameObject inactive
                    Debug.Log("Food transfer"); // A debug log
                    gameManager.playerOneFood.SetActive(true); // This sets the gameObject active
                    gameManager.UpdateScoreTextOne(); // This calls a function from the gamemanager to update scores
                    Debug.Log("Food Delivered"); // a Debug log
                    break; // This breaks out of this varitaion.
                case 2:
                    gameManager.playerOneFood.SetActive(false); // This sets the gameObject inactive
                    Debug.Log("Food transfer"); // A debug log
                    gameManager.playerOneFood.SetActive(true); // This sets the gameObject active
                    gameManager.UpdateScoreTextTwo(); // This calls a function from the gamemanager to update scores
                    Debug.Log("Food Delivered"); // A debug log
                    break; // This breaks out of this varitaion.
                case 3:
                    gameManager.playerOneFood.SetActive(false); // This sets the gameObject inactive
                    Debug.Log("Food transfer"); // A debug log
                    gameManager.playerOneFood.SetActive(true); // This sets the gameObject active
                    gameManager.UpdateScoreTextThree(); // This calls a function from the gamemanager to update scores
                    Debug.Log("Food Delivered"); // A debug log
                    break; // This breaks out of this varitaion.
                case 4:
                    gameManager.playerOneFood.SetActive(false); // This sets the gameObject inactive
                    Debug.Log("Food transfer"); // A debug log
                    gameManager.playerOneFood.SetActive(true); // This sets the gameObject active
                    gameManager.UpdateScoreTextFour(); // This calls a function from the gamemanager to update scores
                    Debug.Log("Food Delivered"); // A debug log
                    break; // This breaks out of this varitaion.

            }
            
        }
    }
    #endregion

}
