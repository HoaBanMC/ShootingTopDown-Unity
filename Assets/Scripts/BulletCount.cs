using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BulletCount : MonoBehaviour
{
    public static int bulletCount = 5;
    int cureentBullet = 5;
    int bulletBonus = 1;
    private Text bulletText;
    public Image bulletImg;

    public float downTimeStart = 1f;
    public float downTime = 1f;

    private void Start()
    {
        bulletText = GetComponent<Text>();
    }

    private void Update()
    {
        bulletText.text = bulletCount.ToString();
        if (bulletCount == 0f)
        {
            bulletText.text = "Loading...";
            downTime -= 1 * Time.deltaTime;
            if(downTime <= 0)
            {
                bulletCount = cureentBullet;
                downTime = downTimeStart;
            }
        }

        if (PlayerController.heath == 0)
        {
            bulletImg.enabled = false;
            bulletText.enabled = false;
        }

        if (ScoreScript.scoreValue / 10 == bulletBonus && cureentBullet < 10)
        {
            cureentBullet += 1;
            bulletBonus += 1;
        }
    }
}
