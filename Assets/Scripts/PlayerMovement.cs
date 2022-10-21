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
    public Sprite roll;
    public Sprite stand;
    bool isRolling;
    public float speedDash;
    public IEnumerator doRoll()
    {
        isRolling = true;
        GetComponent<SpriteRenderer>().sprite = roll;
        yield return new WaitForSeconds(1f);
        GetComponent<SpriteRenderer>().sprite = stand;
        isRolling = false;
        print("caca");
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F) && !isRolling)
        {
            StartCoroutine(doRoll());
        }
        if (isRolling)
        {
            transform.Translate(Vector2.right * currentSpeed * speedDash * Time.deltaTime);
        }
        if (currentSpeed < maxSpeed)
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
