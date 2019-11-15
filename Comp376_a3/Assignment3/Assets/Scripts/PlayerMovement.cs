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

    bool isGrounded;
   // bool contactWithBar;
   // bool contactWithCoins;
    public bool isSwimming = false;

    public Transform SpawnPoint, Player;
    public Transform groundCheck;
   // public Transform goldBar;
   // public Transform goldCoins;

    public LayerMask groundMask;
   // public LayerMask goldMask;

    Vector3 velocity;

    

    void Start()
    {
        speed -= PlayerStats.weightSpeed;
        PlayerStats.maxOxygen = 50;
        PlayerStats.currentOxygen = PlayerStats.maxOxygen;
        PlayerStats.maxLife = 2;
        PlayerStats.currentLife = PlayerStats.maxLife;
        //controller = GetComponent<CharacterController>();
        /*SpawnPoint = GameObject.Find("SpawnPoint").transform;
        Player = GameObject.Find("FirstPersonPlayer").transform;*/
    }

    void Update()
    {
        //Check ground
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);
        //contactWithBar = Physics.CheckSphere(controller.transform.position, 1.0f, goldMask);

        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }

      /*  if (contactWithBar)
        {
            Debug.Log("Made contact with gold!");
        }*/

        //Check Life
        if (PlayerStats.currentLife <= 0.0)
        {
            Player.transform.position = SpawnPoint.transform.position;
            //controller.GetComponent<CharacterController>().enabled = false;
            //controller.transform.position = new Vector3(854.25f, 41.82f, 411.0f);
            // controller.transform.rotation = newPosition.rotation;
            //controller.GetComponent<CharacterController>().enabled = true;
            //velocity.y = -2f;
            //transform.position = PlayerStats.startingLocation;
            // controller.Move(velocity);
            resetGame();
        }

        void resetGame()
        {
            //transform.position = PlayerStats.startingLocation;
            PlayerStats.currentLife = PlayerStats.maxLife;
            PlayerStats.currentOxygen = PlayerStats.maxOxygen;
            PlayerStats.currentLevel = PlayerStats.startingLevel;
            PlayerStats.currentPoints = PlayerStats.startingPoints;
        }
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
            speed = 5.0f - PlayerStats.weightSpeed;
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

