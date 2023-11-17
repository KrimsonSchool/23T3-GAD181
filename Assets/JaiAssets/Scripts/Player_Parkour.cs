using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player_Parkour : MonoBehaviour
{
    Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        rb.velocity = (transform.forward * Input.GetAxis("Vertical") * 10) + (transform.right * Input.GetAxis("Horizontal")) * 10 + new Vector3(0, rb.velocity.y, 0);

        if (Input.GetKey(KeyCode.LeftControl))
        {
            rb.velocity = new Vector3(0, rb.velocity.y, 0);
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            //jump
            rb.velocity += new Vector3(0, 5, 0);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Respawn")
        {
            print("Dead");
            transform.position = new Vector3(0, 1.6f, 0);
        }
    }
}
