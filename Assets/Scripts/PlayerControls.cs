using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControls : MonoBehaviour
{
    Rigidbody2D rb;

    [SerializeField] float jumpForce;

    // Start is called before the first frame update
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        //upward movement
        if(Input.GetKeyDown(KeyCode.W))
        {
            rb.AddForce(transform.up * jumpForce, ForceMode2D.Impulse);
        }

        //downward movement
        if(Input.GetKeyDown(KeyCode.S))
        {
            rb.AddForce(transform.up * (-1) * jumpForce, ForceMode2D.Impulse);
        }
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        //detect water
        //reverse gravity when in the water to simulate buoyancy
        if(collision.gameObject.tag == "Water")
        {
            rb.gravityScale *= -1;
        }


        //detect iceberg
        if(collision.gameObject.tag == "Obstacle")
        {
            //TODO vvv dummy code before game over implementation
            rb.AddForce(transform.right * 10, ForceMode2D.Impulse);
        }
    }


    private void OnTriggerExit2D(Collider2D collision)
    {
        //detect water
        //flip the gravity back when exiting the water
        if(collision.gameObject.tag == "Water")
        {
            rb.gravityScale *= -1;
        }
    }
}
