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

    //public KeyCode[] forwardKey;
    //public KeyCode[] backwardKey;
    //public KeyCode[] rightKey;
    //public KeyCode[] leftKey;

    bool canMove;

    public int cp;

    TMPro.TextMeshProUGUI mPro;

    public Camera cam;

    gManager manager;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();

        mPro = FindObjectOfType<TMPro.TextMeshProUGUI>();

        manager = FindAnyObjectByType<gManager>();

        if(manager.noOfPlayers == 1 )
        {
            cam.rect = new Rect(0, 0, 1, 1);
        }
        else if(manager.noOfPlayers == 2)
        {
            if(playerNo == 0 )
            {
                cam.rect = new Rect(0, 0, 0.5f, 1);
            }
            else
            {
                cam.rect = new Rect(0.5f, 0, 0.5f, 1);
            }
        }
        else if(manager.noOfPlayers == 3)
        {
            if(playerNo == 0)
            {
                cam.rect = new Rect(0, 0.5f, 0.5f, 0.5f);
            }
            else if (playerNo == 1)
            {
                cam.rect = new Rect(0.5f, 0.5f, 0.5f, 0.5f);
            }
            else
            {
                cam.rect = new Rect(0, 0, 0.5f, 0.5f);
            }
        }
        else if (manager.noOfPlayers == 4)
        {
            if (playerNo == 0)
            {
                cam.rect = new Rect(0, 0.5f, 0.5f, 0.5f);
            }
            else if (playerNo == 1)
            {
                cam.rect = new Rect(0.5f, 0.5f, 0.5f, 0.5f);
            }
            else if(playerNo == 2)
            {
                cam.rect = new Rect(0, 0, 0.5f, 0.5f);
            }
            else if (playerNo == 3)
            {
                cam.rect = new Rect(0.5f, 0, 0.5f, 0.5f);
            }
        }
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


        forwardV = Input.GetAxis("Vertical " + playerNo);
        rightwardV += Input.GetAxis("Horizontal " + playerNo);

        Mathf.Clamp(rightwardV, -1, 1);

        rightwardV = Mathf.Lerp(rightwardV, 0, Time.deltaTime * 7.5f);
        
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
