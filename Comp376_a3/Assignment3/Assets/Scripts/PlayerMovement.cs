using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController controller;

    public float speed = 12f;
    public float gravity = -9.81f;
    public float jumpHeight = 2f;
    public float groundDistance = 0.4f;
    public bool isSwimming = false;
    public Transform groundCheck;
    public LayerMask groundMask;

    Vector3 velocity;

    bool isGrounded;

    void Start()
    {
        PlayerStats.maxOxygen = 50;
        PlayerStats.currentOxygen = PlayerStats.maxOxygen;
        PlayerStats.maxLife = 2;
        PlayerStats.currentLife = PlayerStats.maxLife;
    }

    void Update()
    {
        //Check ground
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }

   /*     //Check Life
        if (PlayerStats.currentLife <= 0.0)
        {
            transform.position = PlayerStats.startingLocation;
            resetGame();
        }
*/
   /*     void resetGame()
        {
            transform.position = PlayerStats.startingLocation;
            PlayerStats.currentLife = PlayerStats.maxLife;
            PlayerStats.currentOxygen = PlayerStats.maxOxygen;
            PlayerStats.currentLevel = PlayerStats.startingLevel;
            PlayerStats.currentPoints = PlayerStats.startingPoints;
        } */   
        //Oxygen bar
        if (transform.position.y >= 35f)
        {
            PlayerStats.currentOxygen = PlayerStats.maxOxygen;
        }
        if (transform.position.y < 35f)
        {
            PlayerStats.currentOxygen -= Time.deltaTime;
        }

        //Moving + Swimming
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 move = transform.right * x + transform.forward * z;

        controller.Move(move * speed * Time.deltaTime);

        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2 * gravity);
        }
        if (Input.GetButton("Jump") && isSwimming)
        {
            speed = 5.0f;
            gravity = -3f;
            if ((Input.GetButton("Horizontal") || Input.GetButton("Vertical")) && transform.position.y >= 35f)
            {
                jumpHeight = 0.0f;
            }
            if ((!Input.GetButton("Horizontal") && !Input.GetButton("Vertical") && !Input.GetButton("Jump")) || transform.position.y < 35f)
            {
                jumpHeight = 3.0f;
            }
            if (transform.position.y > 35f)
            {
                jumpHeight = 0.0f;
            }
            velocity.y = Mathf.Sqrt(jumpHeight * -2 * gravity);
        }

        velocity.y += gravity * Time.deltaTime;

        controller.Move(velocity * Time.deltaTime);
    }
}
