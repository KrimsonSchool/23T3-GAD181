using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Timer : MonoBehaviour
{
    public float timeRemaining;
    public bool isTimerRunning = true;
    public TextMeshProUGUI Countdown;

    // Update is called once per frame
    void Update()
    {
        if (isTimerRunning)
        {
            if (timeRemaining > 0)
            {
                timeRemaining -= Time.deltaTime;
                UpdateTimer(timeRemaining);
            }
            else
            {
                Debug.Log("The game is over!");
                timeRemaining = 0;
                isTimerRunning = false;
            }
        }
    }

    public void UpdateTimer(float remainingTime)
    {

        Countdown.text = Mathf.RoundToInt(remainingTime).ToString();
    }

}


