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
    public HungryZombiesManager zombieManager;
    public bool canPlayerMove = false;

    public Animation zombieWalkingAndGrab;
    
    

    #endregion

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //StartCoroutine(ReturnZombiesToReadyPosiiton());
        Kieran_PlayerMovement();
    }

    public void OnTriggerEnter(Collider other)
    {
        if (zombieID == 1)
        {
            zombieWalkingAndGrab.Play("GrabingZombie");
            zombieManager.UpdatePlayerOneScore();
        }
        if (zombieID == 2)
        {
            zombieWalkingAndGrab.Play("GrabingZombie");
            zombieManager.UpdatePlayerTwoScore();
        }
        if (zombieID == 3)
        {
            zombieWalkingAndGrab.Play("GrabingZombie");
            zombieManager.UpdatePlayerThreeScore();
        }
        if (zombieID == 4)
        {
            zombieWalkingAndGrab.Play("GrabingZombie");
            zombieManager.UpdatePlayerFourScore();
        }
    }

    public void ReturnZombiesToReadyPosiiton()
    {
       
        Vector3 xyz = new Vector3(0, 90, 0);
        Vector3 reversexyz = new Vector3(0, -90, 0);

        if(zombieID == 1)
        {
            transform.position = new Vector3(26, 0.1f, -20.5f);
            transform.rotation = Quaternion.Euler(xyz);
        }
        if (zombieID == 2)
        {
            transform.position = new Vector3(26, 0.1f, -18.5f);
            transform.rotation = Quaternion.Euler(xyz);
        }
        if (zombieID == 3)
        {
            transform.position = new Vector3(33.5f, 0.1f, -20.5f);
            transform.rotation = Quaternion.Euler(reversexyz);
        }
        if (zombieID == 4)
        {
            transform.position = new Vector3(33.5f, 0.1f, -18.5f);
            transform.rotation = Quaternion.Euler(reversexyz);
        }
    }


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
                if (canPlayerMove)
                {
                    if (zombieID == 1 && Input.GetKey(KeyCode.LeftControl)) // checks to see if 1 has been assigned to zombieID and the Left control has been pressed.
                    {
                        zombieWalkingAndGrab.Play("ZombieWalkingAndGrab");
                        transform.Translate(0, 0, 5f * Time.deltaTime); // This changes the position of the GameObject to a new vector (Player One)
                                                                        //StartCoroutine(ReturnToPosition()); // This calls the Ienumorator to return the positions of the game objects

                    }
                    else if (Input.GetKeyUp(KeyCode.LeftControl))
                    {
                        zombieWalkingAndGrab.Stop("ZombieWalkingAndGrab");
                        transform.position = new Vector3(26, 0.1f, -20.5f); // This changes the position of the GameObject to a new vector(Player one)
                    }
                }
                    break; // This breaks out of this current case.
                

                case 2: // This is the first if statment assigned a case number of 2
                if (canPlayerMove)
                {
                    if (zombieID == 2 && Input.GetKey(KeyCode.LeftAlt)) // checks to see if 2 has been assigned to zombieID and the Left Alt has been pressed.
                    {
                        zombieWalkingAndGrab.Play("ZombieWalkingAndGrab");
                        transform.Translate(0, 0, 5f * Time.deltaTime); // This changes the position of the GameObject to a new vector (Player Two)
                                                                        //StartCoroutine(ReturnToPosition()); // This calls the Ienumorator to return the positions of the game objects
                    }
                    else if (Input.GetKeyUp(KeyCode.LeftAlt))
                    {
                        zombieWalkingAndGrab.Stop("ZombieWalkingAndGrab");
                        transform.position = new Vector3(26, 0.1f, -18.5f); // This changes the position of the GameObject to a new vector(Player Two)
                    }
                }
                    break; // This breaks out of this current case.


                case 3: // This is the first if statment assigned a case number of 3
                if (canPlayerMove)
                {
                    if (zombieID == 3 && Input.GetKey(KeyCode.RightAlt)) // checks to see if 3 has been assigned to zombieID and the Rigth Alt has been pressed.
                    {
                        zombieWalkingAndGrab.Play("ZombieWalkingAndGrab");
                        transform.Translate(0, 0, 5f * Time.deltaTime); // This changes the position of the GameObject to a new vector (Player Three)
                                                                        //StartCoroutine(ReturnToPosition()); // This calls the Ienumorator to return the positions of the game objects
                    }
                    else if (Input.GetKeyUp(KeyCode.RightAlt))
                    {
                        zombieWalkingAndGrab.Stop("ZombieWalkingAndGrab");
                        transform.position = new Vector3(33.5f, 0.1f, -20.5f); // This changes the position of the GameObject to a new vector(Player Three)
                    }
                }
                    break; // This breaks out of this current case.

                case 4: // This is the first if statment assigned a case number of 4
                if (canPlayerMove)
                {
                    if (zombieID == 4 && Input.GetKey(KeyCode.RightControl)) // checks to see if 4 has been assigned to zombieID and the Right control has been pressed.
                    {
                        zombieWalkingAndGrab.Play("ZombieWalkingAndGrab");
                        transform.Translate(0, 0, 5f * Time.deltaTime); // This changes the position of the GameObject to a new vector (Player Four)
                                                                        //StartCoroutine(ReturnToPosition()); // This calls the Ienumorator to return the positions of the game objects
                    }
                    else if (Input.GetKeyUp(KeyCode.RightControl))
                    {
                        zombieWalkingAndGrab.Stop("ZombieWalkingAndGrab");
                        transform.position = new Vector3(33.5f, 0.1f, -18.5f); // This changes the position of the GameObject to a new vector(Player Four)
                    }
                }
                    break; // This breaks out of this current case.
            }
        
    }
    #endregion

   

}
