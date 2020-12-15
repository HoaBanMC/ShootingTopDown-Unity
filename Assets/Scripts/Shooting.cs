using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEditor.Audio;

public class Shooting : MonoBehaviour
{
    public Transform firePoint;
    public GameObject bulletPrefab;

    public float bulletFroce = 3f;
    private float currentTime = 0.3f;
    private float startTime = 0.3f;

    public AudioClip shootSound;
    public AudioSource soundSource;

    private void Start()
    {
        currentTime = startTime;
    }

    // Update is called once per frame
    private void Update()
    {
        if (!MenuPanel.isPaused)
        {
            currentTime -= 1 * Time.deltaTime;

            if(!GameManager.isStart)
            {
                GameManager.isStart = true;
            }
            if (Input.GetButtonDown("Fire1") && currentTime <= 0 && BulletCount.bulletCount > 0 && GameManager.isStart)
            {
                Shoot();
                BulletCount.bulletCount -= 1;
                currentTime = startTime;
            }
        }
    }

    void Shoot()
    {
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        rb.AddForce(firePoint.right * bulletFroce, ForceMode2D.Impulse);
        soundSource.PlayOneShot(shootSound);
    }
}
