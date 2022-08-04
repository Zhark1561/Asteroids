using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D body;
    private bool thrusting;
    private float turnDirection;


    [SerializeField] private float thrustSpeed = 1f;
    [SerializeField] private float turnSpeed = 1f;

    [SerializeField] private GameObject thrust;


    void Awake()
    {
        body = GetComponent<Rigidbody2D>();
    }

    
    void Update()
    {
        thrusting = Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow);

        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            turnDirection = 1f;
        }
        else if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            turnDirection = -1f;
        }
        else
        {
            turnDirection = 0;
        }

    }

    private void FixedUpdate()
    {
        if (thrusting)
        {
            body.AddForce(transform.up * thrustSpeed);
            thrust.SetActive(true);
        }
        else if (!thrusting)
        {
            thrust.SetActive(false);
        }


        if (turnDirection != 0)
        {
            body.AddTorque(turnDirection * turnSpeed);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Asteroid")
        {
            body.velocity = Vector3.zero;
            body.angularVelocity = 0f;

            gameObject.SetActive(false);

            GameManager.instance.RemoveLife();
        }
    }
}
