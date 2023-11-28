using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class HungryZombiesManager : MonoBehaviour
{
    public MiniGameTwoPlayerController[] players;
    public int noOfPlayers;

    public TextMeshProUGUI playerOnesScore; //This is a text reference to player ones score text.
    public TextMeshProUGUI playerTwosScore; //This is a text reference to player twos score text.
    public TextMeshProUGUI playerThreesScore; //This is a text reference to player three score text.
    public TextMeshProUGUI playerFoursScore; //This is a text reference to player fours score text.

    public GameObject Kieran_humanToSpawn;
    public GameObject Kieran_humanToSpawnTwo;
    public GameObject Kieran_startingMarine;
    public GameObject introCamera;
    public GameObject mainCamera;
    public MiniGameTwoPlayerController playerOne;
    public MiniGameTwoPlayerController playerTwo;
    public MiniGameTwoPlayerController playerThree;
    public MiniGameTwoPlayerController playerFour;
    public TextMeshProUGUI Winner;
    public TimerManager timer;
    public TextMeshProUGUI goalText;
    public TextMeshProUGUI extraText;
    public TextMeshProUGUI timerText;
    public Image controlsUI;
    public AudioSource introSound;
    public AudioSource alarmSonar; // This is a reference to a AudioSource

    public int oneScore = 0; // This is a placeholder for player ones points to update the text.
    public int twoScore = 0; // This is a placeholder for player twos points to update the text.
    public int threeScore = 0; // This is a placeholder for player threes points to update the text.
    public int fourScore = 0; // This is a placeholder for player four4s points to update the text.

    public bool canHumansSpawn = false;
    public bool playerOneWin = false; // sets a bool to false for playerOneWin
    public bool playerTwoWin = false; // sets a bool to false for playerTwoWin
    public bool playerThreeWin = false; // sets a bool to false for playerThreeWin
    public bool playerFourWin = false; // sets a bool to false for playerFourWin


    #region Start

    // Start is called before the first frame update
    void Start()
    {
        noOfPlayers = PlayerPrefs.GetInt("Players");

        //for every player that were selected,
        for (int i = 0; i < noOfPlayers; i++)
        {
            //enable that players car
            players[i].gameObject.SetActive(true);
        }

        introSound.Play();
        StartCoroutine(WaitForCameraMovement());
        playerOnesScore.text = oneScore.ToString(); // This sets the players scores to 0
        playerTwosScore.text = twoScore.ToString(); // This sets the players scores to 0
        playerThreesScore.text = threeScore.ToString(); // This sets the players scores to 0
        playerFoursScore.text = fourScore.ToString(); // This sets the players scores to 0
        InvokeRepeating("SpawnHuman", 1, 3);
    }

    #endregion

    #region Update

    private void Update()
    {
        GameWinDecider();
    }

    #endregion

    #region Winning
    /*
     * Create a function to decide teh winner
     * This should be based of the timer hitting 0 
     * as well which player has the highest score
     */
    public void GameWinDecider() // A function to decide the winner
    {
        if (timer.remainingTime == 0) // checking if the timer is equal to 0.
        {
            if (oneScore > twoScore && oneScore > threeScore && oneScore > fourScore) // checking if player One has a higher score than the rest
            {
                playerOneWin = true; // Sets the playerOneWin bool to true
                Debug.Log("Winner is player ONE!");
                Winner.enabled = true; // Sets the UI text to be dsiplayed on the screen
                Winner.text = oneScore.ToString("Player 1 Wins!"); // CHnages the winner text to Player 1 wins
            }
            else if (twoScore > oneScore && twoScore > threeScore && twoScore > fourScore) // checking if player Two has a higher score than the rest
            {
                playerTwoWin = true; // Sets the playerTwoWin bool to true
                Debug.Log("Winner is player TWO!");
                Winner.enabled = true; //Sets the UI text to be dsiplayed on the screen
                Winner.text = twoScore.ToString("Player 2 Wins!"); // CHnages the winner text to Player 1 wins
            }
            else if (threeScore > oneScore && threeScore > twoScore && threeScore > fourScore) // checking if player Three has a higher score than the rest
            {
                playerThreeWin = true; // Sets the playerThreeWin bool to true
                Debug.Log("Winner is player Three!");
                Winner.enabled = true;  // Sets the UI text to be dsiplayed on the screen
                Winner.text = threeScore.ToString("Player 3 Wins!"); // CHnages the winner text to Player 1 wins
            }
            else if (fourScore > oneScore && fourScore > twoScore && fourScore > threeScore) // checking if player Four has a higher score than the rest
            {
                playerFourWin = true; // Sets the playerFourWin bool to true
                Debug.Log("Winner is player Four!");
                Winner.enabled = true;  // Sets the UI text to be dsiplayed on the screen
                Winner.text = fourScore.ToString("Player 4 Wins!"); // CHnages the winner text to Player 1 wins
            }
            playerOne.canPlayerMove = false; // Disables players movements after a player has won.
            playerTwo.canPlayerMove = false; // Disables players movements after a player has won.
            playerThree.canPlayerMove = false; // Disables players movements after a player has won.
            playerFour.canPlayerMove = false; // Disables players movements after a player has won.
            timer.isTimerOn = false; // Disables the timers
            StartCoroutine(WaitToFinishGame()); // Calls a coroutine of waitToFinishGame to finish the game.

        }


    }
#endregion

    #region Wait for camera to stop

    IEnumerator WaitForCameraMovement()
    {
        yield return new WaitForSeconds(15f);
        Kieran_startingMarine.SetActive(false);
        introCamera.SetActive(false);
        mainCamera.SetActive(true);
        controlsUI.enabled = true;
        goalText.enabled = true; // A bool set to false
        extraText.enabled = true;
        timerText.enabled = true;
        playerOne.ReturnZombiesToReadyPosiiton();
        playerTwo.ReturnZombiesToReadyPosiiton();
        playerThree.ReturnZombiesToReadyPosiiton();
        playerFour.ReturnZombiesToReadyPosiiton();
        StartCoroutine(WaitForGameReady());
    }

    #endregion

    #region Waiting for Game ready

    IEnumerator WaitForGameReady() // A unity function to hold time conditions under the name WaitForGameReady
    {
        yield return new WaitForSeconds(15f); // This will wait for 10 seconds before executing the following code.

        playerOne.canPlayerMove = true; // A bool set to true
        playerTwo.canPlayerMove = true;
        playerThree.canPlayerMove = true;
        playerFour.canPlayerMove = true;
        canHumansSpawn = true;
        timer.isTimerOn = true; // A bool set to true
        controlsUI.enabled = false; // A bool set to false
        goalText.enabled = false; // A bool set to false
        extraText.enabled = false;
        timerText.enabled = false; // A bool set to false
        introSound.Stop();
        alarmSonar.Play();

    }

    #endregion

    #region Spawning Humans

    void SpawnHuman()
    {
        if (canHumansSpawn == true)
        {
           Vector3 randomPosition = new Vector3(Random.Range(27f, 32f), 0.1f, -26.5f);
           Vector3 otherRandomPosition = new Vector3(Random.Range(27f, 32f), 0.1f, -12f);
           

            Instantiate(Kieran_humanToSpawn, randomPosition, Quaternion.identity);
            Instantiate(Kieran_humanToSpawnTwo, otherRandomPosition, Quaternion.LookRotation(Vector3.back));
        }
    }
    #endregion

    #region WaitToFinishGame

    /*
     * Create a Timer for 1 second
     * This should allow for the player winning screen to display and execute some conditions in another scene
     */


    IEnumerator WaitToFinishGame() // A unity function to hold time conditions under the name WaitToFinishGame
    {
        yield return new WaitForSeconds(1f);  // This will wait for 1 seconds before executing the following code.
        if (playerOneWin == true) // Checks if the playerOneWin bool is set true
        {
            PlayerPrefs.SetInt("player1Score", PlayerPrefs.GetInt("player1Score") + 50); // Increase the players score in the mainmenu by 50
        }
        else if (playerTwoWin == true) // Checks if the playerTwoWin bool is set true
        {
            PlayerPrefs.SetInt("player2Score", PlayerPrefs.GetInt("player2Score") + 50); // Increase the players score in the mainmenu by 50
        }
        else if (playerThreeWin == true) // Checks if the playerThreeWin bool is set true
        {
            PlayerPrefs.SetInt("player3Score", PlayerPrefs.GetInt("player3Score") + 50); // Increase the players score in the mainmenu by 50
        }
        else if (playerFourWin == true) // Checks if the playerFourWin bool is set true
        {
            PlayerPrefs.SetInt("player4Score", PlayerPrefs.GetInt("player4Score") + 50); // Increase the players score in the mainmenu by 50
        }
        SceneManager.LoadScene("GamePick"); // Access the scenemanager and loads the game pick scene.

    }
    #endregion

    #region Player scoring

    // Creater a function to update player scores when they have eaten their item.
    // This should increase by 1 point.
    // It will be based on the food health value and if it has reacehd 0.


    public void UpdatePlayerOneScore()
    {
        if (playerOne.zombieID == 1)
        {
            oneScore += 1; // Increase the player ones score by 1
            playerOnesScore.text = oneScore.ToString(); // Converst the score to a string and updates the UI text to dispaly it.
            Debug.Log("Player one got a point");
        }
    }

    public void UpdatePlayerTwoScore()
    {

        if (playerTwo.zombieID == 2)
        {
            twoScore += 1; // Increase the player twos score by 1
            playerTwosScore.text = twoScore.ToString(); // Converst the score to a string and updates the UI text to dispaly it.
            Debug.Log("Player Two got a point");
        }
    }

    public void UpdatePlayerThreeScore()
    {
        if (playerThree.zombieID == 3)
        {
            threeScore += 1; // Increase the player threes score by 1
            playerThreesScore.text = threeScore.ToString(); // Converst the score to a string and updates the UI text to dispaly it.
            Debug.Log("Player Three got a point");
        }
    }

    public void UpdatePlayerFourScore()
    {
        if (playerFour.zombieID == 4)
        {
            fourScore += 1; // Increase the player fours score by 1
            playerFoursScore.text = fourScore.ToString(); // Converst the score to a string and updates the UI text to dispaly it.
            Debug.Log("Player Four got a point");
        }
    }

    #endregion

    

    
}
