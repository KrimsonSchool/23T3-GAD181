using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TimerManager : MonoBehaviour
{

    public float remainingTime;
    public bool isTimerOn = false;
    public TextMeshProUGUI timerText;

    // Start is called before the first frame update
    void Start()
    {
   
    }

    // Update is called once per frame
    void Update()
    {

        if (isTimerOn)
        {
            if (remainingTime > 0)
            {
                remainingTime -= Time.deltaTime;
                UpdateGameTimer(remainingTime);
            }
            else
            {
                Debug.Log("The game is finished!!");
                remainingTime = 0;
                isTimerOn = false;

            }
        }

    }

    public void UpdateGameTimer(float remainingTime)
    {
        
        timerText.text = Mathf.RoundToInt(remainingTime).ToString();
    }

}
