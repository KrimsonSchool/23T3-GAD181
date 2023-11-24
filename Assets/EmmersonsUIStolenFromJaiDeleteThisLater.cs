using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class EmmersonsUIStolenFromJaiDeleteThisLater : MonoBehaviour
{
    public Slider roundsSlider;
    public TMPro.TextMeshProUGUI sliderText;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        sliderText.text = ""+ roundsSlider.value;
    }

    public void TwoPlayer()
    {
        PlayerPrefs.SetInt("Players", 2);
    }
    public void ThreePlayer()
    {
        PlayerPrefs.SetInt("Players", 3);

    }
    public void FourPlayer()
    {
        PlayerPrefs.SetInt("Players", 4);

    }

    public void Play()
    {
        PlayerPrefs.SetInt("NoOfRounds", Mathf.RoundToInt(roundsSlider.value) + 1);
        SceneManager.LoadScene("GamePick");
    }
}
