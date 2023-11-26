using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class HungryZombiesManager : MonoBehaviour
{
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
    public TimerManager timer;
    public TextMeshProUGUI goalText;
    public TextMeshProUGUI timerText;
    public Image controlsUI;
    public AudioSource introSound;
    public AudioSource alarmSonar; // This is a reference to a AudioSource

    public int oneScore = 0; // This is a placeholder for player ones points to update the text.
    public int twoScore = 0; // This is a placeholder for player twos points to update the text.
    public int threeScore = 0; // This is a placeholder for player threes points to update the text.
    public int fourScore = 0; // This is a placeholder for player four4s points to update the text.

    public bool canHumansSpawn = false;

    // Start is called before the first frame update
    void Start()
    {
        introSound.Play();
        StartCoroutine(WaitForCameraMovement());
        playerOnesScore.text = oneScore.ToString(); // This sets the players scores to 0
        playerTwosScore.text = twoScore.ToString(); // This sets the players scores to 0
        playerThreesScore.text = threeScore.ToString(); // This sets the players scores to 0
        playerFoursScore.text = fourScore.ToString(); // This sets the players scores to 0
        InvokeRepeating("SpawnHuman", 1, 3);
    }

    private void Update()
    {
        
    }

    IEnumerator WaitForCameraMovement()
    {
        yield return new WaitForSeconds(10f);
        Kieran_startingMarine.SetActive(false);
        introCamera.SetActive(false);
        mainCamera.SetActive(true);
        controlsUI.enabled = true;
        goalText.enabled = true; // A bool set to false
        timerText.enabled = true;
        playerOne.ReturnZombiesToReadyPosiiton();
        playerTwo.ReturnZombiesToReadyPosiiton();
        playerThree.ReturnZombiesToReadyPosiiton();
        playerFour.ReturnZombiesToReadyPosiiton();
        StartCoroutine(WaitForGameReady());
    }

    IEnumerator WaitForGameReady() // A unity function to hold time conditions under the name WaitForGameReady
    {
        yield return new WaitForSeconds(10f); // This will wait for 10 seconds before executing the following code.

        playerOne.canPlayerMove = true; // A bool set to true
        playerTwo.canPlayerMove = true;
        playerThree.canPlayerMove = true;
        playerFour.canPlayerMove = true;
        canHumansSpawn = true;
        timer.isTimerOn = true; // A bool set to true
        controlsUI.enabled = false; // A bool set to false
        goalText.enabled = false; // A bool set to false
        timerText.enabled = false; // A bool set to false
        introSound.Stop();
        alarmSonar.Play();

    }


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
