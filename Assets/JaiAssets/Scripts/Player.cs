using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

public class Player : MonoBehaviour
{
    public int playerNo;
    public float speed;
    public float rotSpeed;
    public Rigidbody rb;

    float forwardV;
    float rightwardV;

    //public KeyCode[] forwardKey;
    //public KeyCode[] backwardKey;
    //public KeyCode[] rightKey;
    //public KeyCode[] leftKey;

    public bool canMove;

    public int cp;

    TMPro.TextMeshProUGUI mPro;

    public Camera cam;

    gManager manager;

    bool spinout;
    float spinTimer;

    public GameObject portalFX;
    // Start is called before the first frame update
    void Start()
    {
        //rb is set to the players rigidbody
        rb = GetComponent<Rigidbody>();

        //mPro is set to the UI Text
        mPro = FindObjectOfType<TMPro.TextMeshProUGUI>();

        //manager is set to the gManager
        manager = FindAnyObjectByType<gManager>();

        //if the number of players equals 1 then
        if(manager.noOfPlayers == 1 )
        {
            //set the game to fullscreen
            cam.rect = new Rect(0, 0, 1, 1);
        }
        //if the number of players is two then
        else if(manager.noOfPlayers == 2)
        {
            //if player is player 1 / 2
            if(playerNo == 0 )
            {
                //set the view of player 1 to the right half of the screen
                cam.rect = new Rect(0, 0, 0.5f, 1);
            }
            //if player is player 2 / 2 then
            else
            {
                //set the view to the right half of the screen
                cam.rect = new Rect(0.5f, 0, 0.5f, 1);
            }
        }
        //if there are 3 players then
        else if(manager.noOfPlayers == 3)
        {
            //if player 1 then
            if(playerNo == 0)
            {
                //set view to top left of screen
                cam.rect = new Rect(0, 0.5f, 0.5f, 0.5f);
            }
            //if player 2 then
            else if (playerNo == 1)
            {
                //set view to top right of screen
                cam.rect = new Rect(0.5f, 0.5f, 0.5f, 0.5f);
            }
            //if player 3 then
            else
            {
                //set view to bottom left of screen
                cam.rect = new Rect(0, 0, 0.5f, 0.5f);
            }
        }
        //if there are 4 players then
        else if (manager.noOfPlayers == 4)
        {
            //if player 1 then
            if (playerNo == 0)
            {
                //set view to top left of screen
                cam.rect = new Rect(0, 0.5f, 0.5f, 0.5f);
            }
            //if player 2 then
            else if (playerNo == 1)
            {
                //set view to top right of screen
                cam.rect = new Rect(0.5f, 0.5f, 0.5f, 0.5f);
            }
            //if player 3 then
            else if (playerNo == 2)
            {
                //set view to bottom left of screen
                cam.rect = new Rect(0, 0, 0.5f, 0.5f);
            }
            //if player 4 then
            else if (playerNo == 3)
            {
                //set view to bottom right of screen
                cam.rect = new Rect(0.5f, 0, 0.5f, 0.5f);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        //if the boolean spinout is true then
        if (spinout)
        {
            //spin timer counts up by seconds
            spinTimer += Time.deltaTime;

            //rotate the player counter clockwise
            transform.Rotate(transform.up, -360 * Time.deltaTime, 0);

            //if spinTimer is greater or equal to 2 then
            if (spinTimer >= 2)
            {
                //set spinout to be false
                spinout = false;
                //set that the player can move
                canMove = true;
                //reset spinTimer
                spinTimer = 0;
            }
        }

        //if the boolean canMove is true then
        if (canMove)
        {
            //add a force to the player rigidbody equivelent to the player forwardV timed by the players speed
            rb.AddForce(transform.forward * forwardV * speed * Time.deltaTime);

            //rotate the player based on the player rightwardV timesed by the players rotSpeed
            transform.Rotate(transform.up, rightwardV * rotSpeed * Time.deltaTime);
        }

        //set the players forwardV to equal the amout the player is pushing their vertical keys (W and S for player one etc.)
        forwardV = Input.GetAxis("Vertical " + playerNo);
        //set the players rightwardV to equal the amout the player is pushing their horizontal keys (A and D for player one etc.)
        rightwardV = Input.GetAxis("Horizontal " + playerNo);
        
        //if the players FOV is less than 90 then
        if(GetComponentInChildren<Camera>().fieldOfView < 90)
        {
            //increase the players FOV by how fast they are going
            GetComponentInChildren<Camera>().fieldOfView += rb.velocity.magnitude / 250;
        }

        //if the players FOV is greater than 60 then
        if(GetComponentInChildren<Camera>().fieldOfView > 60)
        {
            //decay the player FOV by 0.1
            GetComponentInChildren<Camera>().fieldOfView -= 0.1f;
        }

        //if cp is equal to 5
        if(cp == 5)
        {
            //call the managers function noMove
            manager.noMove();

            //set the text to display who won
            mPro.text = "Player " + (playerNo + 1) + " wins!!!";

            //set cp to 0
            cp = 0;
            //call the managers win function passing in the winning player
            manager.win(playerNo+1);
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

                portalFX.SetActive(true);
                portalFX.gameObject.GetComponent<LifeTimer>().timer = 0;
            }
        }

        if(other.tag == "Enemy")
        {
            print("spinout");
            canMove = false;
            spinout = true;
        }
    }
}
