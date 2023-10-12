using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Playercontroller : MonoBehaviour
{
    public BrainsScript foodAccess;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        PickUpButton();


    }

    void PickUpButton()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            if (foodAccess.FoodAmount >= 1 && foodAccess.FoodAmount <= 10)
            {
                foodAccess.FoodAmount -= 1;
                Debug.Log("KEEP EATING!!!");
            }
            else if (foodAccess.FoodAmount == 0)
            {
                Debug.Log("All food is eaten");
            }
        }
    }
}
