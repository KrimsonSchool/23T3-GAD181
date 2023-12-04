using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    // INSTRUCTIONS
    // This script must be on an object that has a Character Controller component.
    // It will add this component if the object does not already have it.
    //    This is done by line 4: "[RequireComponent(typeof(CharacterController))]"
    //
    // Also, make a camera a child of this object and tilt it the way you want it to tilt.
    // The mouse will let you turn the object, and therefore, the camera.

    // These variables (visible in the inspector) are for you to set up to match the right feel
    public float speed = 12f;
    public float speedH = 2.0f;
    public float speedV = 2.0f;
    public float yaw = 0.0f;
    public float pitch = 0.0f;
    public Animation PlayerAnimate;

    // This must be linked to the object that has the "Character Controller" in the inspector. You may need to add this component to the object
    public CharacterController controller;
    private Vector3 velocity;

    // Customisable gravity
    public float gravity = -20f;

    // Tells the script how far to keep the object off the ground
    public float groundDistance = 0.2f;

    // So the script knows if you can jump!
    private bool isGrounded;

    // How high the player can jump
    public float jumpHeight = 2f;

    private void Start()
    {
        // If the variable "controller" is empty...
        
        if (controller == null)
        {
            // ...then this searches the components on the gameobject and gets a reference to the CharacterController class
            controller = GetComponent<CharacterController>();
            
        }
    }    
    private void Update()
    {
        RunAnimation();

        if (gameObject.tag == "PlayerOne")
        {
            // Get the Left/Right and Forward/Back values of the input being used (WASD, Joystick etc.)
            float x = Input.GetAxis("Horizontal 0");
            float z = Input.GetAxis("Vertical 0");
            // Let the player jump if they are on the ground and they press the jump button
            if (Input.GetButtonDown("Jump") && isGrounded)
            {
                velocity.y = Mathf.Sqrt(jumpHeight * -2 * gravity);
            }

            // Rotate the player based off those mouse values we collected earlier
            // transform.eulerAngles = new Vector3(0.0f, yaw, 0.0f);

            // This is stealing the data about the player being on the ground from the character controller
            isGrounded = controller.isGrounded;

            if (isGrounded && velocity.y < 0)
            {
                velocity.y = -2f;
            }

            // This fakes gravity!
            velocity.y += gravity * Time.deltaTime;

            // This takes the Left/Right and Forward/Back values to build a vector
            Vector3 move = transform.right * x + transform.forward * z;

            // Finally, it applies that vector it just made to the character
            controller.Move(move * speed * Time.deltaTime + velocity * Time.deltaTime);
        }

        if (gameObject.tag == "PlayerTwo")
        {
            // Get the Left/Right and Forward/Back values of the input being used (WASD, Joystick etc.)
            float x = Input.GetAxis("Horizontal 1");
            float z = Input.GetAxis("Vertical 1");
            // Let the player jump if they are on the ground and they press the jump button
            if (Input.GetButtonDown("Jump") && isGrounded)
            {
                velocity.y = Mathf.Sqrt(jumpHeight * -2 * gravity);
            }

            // Rotate the player based off those mouse values we collected earlier
            // transform.eulerAngles = new Vector3(0.0f, yaw, 0.0f);

            // This is stealing the data about the player being on the ground from the character controller
            isGrounded = controller.isGrounded;

            if (isGrounded && velocity.y < 0)
            {
                velocity.y = -2f;
            }

            // This fakes gravity!
            velocity.y += gravity * Time.deltaTime;

            // This takes the Left/Right and Forward/Back values to build a vector
            Vector3 move = transform.right * x + transform.forward * z;

            // Finally, it applies that vector it just made to the character
            controller.Move(move * speed * Time.deltaTime + velocity * Time.deltaTime);
        }

        if (gameObject.tag == "PlayerThree")
        {
            // Get the Left/Right and Forward/Back values of the input being used (WASD, Joystick etc.)
            float x = Input.GetAxis("Horizontal 2");
            float z = Input.GetAxis("Vertical 2");
            // Let the player jump if they are on the ground and they press the jump button
            if (Input.GetButtonDown("Jump") && isGrounded)
            {
                velocity.y = Mathf.Sqrt(jumpHeight * -2 * gravity);
            }

            // Rotate the player based off those mouse values we collected earlier
            // transform.eulerAngles = new Vector3(0.0f, yaw, 0.0f);

            // This is stealing the data about the player being on the ground from the character controller
            isGrounded = controller.isGrounded;

            if (isGrounded && velocity.y < 0)
            {
                velocity.y = -2f;
            }

            // This fakes gravity!
            velocity.y += gravity * Time.deltaTime;

            // This takes the Left/Right and Forward/Back values to build a vector
            Vector3 move = transform.right * x + transform.forward * z;

            // Finally, it applies that vector it just made to the character
            controller.Move(move * speed * Time.deltaTime + velocity * Time.deltaTime);
        }

        if (gameObject.tag == "PlayerFour")
        {
            // Get the Left/Right and Forward/Back values of the input being used (WASD, Joystick etc.)
            float x = Input.GetAxis("Horizontal 3");
            float z = Input.GetAxis("Vertical 3");
            // Let the player jump if they are on the ground and they press the jump button
            if (Input.GetButtonDown("Jump") && isGrounded)
            {
                velocity.y = Mathf.Sqrt(jumpHeight * -2 * gravity);
            }

            // Rotate the player based off those mouse values we collected earlier
            // transform.eulerAngles = new Vector3(0.0f, yaw, 0.0f);

            // This is stealing the data about the player being on the ground from the character controller
            isGrounded = controller.isGrounded;

            if (isGrounded && velocity.y < 0)
            {
                velocity.y = -2f;
            }

            // This fakes gravity!
            velocity.y += gravity * Time.deltaTime;

            // This takes the Left/Right and Forward/Back values to build a vector
            Vector3 move = transform.right * x + transform.forward * z;

            // Finally, it applies that vector it just made to the character
            controller.Move(move * speed * Time.deltaTime + velocity * Time.deltaTime);
        }
    }
    
    void RunAnimation()
    {
        if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.D))
        {
            PlayerAnimate.Play();
        }
        else if (Input.GetKeyUp(KeyCode.W) || Input.GetKeyUp (KeyCode.A) || Input.GetKeyUp (KeyCode.S) || Input.GetKeyUp(KeyCode.D))
        {
            PlayerAnimate.Stop();
        }
        if (Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.DownArrow) || Input.GetKeyDown(KeyCode.RightArrow))
        {
            PlayerAnimate.Play();
        }
        else if (Input.GetKeyUp(KeyCode.UpArrow) || Input.GetKeyUp(KeyCode.LeftArrow) || Input.GetKeyUp(KeyCode.DownArrow) || Input.GetKeyUp(KeyCode.RightArrow))
        {
            PlayerAnimate.Stop();
        }
        if (Input.GetKeyDown(KeyCode.Y) || Input.GetKeyDown(KeyCode.G) || Input.GetKeyDown(KeyCode.H) || Input.GetKeyDown(KeyCode.J))
        {
            PlayerAnimate.Play();
        }
        else if (Input.GetKeyUp(KeyCode.Y) || Input.GetKeyUp(KeyCode.G) || Input.GetKeyUp(KeyCode.H) || Input.GetKeyUp(KeyCode.J))
        {
            
            PlayerAnimate.Stop();
        }
        if (Input.GetKeyDown(KeyCode.P) || Input.GetKeyDown(KeyCode.L) || Input.GetKeyDown(KeyCode.Semicolon) || Input.GetKeyDown(KeyCode.Quote))
        {
            
            PlayerAnimate.Play();
        }
        else if (Input.GetKeyUp(KeyCode.P) || Input.GetKeyUp(KeyCode.L) || Input.GetKeyUp(KeyCode.Semicolon) || Input.GetKeyUp(KeyCode.Quote))
        {
            PlayerAnimate.Stop();
        }
    }
}


