using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Rigidbody2D rb;
    public Animator anim;
    float heightCam;
    float widthCam;

    //public Joystick joystick;

    private Vector2 movement;
    public float speed = 5f;

    public static int heath = 5;

    void Start()
    {
        //lay kich thuoc cua camera
        heightCam = Camera.main.orthographicSize * 2.0f;
        widthCam = heightCam * Camera.main.aspect;
    }

    // Update is called once per frame
    void Update()
    {
        movement.x = Input.GetAxis("Horizontal");
        movement.y = Input.GetAxis("Vertical");
        /*
        if (joystick.Horizontal >= 0.2f)
        {
            movement.x = joystick.Horizontal;
        }
        else if (joystick.Horizontal <= -0.2f)
        {
            movement.x = joystick.Horizontal;
        }
        else
        {
            movement.x = 0f;
        }

        if (joystick.Vertical >= 0.2f)
        {
            movement.y = joystick.Vertical;
        }
        else if (joystick.Vertical <= -0.2f)
        {
            movement.y = joystick.Vertical;
        }
        else
        {
            movement.y = 0f;
        }*/

        anim.SetFloat("Horizontal", movement.x);
        anim.SetFloat("Vertical", movement.y);
        //Ham kiem tra do lon cua movement
        anim.SetFloat("Speed", movement.sqrMagnitude);
    }

    void FixedUpdate(){
        rb.MovePosition(rb.position + movement * speed * Time.fixedDeltaTime);
        //gioi han player trong camera
        transform.position = new Vector2(
            Mathf.Clamp(rb.position.x, -widthCam/2, widthCam/2),
            Mathf.Clamp(rb.position.y, -heightCam/2, heightCam/2)
        );

        if (heath == 0)
        {
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Mobs"))
        {
            heath -= 1;
            Destroy(collision.gameObject);
        }
    }
}
