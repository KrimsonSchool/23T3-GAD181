using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EscapePod : MonoBehaviour
{
    public PlayerMovement playerMovement;
    public GameObject uiWinPrompt;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    private void OnTriggerEnter(Collider Player)
    {
       // check to see which player has won       
        if (Player.tag == "PlayerOne")
        {
            Debug.Log("Player One Wins");
        }

        if (Player.tag == "PlayerTwo")
        {
            Debug.Log("Player Two Wins");
        }

        if (Player.tag == "PlayerThree")
        {
            Debug.Log("Player Three Wins");
        }

        if (Player.tag == "PlayerFour")
        {
            Debug.Log("Player Four Wins");
        }
        // disable movement of all characters
        playerMovement.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
