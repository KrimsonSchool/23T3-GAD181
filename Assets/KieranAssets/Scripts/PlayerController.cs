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
        if(foodAccess.brainID == 1 && Input.GetKeyDown(KeyCode.LeftControl))
        {
            
            if (foodAccess.foodAmount >= 1 && foodAccess.foodAmount <= 10)
            {
                foodAccess.foodAmount -= 1;
                Debug.Log("KEEP EATING!!!");
            }
            else if (foodAccess.foodAmount == 0)
            {
                Debug.Log("All food is eaten");
            }
        }
        if (foodAccess.brainID == 2 && Input.GetKeyDown(KeyCode.LeftAlt))
        {
            if (foodAccess.foodAmount >= 1 && foodAccess.foodAmount <= 10)
            {
                foodAccess.foodAmount -= 1;
                Debug.Log("KEEP EATING!!!");
            }
            else if (foodAccess.foodAmount == 0)
            {
                Debug.Log("All food is eaten");
            }
        }
        if (foodAccess.brainID == 3 && Input.GetKeyDown(KeyCode.RightAlt))
        {
            if (foodAccess.foodAmount >= 1 && foodAccess.foodAmount <= 10)
            {
                foodAccess.foodAmount -= 1;
                Debug.Log("KEEP EATING!!!");
            }
            else if (foodAccess.foodAmount == 0)
            {
                Debug.Log("All food is eaten");
            }
        }
        if (foodAccess.brainID == 4 && Input.GetKeyDown(KeyCode.RightControl))
        {
            if (foodAccess.foodAmount >= 1 && foodAccess.foodAmount <= 10)
            {
                foodAccess.foodAmount -= 1;
                Debug.Log("KEEP EATING!!!");
            }
            else if (foodAccess.foodAmount == 0)
            {
                Debug.Log("All food is eaten");
            }
        }

    }
}
