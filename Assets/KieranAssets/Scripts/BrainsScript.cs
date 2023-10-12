using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrainsScript : MonoBehaviour
{
    public GameObject playerOneFood;
    public GameObject playerTwoFood;
    public GameObject playerThreeFood;
    public GameObject playerFourFood;
    public int FoodAmountOne = 10;
    public bool isFoodEaten = false;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        if(FoodAmountOne == 0 && isFoodEaten)
        {
            
            playerOneFood.SetActive(false);
            Debug.Log("Food transfer");
            FoodAmountOne += 10;
            playerOneFood.SetActive(true);
            Debug.Log("Food Delivered");
            isFoodEaten = true;
        }

        if(isFoodEaten == true)
        {
            isFoodEaten = false;
            
        }
        
    }
}
