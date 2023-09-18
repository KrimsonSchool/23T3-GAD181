using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float speed;
    public float rotSpeed;
    Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        //transform.position += transform.forward * Input.GetAxis("Vertical") * speed * Time.deltaTime;

        rb.AddForce(transform.forward * Input.GetAxis("Vertical") * speed * Time.deltaTime);

        transform.Rotate(transform.up, Input.GetAxis("Horizontal") * rotSpeed * Time.deltaTime);
    }
}
