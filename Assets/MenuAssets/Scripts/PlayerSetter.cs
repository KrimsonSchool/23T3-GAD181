using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerSetter : MonoBehaviour
{
    
    public TextMeshProUGUI player2Name;
    public TextMeshProUGUI player2Score;

    public TextMeshProUGUI player3Name;
    public TextMeshProUGUI player3Score;

    public TextMeshProUGUI player4Name;
    public TextMeshProUGUI player4Score;

    private Color greyedOut;

    // Start is called before the first frame update
    void Start()
    {
        greyedOut = new Color(.45f, .45f, .45f, .1f);
        if (PlayerPrefs.GetInt("Players") == 1)
        {
            player2Name.color = greyedOut;
            player2Score.color = greyedOut;

            player3Name.color = greyedOut;
            player3Score.color = greyedOut;

            player4Name.color = greyedOut;
            player4Score.color = greyedOut;
        }

        if (PlayerPrefs.GetInt("Players") == 2)
        {
            player3Name.color = greyedOut;
            player3Score.color = greyedOut;

            player4Name.color = greyedOut;
            player4Score.color = greyedOut;
        }

        if (PlayerPrefs.GetInt("Players") == 3)
        {
            player4Name.color = greyedOut;
            player4Score.color = greyedOut;
        }












    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
