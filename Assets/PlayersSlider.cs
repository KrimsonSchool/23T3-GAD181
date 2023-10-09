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
        
    }

    // Update is called once per frame
    void Update()
    {
        players.text = "Players: " + GetComponent<Slider>().value;
    }
}
