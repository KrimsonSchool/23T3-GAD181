using System.Collections;
using System.Collections.Generic;
using UnityEngine;
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

    }
    public void ThreePlayer()
    {

    }
    public void FourPlayer()
    {

    }
}
