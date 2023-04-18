using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float playerSpeed = 1;
    public float jumpForce = 3;
    public bool isGrounded;
    private Vector3 initialScale;

    // Start is called before the first frame update
    void Start()
    {
        // Cache the scale
        initialScale = transform.localScale;
    }

    // Update is called once per frame
    void Update()
    {
        // If right arrow is held down
        if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.position += playerSpeed * Vector3.right * Time.deltaTime;
            // flip character
            transform.localScale = new Vector3(-initialScale.x, initialScale.y, initialScale.z);
        }

        // If left arrow is held down
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.position += playerSpeed * Vector3.left * Time.deltaTime;
            // flip character
            transform.localScale = new Vector3(initialScale.x, initialScale.y, initialScale.z);
        }

        // Jump
        if (Input.GetKeyDown(KeyCode.UpArrow) && isGrounded)
        {
            GetComponent<Rigidbody2D>().AddForce(jumpForce * Vector3.up, ForceMode2D.Impulse);
        }
    }

    private void onCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer == 10)
        {
            isGrounded = true;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.layer == 10)
        {
            isGrounded = false;
        }
    }
}
