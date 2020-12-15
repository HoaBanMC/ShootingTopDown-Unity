using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MobController : MonoBehaviour
{
    public Rigidbody2D rb;
    public float min_speed = 5f;
    public float max_speed = 10f;
    private float speed = 5f;
    private Vector2 movement;

    private void Start()
    {
        speed = Random.Range(min_speed, max_speed);
    }

    private void Update()
    {
        if (GameObject.Find("Player"))
        {
            var target = GameObject.Find("Player").transform;
            Vector3 direction = target.position - transform.position;
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
            rb.rotation = angle;
            direction.Normalize();
            movement = direction;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void FixedUpdate()
    {
        rb.MovePosition((Vector2)transform.position + (movement * speed * Time.fixedDeltaTime));
    }

    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
}
