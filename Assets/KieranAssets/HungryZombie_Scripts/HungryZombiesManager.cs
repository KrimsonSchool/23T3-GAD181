using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class HungryZombiesManager : MonoBehaviour
{
    public TextMeshProUGUI playerOnesScore; //This is a text reference to player ones score text.
    public TextMeshProUGUI playerTwosScore; //This is a text reference to player twos score text.
    public TextMeshProUGUI playerThreesScore; //This is a text reference to player three score text.
    public TextMeshProUGUI playerFoursScore; //This is a text reference to player fours score text.

    public GameObject Kieran_humanToSpawn;
    public GameObject Kieran_humanToSpawnTwo;
    public int oneScore = 0; // This is a placeholder for player ones points to update the text.
    public int twoScore = 0; // This is a placeholder for player twos points to update the text.
    public int threeScore = 0; // This is a placeholder for player threes points to update the text.
    public int fourScore = 0; // This is a placeholder for player four4s points to update the text.

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnHuman", 1, 3);
    }

    private void Update()
    {
        
    }

    void SpawnHuman()
    {
        Vector3 randomPosition = new Vector3(Random.Range(-1.54f, 1.794f), 1.2f, -4.5f);
        Vector3 otherRandomPosition = new Vector3(Random.Range(-1.54f, 1.794f), 1.2f, 10.5f);

        Instantiate(Kieran_humanToSpawn, randomPosition, Quaternion.identity);
        Instantiate(Kieran_humanToSpawnTwo, otherRandomPosition, Quaternion.identity);
    }

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

}
