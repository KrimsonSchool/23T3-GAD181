using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Playercontroller : MonoBehaviour
{
    public BrainsScript foodAccess;
    public GameManager gameManager;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (gameManager.canPlayerMove == true)
        {
            PickUpButton();
        }


    }

    void PickUpButton()
    {
        if(Input.GetKeyDown(KeyCode.LeftControl))
        {
            
            if (foodAccess.FoodAmountOne >= 1 && foodAccess.FoodAmountOne <= 10)
            {
                foodAccess.FoodAmountOne -= 1;
                Debug.Log("KEEP EATING!!!");
            }
            else if (foodAccess.FoodAmountOne == 0)
            {
                Debug.Log("All food is eaten");
            }
        }
        if (Input.GetKeyDown(KeyCode.LeftAlt))
        {
            if (foodAccess.FoodAmountTwo >= 1 && foodAccess.FoodAmountTwo <= 10)
            {
                foodAccess.FoodAmountTwo -= 1;
                Debug.Log("KEEP EATING!!!");
            }
            else if (foodAccess.FoodAmountTwo == 0)
            {
                Debug.Log("All food is eaten");
            }
        }
        if (Input.GetKeyDown(KeyCode.RightAlt))
        {
            if (foodAccess.FoodAmountThree >= 1 && foodAccess.FoodAmountThree <= 10)
            {
                foodAccess.FoodAmountThree -= 1;
                Debug.Log("KEEP EATING!!!");
            }
            else if (foodAccess.FoodAmountThree == 0)
            {
                Debug.Log("All food is eaten");
            }
        }
        if (Input.GetKeyDown(KeyCode.RightControl))
        {
            if (foodAccess.FoodAmountFour >= 1 && foodAccess.FoodAmountFour <= 10)
            {
                foodAccess.FoodAmountFour -= 1;
                Debug.Log("KEEP EATING!!!");
            }
            else if (foodAccess.FoodAmountFour == 0)
            {
                Debug.Log("All food is eaten");
            }
        }

    }
}
