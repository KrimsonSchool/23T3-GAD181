using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    #region References and score placeholder

    // Create some refernece points.
    // This is for texts UI
    // And a script reference
    public Playercontroller[] players;
    public int noOfPlayers;

    public TextMeshProUGUI playerOnesScore; //This is a text reference to player ones score text.
    public TextMeshProUGUI playerTwosScore; //This is a text reference to player twos score text.
    public TextMeshProUGUI playerThreesScore; //This is a text reference to player three score text.
    public TextMeshProUGUI playerFoursScore; //This is a text reference to player fours score text.
    public TextMeshProUGUI Winner;
    public Image controlsUI;
    
    
    public GameObject playerOneFood; // This is a reference to the gameObject in the scene of playerOnesfood
    public GameObject playerTwoFood; // This is a reference to the gameObject in the scene of playerTwosfood
    public GameObject playerThreeFood; // This is a reference to the gameObject in the scene of playerThreesfood
    public GameObject playerFourFood; // This is a reference to the gameObject in the scene of playerFoursfood
    [SerializeField] private BrainsScript foodUpdate01; // A reference to the brainscript that gets the burger 1 attached in the scene
    [SerializeField] private BrainsScript foodUpdate02; // A reference to the brainscript that gets the burger 2 attached in the scene
    [SerializeField] private BrainsScript foodUpdate03; // A reference to the brainscript that gets the burger 3 attached in the scene
    [SerializeField] private BrainsScript foodUpdate04; // A reference to the brainscript that gets the burger 4 attached in the scene
    public TimerManager timer; // A reference to the TimerManager
    public AudioSource spaceShipAlarm; // Access to the audioSource assigned in the scene.


    // Create some Ints to hold the score
    // This should be for each player.

    public int oneScore = 0; // This is a placeholder for player ones points to update the text.
    public int twoScore = 0; // This is a placeholder for player twos points to update the text.
    public int threeScore = 0; // This is a placeholder for player threes points to update the text.
    public int fourScore = 0; // This is a placeholder for player four4s points to update the text.

    public bool isGameReady = false; // sets a bool to false for isGameReady
    public bool canPlayerMove = false; // sets a bool to false for canPlayerMove
    

    public bool playerOneWin = false; // sets a bool to false for playerOneWin
    public bool playerTwoWin = false; // sets a bool to false for playerTwoWin
    public bool playerThreeWin = false; // sets a bool to false for playerThreeWin
    public bool playerFourWin = false; // sets a bool to false for playerFourWin

    #endregion

    #region Start Function
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

        spaceShipAlarm.Play(); // playes the audiosource spaceshipalarm on start.
        controlsUI.enabled = true; // This sets the Image source to true in the scene on start.
        Winner.enabled = false; // This sets the winner text false on start until called later.
        playerOnesScore.text = oneScore.ToString(); // This sets the players scores to 0
        playerTwosScore.text = twoScore.ToString(); // This sets the players scores to 0
        playerThreesScore.text = threeScore.ToString(); // This sets the players scores to 0
        playerFoursScore.text = fourScore.ToString(); // This sets the players scores to 0
        StartCoroutine(WaitForGameReady()); // This calls a IEnumator at the start of the scene 
        PlayerPrefs.GetInt("Players"); // This sets the amount of players in the game.

    }
    #endregion

    #region GameReadying Timer

    /*
     * Create a timer of 10 seconds
     * This should pause all interaction with the game
     * This should enable and disable some images and text
     */
    IEnumerator WaitForGameReady() // A unity function to hold time conditions under the name WaitForGameReady
    {
        yield return new WaitForSeconds(10f); // This will wait for 10 seconds before executing the following code.
        
        canPlayerMove = true; // A bool set to true
        timer.isTimerOn = true; // A bool set to true
        controlsUI.enabled = false; // A bool set to false
        


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
        else if(playerTwoWin == true) // Checks if the playerTwoWin bool is set true
        {
            PlayerPrefs.SetInt("player2Score", PlayerPrefs.GetInt("player2Score") + 50); // Increase the players score in the mainmenu by 50
        }
        else if(playerThreeWin == true) // Checks if the playerThreeWin bool is set true
        {
            PlayerPrefs.SetInt("player3Score", PlayerPrefs.GetInt("player3Score") + 50); // Increase the players score in the mainmenu by 50
        }
        else if(playerFourWin == true) // Checks if the playerFourWin bool is set true
        {
            PlayerPrefs.SetInt("player4Score", PlayerPrefs.GetInt("player4Score") + 50); // Increase the players score in the mainmenu by 50
        }
        SceneManager.LoadScene("GamePick"); // Access the scenemanager and loads the game pick scene.

    }
    #endregion

    #region Update function
    // Update is called once per frame
    void Update()
    {
       // UpdateScoreText();
        GameWinDecider();
    }
    #endregion

    #region Player scoring

    // Creater a function to update player scores when they have eaten their item.
    // This should increase by 1 point.
    // It will be based on the food health value and if it has reacehd 0.

    public void UpdateScoreTextOne() // A function to update player ones score
    {
        oneScore += 1; // Increase the player ones score by 1
        playerOnesScore.text = oneScore.ToString(); // Converst the score to a string and updates the UI text to dispaly it.
    }
    public void UpdateScoreTextTwo() // A function to update player twos score
    {
        twoScore += 1; // Increase the player twos score by 1
        playerTwosScore.text = twoScore.ToString(); // Converst the score to a string and updates the UI text to dispaly it.
    }
    public void UpdateScoreTextThree() // A function to update player threes score
    {
        threeScore += 1; // Increase the player threes score by 1
        playerThreesScore.text = threeScore.ToString(); // Converst the score to a string and updates the UI text to dispaly it.
    }
    public void UpdateScoreTextFour() // A function to update player fours score
    {
        fourScore += 1; // Increase the player fours score by 1
        playerFoursScore.text = fourScore.ToString(); // Converst the score to a string and updates the UI text to dispaly it.
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
        if(timer.remainingTime == 0) // checking if the timer is equal to 0.
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
            canPlayerMove = false; // Disables players movements after a player has won.
            timer.isTimerOn = false; // Disables the timers
            StartCoroutine(WaitToFinishGame()); // Calls a coroutine of waitToFinishGame to finish the game.

        }
       

    }
    #endregion

}
