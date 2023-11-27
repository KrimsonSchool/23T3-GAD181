using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaitToStart : MonoBehaviour
{

    public PlayerMovement playerOneMovement;
    public PlayerMovement playerTwoMovement;
    public PlayerMovement playerThreeMovement;
    public PlayerMovement playerFourMovement;
    public GameObject backgroundUI;

    // Start is called before the first frame update
    void Start()
    {
        playerOneMovement.enabled = false;
        playerTwoMovement.enabled = false;
        playerThreeMovement.enabled = false;
        playerFourMovement.enabled = false;
        backgroundUI.SetActive(true);
      
        StartCoroutine(PlayerCanMove());
    }

    public IEnumerator PlayerCanMove()
    {
        yield return new WaitForSeconds(15f);
        playerOneMovement.enabled = true;
        playerTwoMovement.enabled = true;
        playerThreeMovement.enabled = true;
        playerFourMovement.enabled = true;
        backgroundUI.SetActive(false);
    }

}

