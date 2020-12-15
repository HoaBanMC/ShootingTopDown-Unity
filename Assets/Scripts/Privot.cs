using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Privot : MonoBehaviour
{
    public GameObject hand_sanitizer;

    public GameObject player;
/*
    Vector2 dir;
    private void Update()
    {
        for (int i = 0; i < Input.touchCount; i++)
        {
            Vector3 touchPos = Camera.main.ScreenToWorldPoint(Input.touches[i].position);
            Debug.DrawLine(Vector3.zero, touchPos, Color.red);
        }
    }
*/
    private void FixedUpdate()
    {
        Vector3 difference = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        difference.Normalize();
        float rotaionz = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0f, 0f, rotaionz);
    }
}
