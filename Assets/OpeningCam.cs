using System.Collections;
using System.Collections.Generic;
using Unity.Burst;
using Unity.VisualScripting;
using UnityEngine;

public class OpeningCam : MonoBehaviour
{
    public GameObject[] thingsToTrigger;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OpeniningDone()
    {
        for (int i = 0; i < thingsToTrigger.Length; i++)
        {
            //NOTE: Attempt to make modular (assign script and function to select?)
            if (thingsToTrigger[i] != null)
            {
                thingsToTrigger[i].GetComponent<Player_Parkour>().SetCams();
            }
        }
    }
}
