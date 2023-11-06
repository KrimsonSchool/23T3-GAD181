using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EscapePod : MonoBehaviour
{
    public PlayerMovement playerOneMovement;
    public PlayerMovement playerTwoMovement;
    public PlayerMovement playerThreeMovement;
    public PlayerMovement playerFourMovement;
    public GameObject uiPlayerOneWinPrompt;
    public GameObject uiPlayerTwoWinPrompt;
    public GameObject uiPlayerThreeWinPrompt;
    public GameObject uiPlayerFourWinPrompt;
    // Start is called before the first frame update
    void Start()
    {
        playerOneMovement.enabled = false;
        playerTwoMovement.enabled = false;
        playerThreeMovement.enabled = false;
        playerFourMovement.enabled = false;
        uiPlayerOneWinPrompt.SetActive(false);
        uiPlayerTwoWinPrompt.SetActive(false);
        uiPlayerThreeWinPrompt.SetActive(false);
        uiPlayerFourWinPrompt.SetActive(false);
        StartCoroutine(PlayerCanMove());
    }

    public IEnumerator PlayerCanMove()
    {
        yield return new WaitForSeconds(5f);
        playerOneMovement.enabled = true;
        playerTwoMovement.enabled = true;
        playerThreeMovement.enabled = true;
        playerFourMovement.enabled = true;
    }

        private void OnTriggerEnter(Collider Player)
    {
        // check to see which player has won       
        // If something with the tag "PlayerOne" enters the trigger then Player One wins and all players movement is disabled
        if (Player.tag == "PlayerOne")
        {
            Debug.Log("Player One Wins");
            uiPlayerOneWinPrompt.SetActive(true);
            playerTwoMovement.enabled = false;
            playerThreeMovement.enabled = false;
            playerFourMovement.enabled = false;
            StartCoroutine(PlayerOneWinner());
        }

        // If something with the tag "PlayerTwo" enters the trigger then Player Two wins and all players movement is disabled
        if (Player.tag == "PlayerTwo")
        {
            Debug.Log("Player Two Wins");
            uiPlayerTwoWinPrompt.SetActive(true);
            playerOneMovement.enabled = false;
            playerThreeMovement.enabled = false;
            playerFourMovement.enabled = false;
            StartCoroutine(PlayerTwoWinner());
        }

        // If something with the tag "PlayerThree" enters the trigger then Player Three wins and all players movement is disabled
        if (Player.tag == "PlayerThree")
        {
            Debug.Log("Player Three Wins");
            uiPlayerThreeWinPrompt.SetActive(true);
            playerOneMovement.enabled = false;
            playerTwoMovement.enabled = false;
            playerFourMovement.enabled = false;
            StartCoroutine(PlayerThreeWinner());            
        }
        
        // If something with the tag "PlayerFour" enters the trigger then Player Four wins and all players movement is disabled
        if (Player.tag == "PlayerFour")
        {
            Debug.Log("Player Four Wins");
            uiPlayerFourWinPrompt.SetActive(true);
            playerOneMovement.enabled = false;
            playerTwoMovement.enabled = false;
            playerThreeMovement.enabled = false;
            StartCoroutine(PlayerFourWinner());
        }
        
        
    }

    // display text that Player One Wins
    public IEnumerator PlayerOneWinner()
    {
        yield return new WaitForSeconds(10f);
        uiPlayerOneWinPrompt.SetActive(false);
    }

    // display text that Player Two Wins
    public IEnumerator PlayerTwoWinner()
    {
        yield return new WaitForSeconds(10f);
        uiPlayerTwoWinPrompt.SetActive(false);
    }

    // display text that Player Three Wins
    public IEnumerator PlayerThreeWinner()
    {
        yield return new WaitForSeconds(10f);
        uiPlayerThreeWinPrompt.SetActive(false);
    }

    // display text that Player Four Wins
    public IEnumerator PlayerFourWinner()
    {
        yield return new WaitForSeconds(10f);
        uiPlayerFourWinPrompt.SetActive(false);
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
