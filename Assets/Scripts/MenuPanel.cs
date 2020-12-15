using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuPanel : MonoBehaviour
{
    public GameObject menuPanel;
    public Text message;
    public GameObject playAgian;
    public GameObject backMenu;

    public static bool isPaused = false;
    int highScore = 0;

    private void Start()
    {
        if (PlayerPrefs.HasKey("HighScore"))
        {
            highScore = PlayerPrefs.GetInt("HighScore");
        }
        menuPanel.SetActive(false);
        Time.timeScale = 1f;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (isPaused)
            {
                ResumeGame();
            }
            else
            {
                PauseGame();
                message.text = "Press Space to Resume Game!\nHigh Score: " + highScore;
            }
        }

        if (PlayerController.heath == 0)
        {
            if (ScoreScript.scoreValue > highScore) 
            {
                highScore = ScoreScript.scoreValue;
                PlayerPrefs.SetInt("HighScore", highScore);
            }
            else
            {
                PlayerPrefs.SetInt("HighScore", highScore);
            }
            GameOver();
        }
    }

    void GameOver()
    {
        menuPanel.SetActive(true);
        message.text = "LOSE!\nHigh Score: " + highScore;
    }

    public void ResumeGame()
    {
        isPaused = false;
        Time.timeScale = 1f;
        menuPanel.SetActive(false);
    }

    public void PauseGame()
    {
        isPaused = true;
        Time.timeScale = 0f;
        menuPanel.SetActive(true);
    }

    public void QuitGame()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }
}
