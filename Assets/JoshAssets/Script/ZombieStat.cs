using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ZombieStat : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // when a zombie enters a trigger of something with the player health component then remove 100 health from it.
    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<PlayerHealth>())
        {
            other.GetComponent<PlayerHealth>().health -= 100;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
