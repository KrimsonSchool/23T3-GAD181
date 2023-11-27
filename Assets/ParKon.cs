using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParKon : MonoBehaviour
{
    [HideInInspector] public KeyCode[] jumpInput;
    // Start is called before the first frame update
    void Start()
    {
        jumpInput[0] = KeyCode.LeftControl;
        jumpInput[1] = KeyCode.LeftAlt;
        jumpInput[2] = KeyCode.RightControl;
        jumpInput[3] = KeyCode.RightAlt;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
