using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Playercontroller : MonoBehaviour
{
    #region References
    /*
     * Create references to hold access to;
     * scripts to change conditions
     * animation of characters
     * audio source for characters
     */

    public BrainsScript foodAccess; // A reference to the BrainScript script
    public GameManager gameManager; // A refernce to the GameMananger script
    public Animation animToPlay; // A referecne to the animation to be played in the scene
    public AudioSource eatingSound; // A reference to the audio source.
    #endregion

    #region Start 
    // Start is called before the first frame update
    void Start()
    {
        animToPlay = GetComponent<Animation>(); // Assigning the animation required to play the component Animation.
    }
    #endregion

    #region Update
    // Update is called once per frame
    void Update()
    {
        if (gameManager.canPlayerMove == true) // Checking to see if the player can move
        {
            PickUpButton(); // Calls the pick up button function
        }
    }
    #endregion

    #region PlayerKeyBinds

    /*
     * Create a set of key codes to assign each player
     * This should be 1 button easily accesible for multiple players
     * Lft Ctrl, Lft Alt, Rht Alt, Rht Lft
     */

    void PickUpButton() // A function to call the players key inputs
    {
        if(foodAccess.burgerID == 1 && Input.GetKeyDown(KeyCode.LeftControl)) // Checking to see if the player has the burgerID 1 and has pressed the left control.
        {
            
            if (foodAccess.foodAmount >= 1 && foodAccess.foodAmount <= 10) // Checking if the foodamount in the brain script is greater or equal to 1 and less than or equal to 10.
            {
                foodAccess.foodAmount -= 1; // Minusing 1 from the food amount
                Debug.Log("KEEP EATING!!!"); // A debug Log
            }
            else if (foodAccess.foodAmount == 0) // Checking to see if the foodamount in brain script is eual to 0.
            {
                Debug.Log("All food is eaten"); // A debug log
            }
            animToPlay.Play("EatingZombie"); //  Plays the assigned animation, with the name of "EatingZombie".
            eatingSound.Play(); // Plays the assigned eating sound in the inspector.

        }
        if (foodAccess.burgerID == 2 && Input.GetKeyDown(KeyCode.LeftAlt)) // Checking to see if the player has the burgerID 2 and has pressed the left alt.
        {
            if (foodAccess.foodAmount >= 1 && foodAccess.foodAmount <= 10) // Checking if the foodamount in the brain script is greater or equal to 1 and less than or equal to 10.
            {
                foodAccess.foodAmount -= 1; // Minusing 1 from the food amount
                Debug.Log("KEEP EATING!!!"); // A debug Log
            }
            else if (foodAccess.foodAmount == 0) // Checking to see if the foodamount in brain script is eual to 0.
            {
                Debug.Log("All food is eaten"); // A debug Log
            }
            animToPlay.Play("EatingZombie"); //  Plays the assigned animation, with the name of "EatingZombie".
            eatingSound.Play();// Plays the assigned eating sound in the inspector.

        }
        if (foodAccess.burgerID == 3 && Input.GetKeyDown(KeyCode.RightAlt)) // Checking to see if the player has the burgerID 3 and has pressed the right alt.
        {
            if (foodAccess.foodAmount >= 1 && foodAccess.foodAmount <= 10) // Checking if the foodamount in the brain script is greater or equal to 1 and less than or equal to 10.
            {
                foodAccess.foodAmount -= 1; // Minusing 1 from the food amount
                Debug.Log("KEEP EATING!!!"); // A debug Log
            }
            else if (foodAccess.foodAmount == 0) // Checking to see if the foodamount in brain script is eual to 0.
            {
                Debug.Log("All food is eaten"); // A debug Log
            }
            animToPlay.Play("EatingZombie"); //  Plays the assigned animation, with the name of "EatingZombie".
            eatingSound.Play();// Plays the assigned eating sound in the inspector.

        }
        if (foodAccess.burgerID == 4 && Input.GetKeyDown(KeyCode.RightControl)) // Checking to see if the player has the burgerID 4 and has pressed the right control.
        {
            if (foodAccess.foodAmount >= 1 && foodAccess.foodAmount <= 10) // Checking if the foodamount in the brain script is greater or equal to 1 and less than or equal to 10.
            {
                foodAccess.foodAmount -= 1; // Minusing 1 from the food amount
                Debug.Log("KEEP EATING!!!"); // A debug Log
            }
            else if (foodAccess.foodAmount == 0) // Checking to see if the foodamount in brain script is eual to 0.
            {
                Debug.Log("All food is eaten"); // A debug Log
            }
            animToPlay.Play("EatingZombie"); //  Plays the assigned animation, with the name of "EatingZombie".
            eatingSound.Play();// Plays the assigned eating sound in the inspector.

        }

    }
    #endregion
}
