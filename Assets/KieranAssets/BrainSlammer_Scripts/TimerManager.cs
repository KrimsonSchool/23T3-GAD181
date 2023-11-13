using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TimerManager : MonoBehaviour
{
    #region Classes and references

    public float remainingTime; // This holds a float under remainingTime with no value
    public bool isTimerOn = false; // This holds a false bool under isTimerOn
    public TextMeshProUGUI timerText; // This is reference to textMeshPro
    public AudioSource startGameSound; // This is a reference to a AudioSource
    public AudioSource spaceShipSound; // This is a reference to a AudioSource
    #endregion

    #region Update
    // Update is called once per frame
    void Update()
    {
        if (isTimerOn) // This checks if the timer is true
        {
            if (remainingTime > 0) // This checks if the timer has a remainingTime greate than 0
            {
                remainingTime -= Time.deltaTime; // This takesaway from the remainingTime by 1 second in realtime
                UpdateGameTimer(remainingTime); // This calls the updateGameTimer with the value of reaminingTime
                spaceShipSound.Play(); // This plays the background spaceship sound
            }
            else // This checks if there is anything else other than the previous condition
            {
                Debug.Log("The game is finished!!"); // A debug log
                remainingTime = 0; // remianining time is set to 0
                isTimerOn = false; // isTimerOn is set to false to stop the timer
                startGameSound.Play(); // This plays an assigned sound
                timerText.enabled = false; // This Disables the timer text when  it reaches 0
            }
        }
    }
    #endregion

    #region UpdateGameTimer function

    public void UpdateGameTimer(float remainingTime) // This is a function to update the timer with a float
    {  
        timerText.text = Mathf.RoundToInt(remainingTime).ToString(); // This calculates the remaininf time and converts into a int and a string to be displayed.
    }
    #endregion
}
