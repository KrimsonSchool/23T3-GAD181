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
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        //transform.position += transform.forward * Input.GetAxis("Vertical") * speed * Time.deltaTime;
        rb.AddForce(transform.forward * forwardV * speed * Time.deltaTime);

        transform.Rotate(transform.up, rightwardV * rotSpeed * Time.deltaTime);



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
    }
}
