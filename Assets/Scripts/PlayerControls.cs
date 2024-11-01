using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControls : MonoBehaviour
{
    private Rigidbody2D rb;

    [SerializeField] private float jumpForce;

    private bool isSubmerged;

    private GameObject camera;

    private AudioSource[] sfx;

    // Start is called before the first frame update
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();

        camera = GameObject.Find("Main Camera");

        sfx = gameObject.GetComponents<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        //upward movement
        if(Input.GetKeyDown(KeyCode.W) && !isSubmerged)
        {
            sfx[0].Play();
            rb.AddForce(transform.up * jumpForce, ForceMode2D.Impulse);
        }

        //downward movement
        if(Input.GetKeyDown(KeyCode.S) && isSubmerged)
        {
            sfx[1].Play();
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
            isSubmerged = true;
        }


        //detect iceberg
        if(collision.gameObject.tag == "Obstacle")
        {
            //TODO vvv dummy code before game over implementation
            transform.Translate(Vector2.right * 100);

            var videoPlayer = camera.AddComponent<UnityEngine.Video.VideoPlayer>();
            videoPlayer.renderMode = UnityEngine.Video.VideoRenderMode.CameraNearPlane;
            videoPlayer.url = "Assets/Videos/Jumpscare_penguin.mp4";
        }
    }


    private void OnTriggerExit2D(Collider2D collision)
    {
        //detect water
        //flip the gravity back when exiting the water
        if(collision.gameObject.tag == "Water")
        {
            rb.gravityScale *= -1;
            isSubmerged = false;
        }
    }
}
