using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CureMakerGameManager : MonoBehaviour
{

    public int noCollected;
    public PlayerMovement playerOneMovement;
    public PlayerMovement playerTwoMovement;
    public PlayerMovement playerThreeMovement;
    public PlayerMovement playerFourMovement;
    public GameObject uiWinPrompt;
    public CollectingItems[] players;
    public GameObject uiPlayerOneWinPrompt;
    public GameObject uiPlayerTwoWinPrompt;
    public GameObject uiPlayerThreeWinPrompt;
    public GameObject uiPlayerFourWinPrompt;
    float timer;  
    public int dead;
    public int playersAlive;
    public GameObject gameOver;
    public AudioSource levelCompleteSound;
    public AudioSource gameOverSound;
    public AudioClip clipToPlay;

    // Start is called before the first frame update
    void Start()
    {
        uiWinPrompt.SetActive(false);
        uiPlayerOneWinPrompt.SetActive(false);
        uiPlayerTwoWinPrompt.SetActive(false);
        uiPlayerThreeWinPrompt.SetActive(false);
        uiPlayerFourWinPrompt.SetActive(false);
        gameOver.SetActive(false);
        playersAlive = PlayerPrefs.GetInt("Players");      
        for (int i = 0; i < players.Length; i++)
        {
            players[i].GetComponent<Health>().id = i;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(dead >= playersAlive)
        {
            gameOver.SetActive(true);
            timer += Time.deltaTime;
            if (timer > 5)
            {
                SceneManager.LoadScene("GamePick");
            }
        }

        if (noCollected >= 9)
        {
            
            playerOneMovement.enabled = false;
            playerTwoMovement.enabled = false;
            playerThreeMovement.enabled = false;
            playerFourMovement.enabled = false;
            uiWinPrompt.SetActive(true);

            CheckWinner();
        }       
        if (playersAlive == 0)
        {            
            gameOver.SetActive(true);
            StartCoroutine(GameOver());
        }

         IEnumerator GameOver()
         {
            gameOverSound.Play();
            yield return new WaitForSeconds(3f);
            gameOver.SetActive(false);
            SceneManager.LoadScene("GamePick");
         }
    }

    public void CheckWinner()
    {
        int highest = 0;
        int winningPlayer = 0;
        for (int i = 0; i < PlayerPrefs.GetInt("Players"); i++)
        {
            if (players[i].itemsCollected > highest)
            {
                highest = players[i].itemsCollected;
                winningPlayer = i;
            }
        }

        Debug.Log(players[winningPlayer].name);
        if (players[winningPlayer].tag == "PlayerOne")
        {
            Debug.Log("Player One Wins");
            levelCompleteSound.Play();
            uiPlayerOneWinPrompt.SetActive(true);
            timer += Time.deltaTime;
            if (timer > 5)
            {
                PlayerPrefs.SetInt("player1Score", PlayerPrefs.GetInt("player1Score") + 50);
                SceneManager.LoadScene("GamePick");
            }        
            
        }
        if (players[winningPlayer].tag == "PlayerTwo")
        {
            Debug.Log("Player Two Wins");
            levelCompleteSound.Play();
            uiPlayerTwoWinPrompt.SetActive(true);
            timer += Time.deltaTime;
            if (timer > 5)
            {
                PlayerPrefs.SetInt("player2Score", PlayerPrefs.GetInt("player2Score") + 50);
                SceneManager.LoadScene("GamePick");
            }
            

        }
        if (players[winningPlayer].tag == "PlayerThree")
        {
            Debug.Log("Player Three Wins");
            levelCompleteSound.Play();
            uiPlayerThreeWinPrompt.SetActive(true);
            timer += Time.deltaTime;
            if (timer > 5)
            {
                PlayerPrefs.SetInt("player3Score", PlayerPrefs.GetInt("player3Score") + 50);
                SceneManager.LoadScene("GamePick");
            }
           

        }
        if (players[winningPlayer].tag == "PlayerFour")
        {
            Debug.Log("Player Four Wins");
            levelCompleteSound.Play();
            uiPlayerFourWinPrompt.SetActive(true);
            timer += Time.deltaTime;
            if (timer > 5)
            {
                PlayerPrefs.SetInt("player4Score", PlayerPrefs.GetInt("player4Score") + 50);
                SceneManager.LoadScene("GamePick");
            }

        }
    }
}
