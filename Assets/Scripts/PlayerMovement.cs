using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float currentSpeed;
    public float minSpeed;
    public float maxSpeed;

    public float speedMultiplier;


    public float jumpForce;

    [SerializeField]
    bool isGrounded = false;

    Rigidbody2D rbPlayer;

    private void Awake()
    {
        rbPlayer = GetComponent<Rigidbody2D>();
        currentSpeed = minSpeed;
    }

    // Update is called once per frame
    void Update()
    {
        
        if(currentSpeed < maxSpeed)
        {
            currentSpeed += speedMultiplier;
        }

        transform.Translate(Vector2.right * currentSpeed * Time.deltaTime);

        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (isGrounded)
            {
                rbPlayer.AddForce(Vector2.up * jumpForce);
                isGrounded = false;
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            if(isGrounded == false)
            {
                isGrounded = true;
            }
        }
    }
}
