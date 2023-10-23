using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuManager : MonoBehaviour
{
    public Slider noOfRoundsSlider;
    public TMPro.TextMeshProUGUI noOfRoundsText;
    int noOfRounds;
    // Start is called before the first frame update
    void Start()
    {
        noOfRoundsSlider.Select();
    }

    // Update is called once per frame
    void Update()
    {
        noOfRounds = Mathf.RoundToInt(noOfRoundsSlider.value);
        noOfRoundsText.text = ""+noOfRounds;
    }

    public void StartGame()
    {
        PlayerPrefs.SetInt("NoOfRounds", noOfRounds);
        SceneManager.LoadScene(1);
    }

    public void Quit()
    {
        Application.Quit();
    }
}
