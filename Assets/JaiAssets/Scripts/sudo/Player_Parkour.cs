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
        //finds an assignes the rigidbody component to rb
        rb = GetComponent<Rigidbody>();
        //sets the cursor to be invisible and locked to the center of the screen
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;

        //find and assignes the camera component to cam
        cam = GetComponentInChildren<Camera>();

        //find and assignes the ParKon component to parKon
        parKon = FindAnyObjectByType<ParKon>();

        //sets the cam's rect to be 0,0,0,0
        cam.rect = new Rect(0, 0, 0, 0);
    }

    // Update is called once per frame
    void Update()
    {
        //the players velocity is set to the players forward vector timesed by the the forward input plus the players rightward vector timesed by the right input
        rb.velocity = (transform.forward * Input.GetAxis("Vertical " + playerNo) * speed) + (transform.right * Input.GetAxis("Horizontal "+playerNo)) * speed + new Vector3(0, rb.velocity.y, 0);

        //if the player presses the jump key and they can jump then
        if (Input.GetKeyDown(parKon.jumpInput[playerNo]) && canJump)
        {
            //the players y velocity is set so that they move upward
            rb.velocity += new Vector3(0, speed/2, 0);
            //set canJump to be false
            canJump = false;
        }

        //if won is true then
        if (won)
        {
            //set the players position to the helicopters position
            transform.position = heli.transform.position;
        }

        //if the players forward input isnt 0 or the players rightward input isnt 0 then
        if(Input.GetAxis("Vertical " + playerNo) != 0 || Input.GetAxis("Horizontal " + playerNo) != 0)
        {
            //stop the playback of the animation
            playerObj.GetComponent<Animator>().StopPlayback();
        }
        //if not then
        else
        {
            //start the playback of the animation
            playerObj.GetComponent<Animator>().StartPlayback();
        }
    }

    public void SetCams()
    {
        //set speed to 10
        speed = 10;
        print(name);

        //if cam exists then
        if(cam!= null)
        {
            //if playerNo is 0 then
            if (playerNo == 0)
            {
                //set the cam rect to the top left corner
                cam.rect = new Rect(0, 0.5f, 0.5f, 0.5f);
            }
            //if playerNo is 1 then 
            else if (playerNo == 1)
            {
                //set the cam rect to the top right corner
                cam.rect = new Rect(0.5f, 0.5f, 0.5f, 0.5f);
            }
            //if player no is 2 then
            else if (playerNo == 2)
            {
                //set the cam rect to the bottom left corner
                cam.rect = new Rect(0, 0, 0.5f, 0.5f);
            }
            //else then
            else
            {
                //set the cam rect to the bottom right corner
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
