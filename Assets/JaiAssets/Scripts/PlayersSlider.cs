using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayersSlider : MonoBehaviour
{
    public TMPro.TextMeshProUGUI players;
    // Start is called before the first frame update
    void Start()
    {
        //HAVE TO WORK ON JOYSTICK INPUT - REQUIRE JOYSTICK TESTS AT HOME
    }

    // Update is called once per frame
    void Update()
    {
        players.text = "Players: " + GetComponent<Slider>().value;
    }

    public void savePlayersNo()
    {
        PlayerPrefs.SetInt("Players", Mathf.RoundToInt(GetComponent<Slider>().value));
    }
}
