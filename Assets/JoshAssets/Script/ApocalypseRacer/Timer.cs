using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Timer : MonoBehaviour
{
    public float timeRemaining;
    public bool isTimerRunning = true;
    public TextMeshProUGUI countdown;

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
                countdown.enabled = false;
                Debug.Log("The game is over!");
                timeRemaining = 0;
                isTimerRunning = false;
            }
        }
    }

    public void UpdateTimer(float remainingTime)
    {

        countdown.text = Mathf.RoundToInt(remainingTime).ToString();
    }

}


