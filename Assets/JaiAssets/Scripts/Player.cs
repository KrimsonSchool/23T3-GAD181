using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public int playerNo;
    public float speed;
    public float rotSpeed;
    Rigidbody rb;

    float forwardV;
    float rightwardV;

    public KeyCode[] forwardKey;
    public KeyCode[] backwardKey;
    public KeyCode[] rightKey;
    public KeyCode[] leftKey;

    bool canMove;

    public int cp;

    TMPro.TextMeshProUGUI mPro;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();

        mPro = FindObjectOfType<TMPro.TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        //transform.position += transform.forward * Input.GetAxis("Vertical") * speed * Time.deltaTime;
       if(canMove)
        {
            rb.AddForce(transform.forward * forwardV * speed * Time.deltaTime);

            transform.Rotate(transform.up, rightwardV * rotSpeed * Time.deltaTime);
        }



        if (Input.GetKey(forwardKey[playerNo]))
        {
            forwardV = 1;
        }
        else if (Input.GetKey(backwardKey[playerNo]))
        {
            forwardV = -1;
        }
        else
        {
            forwardV = 0;
        }

        if (Input.GetKey(rightKey[playerNo]))
        {
            rightwardV = 1;
        }
        else if (Input.GetKey(leftKey[playerNo]))
        {
            rightwardV = -1;
        }
        else
        {
            rightwardV = 0;
        }

        
        if(GetComponentInChildren<Camera>().fieldOfView < 90)
        {
            GetComponentInChildren<Camera>().fieldOfView += rb.velocity.magnitude / 250;
        }

        if(GetComponentInChildren<Camera>().fieldOfView > 60)
        {
            GetComponentInChildren<Camera>().fieldOfView -= 0.1f;
        }

        if(cp == 5)
        {
            Time.timeScale = 0;

            mPro.text = "Player " + (playerNo + 1) + " wins!!!";
        }
    }

    public void move()
    {
        canMove = true;
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Checkpoint")
        {
            if(other.GetComponent<Checkpoint>().no == cp+1)
            {
                cp += 1;
            }
        }
    }
}
