using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    public Slider roundsSlider;
    public TMPro.TextMeshProUGUI sliderText;

    Animator animator;
    bool start;
    float tmr;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        //sets the slider text to show how many rounds has been selected
        sliderText.text = ""+ roundsSlider.value;

        if (start)
        {
            tmr += Time.deltaTime;

            if (tmr > 1) {

                SceneManager.LoadScene("GamePick");
            }
        }
    }
    //function called when player clicks 1 player
    public void OnePlayer()
    {
        //sets the amount of players playing to 1
        PlayerPrefs.SetInt("Players", 1);
    }

    //function called when player clicks 2 players
    public void TwoPlayer()
    {
        //sets the amount of players playing to 2
        PlayerPrefs.SetInt("Players", 2);
    }
    //function called when player clicks 3 players

    public void ThreePlayer()
    {   
        //sets the amount of players playing to 3
        PlayerPrefs.SetInt("Players", 3);
    }
    //function called when player clicks 4 players
    public void FourPlayer()
    {
        //sets the amount of players playing to 4
        PlayerPrefs.SetInt("Players", 4);
    }

    //function called when player clicks the Play button
    public void Play()
    {
        //set the number of rounds to be the selected amount
        PlayerPrefs.SetInt("NoOfRounds", Mathf.RoundToInt(roundsSlider.value) + 1);
        //loads the game pick menu
        animator.enabled = true;
        start = true;
    }
}
