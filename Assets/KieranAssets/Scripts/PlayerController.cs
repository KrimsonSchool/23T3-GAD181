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
        if(foodAccess.BrainID == 1 && Input.GetKeyDown(KeyCode.LeftControl))
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
        if (foodAccess.BrainID == 2 && Input.GetKeyDown(KeyCode.LeftAlt))
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
        if (foodAccess.BrainID == 3 && Input.GetKeyDown(KeyCode.RightAlt))
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
        if (foodAccess.BrainID == 4 && Input.GetKeyDown(KeyCode.RightControl))
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
