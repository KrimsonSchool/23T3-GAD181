using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrainsScript : MonoBehaviour
{
    public GameObject playerFood;
    public int FoodAmount = 10;
    public bool isFoodEaten = false;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        if(FoodAmount == 0 && isFoodEaten)
        {
            
            playerFood.SetActive(false);
            Debug.Log("Food transfer");
            FoodAmount += 10;
            playerFood.SetActive(true);
            Debug.Log("Food Delivered");
            isFoodEaten = true;
        }

        if(isFoodEaten == true)
        {
            isFoodEaten = false;
            
        }
        
    }
}
