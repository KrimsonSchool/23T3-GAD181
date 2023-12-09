using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreditsTextModulatorMajig : MonoBehaviour
{
    public TMPro.TextMeshProUGUI creditsText;
    public string[] names;
    public Color[] colours;
    public Color[] coloursB;
    string[] clrs;
    public float changePeriod;
    bool crnt;
    float tmr;
    // Start is called before the first frame update
    void Start()
    {
        clrs = new string[colours.Length];
        colourChange();
    }

    // Update is called once per frame
    void Update()
    {
        tmr += Time.deltaTime;

        if(tmr > changePeriod)
        {
            colourChange();
            tmr = 0;
        }
    }

    public void colourChange()
    {
        for (int i = 0; i < colours.Length; i++)
        {
            if (crnt)
            {
                clrs[i] = ColorUtility.ToHtmlStringRGB(coloursB[i]);
            }
            else
            {
                clrs[i] = ColorUtility.ToHtmlStringRGB(colours[i]);

            }
        }

        creditsText.text = "<color=red> Problematic Times </color> © 2023 | Created by ";
        for (int i = 0; i < names.Length; i++)
        {
            creditsText.text += "<color=#" + clrs[i] + ">" + names[i] + "</color>, ";
        }

        crnt=!crnt;
    }
}
