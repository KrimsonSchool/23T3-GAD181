using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieStat : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

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
