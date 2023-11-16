using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Parkour : MonoBehaviour
{
    Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (rb.velocity.z < 10 && rb.velocity.z > -10)
        {
            rb.AddRelativeForce(transform.forward * Input.GetAxis("Vertical") * 10);
        }
        if (rb.velocity.x < 10 && rb.velocity.x > -10)
        {
            rb.AddRelativeForce(transform.right * Input.GetAxis("Horizontal") * 10);
        }

        if (Input.GetKey(KeyCode.LeftControl))
        {
            rb.velocity = new Vector3(0, rb.velocity.y, 0);
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            //jump
        }
    }
}
