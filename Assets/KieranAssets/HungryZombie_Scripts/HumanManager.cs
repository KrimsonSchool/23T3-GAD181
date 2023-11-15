using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HumanManager : MonoBehaviour
{
    public HungryZombiesManager zombiesManager;
    public int humanID = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        switch (humanID)
        {
            case 1:
            transform.Translate(0, 0, 5f * Time.deltaTime);
            

                break;

            case 2:
                transform.Translate(0, 0, -5f * Time.deltaTime);


                break;
        }

    }
}
