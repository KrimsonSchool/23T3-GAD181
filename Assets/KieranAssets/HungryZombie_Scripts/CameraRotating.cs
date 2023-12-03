using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraRotating : MonoBehaviour
{
    public float speedOfCamera;

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(0, speedOfCamera * Time.deltaTime, 0);
    }
}
