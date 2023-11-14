using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiniGameTwoPlayerController : MonoBehaviour
{
    #region variables and references
    /*
     * Create some variables to hold;
     * a reference to the zombies game object
     * an int to idnentify which zombie is which player 1-4
    */
    public int zombieID = 0; // This holds an int to be assigned a number 1-4.
    public GameObject zombie; // This is reference to the assigned GameObject.

    #endregion

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        Kieran_PlayerMovement();
    }

    #region Return to position

    /*
     * Create a function to return the Zombie GameObject to its original position.
     * This will be called after 0.5 seconds to allow for a small delay.
     */

    IEnumerator ReturnToPosition() 
    {
        yield return new WaitForSeconds(0.5f); // This returns a value of 0.5 in the form of seconds.
        if (zombieID == 1) // This checks the zoombieID for the number 1
        {
            transform.position = new Vector3(-4, 0, 2); // This changes the position of the GameObject to a new vector(Player one)
        }
        else if (zombieID == 2) // This checks the zoombieID for the number 2
        {
            transform.position = new Vector3(-4, 0, 4); // This changes the position of the GameObject to a new vector(Player Two)
        }
        else if (zombieID == 3) // This checks the zoombieID for the number 3
        {
            transform.position = new Vector3(4, 0, 2); // This changes the position of the GameObject to a new vector(Player Three)
        }
        else if (zombieID == 4) // This checks the zoombieID for the number 4
        {
            transform.position = new Vector3(4, 0, 4); // This changes the position of the GameObject to a new vector(Player Four)
        }
    }
    #endregion

    #region PlayerMovement
    /*
     * Create a function to move the players
     * This should be called on a button input
     * Assign the same buttons used in the previous minigame for similarity
     */

    void Kieran_PlayerMovement() // A function to hold some code
    {
        switch (zombieID) // A if statement that holds mutliple variations of the same code under the variable of zombieID
        {
            case 1: // This is the first if statment assigned a case number of 1
                if(zombieID == 1 && Input.GetKeyDown(KeyCode.LeftControl)) // checks to see if 1 has been assigned to zombieID and the Left control has been pressed.
                {
                    transform.position = new Vector3(0, 0, 2); // This changes the position of the GameObject to a new vector (Player One)
                    StartCoroutine(ReturnToPosition()); // This calls the Ienumorator to return the positions of the game objects
                }
               
                break; // This breaks out of this current case.

            case 2: // This is the first if statment assigned a case number of 2
                if (zombieID == 2 && Input.GetKeyDown(KeyCode.LeftAlt)) // checks to see if 2 has been assigned to zombieID and the Left Alt has been pressed.
                {
                    transform.position = new Vector3(0, 0, 4); // This changes the position of the GameObject to a new vector (Player Two)
                    StartCoroutine(ReturnToPosition()); // This calls the Ienumorator to return the positions of the game objects
                }
                break; // This breaks out of this current case.

            case 3: // This is the first if statment assigned a case number of 3
                if (zombieID == 3 && Input.GetKeyDown(KeyCode.RightAlt)) // checks to see if 3 has been assigned to zombieID and the Rigth Alt has been pressed.
                {
                    transform.position = new Vector3(0, 0, 2); // This changes the position of the GameObject to a new vector (Player Three)
                    StartCoroutine(ReturnToPosition()); // This calls the Ienumorator to return the positions of the game objects
                }
                break; // This breaks out of this current case.

            case 4: // This is the first if statment assigned a case number of 4
                if (zombieID == 4 && Input.GetKeyDown(KeyCode.RightControl)) // checks to see if 4 has been assigned to zombieID and the Right control has been pressed.
                {
                    transform.position = new Vector3(0, 0, 4); // This changes the position of the GameObject to a new vector (Player Four)
                    StartCoroutine(ReturnToPosition()); // This calls the Ienumorator to return the positions of the game objects
                }
                break; // This breaks out of this current case.
        }
    }
    #endregion
}
