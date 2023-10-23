using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public GameObject[] Players;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // make camera be in the position average of all players 
        if (PlayerPrefs.GetInt("Players") == 1)
        {
            transform.position = ((Players[0].transform.position)) + new Vector3(0, 17, -25);
        }
        else if (PlayerPrefs.GetInt("Players") == 2)
        {
            transform.position = ((Players[0].transform.position + Players[1].transform.position) / 2) + new Vector3(0, 17, -25);
        }
        else if (PlayerPrefs.GetInt("Players") == 3)
        {
            transform.position = ((Players[0].transform.position + Players[1].transform.position + Players[2].transform.position) / 3) + new Vector3(0, 17, -25);
        }
        else
        {
            transform.position = ((Players[0].transform.position + Players[1].transform.position + Players[2].transform.position + Players[3].transform.position) / 4) + new Vector3(0, 17, -25);
        }
        
    }
}
