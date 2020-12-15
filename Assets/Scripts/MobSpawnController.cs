using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MobSpawnController : MonoBehaviour
{
    public GameObject mobPrefab;
    public Transform mobSpwan;
    public Camera cam;
    public GameObject player;

    private float heightCam;
    private float widthCam;

    // Start is called before the first frame update
    private void Start()
    {
        heightCam = Camera.main.orthographicSize * 2f;
        widthCam = heightCam * Camera.main.aspect;
        InvokeRepeating("SpawnMob", 2f, 1f);
    }

    private void Update()
    {
        if (player == null)
        {
            CancelInvoke();
        }
    }

    void SpawnMob()
    {
        Vector2[] posList = {
               new Vector2(Random.Range(-widthCam / 2, widthCam / 2), heightCam / 2),
               new Vector2(Random.Range(-widthCam / 2, widthCam / 2), -heightCam / 2),
               new Vector2(-widthCam / 2, Random.Range(-heightCam / 2, heightCam / 2)),
               new Vector2(widthCam / 2, Random.Range(-heightCam / 2, heightCam / 2)),
        };
        //Vector2 screenPosition = Camera.main.ViewportToWorldPoint(new Vector2(Random.value, Random.value));
        GameObject mob = Instantiate(mobPrefab, posList[Random.Range(0, posList.Length)], Quaternion.identity);
        Animator anim = mob.GetComponent<Animator>();
        anim.SetInteger("MobState", Random.Range(0,3));
    }
}
