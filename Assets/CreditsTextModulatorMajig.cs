using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreditsTextModulatorMajig : MonoBehaviour
{
    public TMPro.TextMeshProUGUI creditsText;
    public string[] names;
    public Color[] colours;
    string[] clrs;
    // Start is called before the first frame update
    void Start()
    {
        clrs = new string[colours.Length];

        for (int i = 0; i < colours.Length; i++)
        {
            clrs[i] = ColorUtility.ToHtmlStringRGB(colours[i]);
        }
    }

    // Update is called once per frame
    void Update()
    {
        creditsText.text = "<color=red> Problematic Times </color> © 2023 | Created by ";
        for (int i = 0;i < names.Length;i++)
        {
            creditsText.text += "<color=#" + clrs[i] + ">" + names[i] + "</color>, ";
        }
    }
}
