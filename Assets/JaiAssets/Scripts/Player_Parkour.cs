using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player_Parkour : MonoBehaviour
{
    public int playerNo;
    public GameObject playerObj;
    Rigidbody rb;

    bool won;
    GameObject heli;
    bool canJump;
    Camera cam;
    ParKon parKon;

    float speed;

    bool hax;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        cam = GetComponentInChildren<Camera>();

        parKon = FindAnyObjectByType<ParKon>();

        cam.rect = new Rect(0, 0, 0, 0);
    }

    // Update is called once per frame
    void Update()
    {
        rb.velocity = (transform.forward * Input.GetAxis("Vertical " + playerNo) * speed) + (transform.right * Input.GetAxis("Horizontal "+playerNo)) * speed + new Vector3(0, rb.velocity.y, 0);

        if (Input.GetKeyDown(parKon.jumpInput[playerNo]) && canJump)
        {
            //jump
            rb.velocity += new Vector3(0, speed/2, 0);
            canJump = false;
        }

        if (won)
        {
            transform.position = heli.transform.position;
        }

        if(Input.GetAxis("Vertical " + playerNo) != 0 || Input.GetAxis("Horizontal " + playerNo) != 0)
        {
            playerObj.GetComponent<Animator>().StopPlayback();
        }
        else
        {
            playerObj.GetComponent<Animator>().StartPlayback();
        }

        if(Input.GetKeyDown(KeyCode.Q)&&playerNo==0)
        {
            hax = true;
        }
        if (hax)
        {
            canJump = true;
        }
    }

    public void SetCams()
    {
        speed = 10;
        print(name);
        if(cam!= null)
        {
            if (playerNo == 0)
            {
                cam.rect = new Rect(0, 0.5f, 0.5f, 0.5f);
            }
            else if (playerNo == 1)
            {
                cam.rect = new Rect(0.5f, 0.5f, 0.5f, 0.5f);
            }
            else if (playerNo == 2)
            {
                cam.rect = new Rect(0, 0, 0.5f, 0.5f);
            }
            else
            {
                cam.rect = new Rect(0.5f, 0, 0.5f, 0.5f);
            }
        }
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Respawn")
        {
            print("Dead");
            Die();
        }
        else if(other.tag == "Checkpoint")
        {
            other.GetComponent<Goal>().Win();
            heli = other.GetComponent<Goal>().an.gameObject;
            playerObj.SetActive(false);
            GetComponentInChildren<Camera>().fieldOfView = 120;
            won = true;

            FindAnyObjectByType<helicopter>().winningPlayer = playerNo;
        }
        else if(other.tag == "Enemy")
        {
            other.GetComponent<AnimateMat>().alt = true;
        }
        else
        {
            canJump = true;
        }
    }
    /*float maths = Mathf.Sqrt(Random.Range(10000000, 99999999999));
            maths = Mathf.Sqrt(Random.Range(10000000, 99999999999));
            maths = Mathf.Sqrt(Random.Range(10000000, 99999999999));
            maths = Mathf.Sqrt(Random.Range(10000000, 99999999999));*/
    public void Die()
    {
        Instantiate(parKon.playerRagdoll, transform.position, transform.rotation);

        transform.position = new Vector3(0, 1.6f, 0);
    }
}
