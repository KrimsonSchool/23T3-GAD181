using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectingItems : MonoBehaviour
{
    public int itemsCollected;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Item"))
        {
            itemsCollected += 1;
            other.gameObject.SetActive(false);
        }
    }
}
