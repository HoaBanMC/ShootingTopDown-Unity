using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LifeHeartPlayer : MonoBehaviour
{
    public int health;
    public int numOfHearts;

    public Image[] hearts;
    public Sprite fullHeart;
    public Sprite emptHeart;

    private void Update()
    {
        health = PlayerController.heath;
        for (int i = 0; i < hearts.Length; i++)
        {
            if(health > numOfHearts)
            {
                health = numOfHearts;
            }

            if (i < health)
            {
                hearts[i].sprite = fullHeart;
            }
            else
            {
                hearts[i].sprite = emptHeart;
            }

            if (i < numOfHearts)
            {
                hearts[i].enabled = true;
            }
            else
            {
                hearts[i].enabled = false;
            }

            if (health == 0)
            {
                hearts[i].enabled = false;
            }
        }
    }
}
