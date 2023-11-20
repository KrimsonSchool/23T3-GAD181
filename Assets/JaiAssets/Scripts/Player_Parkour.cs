using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player_Parkour : MonoBehaviour
{
    public GameObject playerObj;
    Rigidbody rb;

    bool won;
    GameObject heli;
    bool canJump;
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
        if (Input.GetKeyDown(KeyCode.Space) && canJump)
        {
            //jump
            rb.velocity += new Vector3(0, 5, 0);
            canJump = false;
        }

        if (won)
        {
            transform.position = heli.transform.position;
        }

        if(Input.GetAxis("Vertical") != 0 || Input.GetAxis("Horizontal") != 0)
        {
            playerObj.GetComponent<Animator>().StopPlayback();
        }
        else
        {
            playerObj.GetComponent<Animator>().StartPlayback();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Respawn")
        {
            print("Dead");
            transform.position = new Vector3(0, 1.6f, 0);
        }
        else if(other.tag == "Checkpoint")
        {
            other.GetComponent<Goal>().Win();
            heli = other.GetComponent<Goal>().an.gameObject;
            playerObj.SetActive(false);
            GetComponentInChildren<Camera>().fieldOfView = 120;
            won = true;
        }
        else
        {
            canJump = true;
        }
    }
}
