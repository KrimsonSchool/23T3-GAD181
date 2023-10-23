using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EscapePod : MonoBehaviour
{
    public PlayerMovement playerMovement;
    public GameObject uiPlayerOneWinPrompt;
    public GameObject uiPlayerTwoWinPrompt;
    public GameObject uiPlayerThreeWinPrompt;
    public GameObject uiPlayerFourWinPrompt;
    // Start is called before the first frame update
    void Start()
    {
        uiPlayerOneWinPrompt.SetActive(false);
        uiPlayerTwoWinPrompt.SetActive(false);
        uiPlayerThreeWinPrompt.SetActive(false);
        uiPlayerFourWinPrompt.SetActive(false);
    }
    private void OnTriggerEnter(Collider Player)
    {
       // check to see which player has won       
        if (Player.tag == "PlayerOne")
        {
            Debug.Log("Player One Wins");
            uiPlayerOneWinPrompt.SetActive(true);
            StartCoroutine(PlayerOneWinner());
        }

        if (Player.tag == "PlayerTwo")
        {
            Debug.Log("Player Two Wins");
            uiPlayerTwoWinPrompt.SetActive(true);
            StartCoroutine(PlayerTwoWinner());
        }

        if (Player.tag == "PlayerThree")
        {
            Debug.Log("Player Three Wins");
            uiPlayerThreeWinPrompt.SetActive(true);
            StartCoroutine(PlayerThreeWinner());            
        }

        if (Player.tag == "PlayerFour")
        {
            Debug.Log("Player Four Wins");
            uiPlayerFourWinPrompt.SetActive(true);
            StartCoroutine(PlayerFourWinner());
        }
        // disable movement of all characters
        playerMovement.enabled = false;
    }

    public IEnumerator PlayerOneWinner()
    {
        yield return new WaitForSeconds(10f);
        uiPlayerOneWinPrompt.SetActive(false);
    }

    public IEnumerator PlayerTwoWinner()
    {
        yield return new WaitForSeconds(10f);
        uiPlayerTwoWinPrompt.SetActive(false);
    }

    public IEnumerator PlayerThreeWinner()
    {
        yield return new WaitForSeconds(10f);
        uiPlayerThreeWinPrompt.SetActive(false);
    }

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
