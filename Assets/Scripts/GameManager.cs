using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor.SceneManagement;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static bool isStart = false;
    public void StartGame()
    {
#if UNITY_EDITOR
        EditorSceneManager.LoadScene(1);
        MenuPanel.isPaused = false;
        BulletCount.bulletCount = 5;
        Time.timeScale = 1f;
        PlayerController.heath = 5;
        ScoreScript.scoreValue = 0;
        isStart = false;

#else
        
        SceneManager.LoadScene(1);
        MenuPanel.isPaused = false;
        BulletCount.bulletCount = 5;
        Time.timeScale = 1f;
        PlayerController.heath = 5;
        ScoreScript.scoreValue = 0;
        isStart = false;
#endif
    }
    public void ReStartGame()
    {
#if     UNITY_EDITOR
        EditorSceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        MenuPanel.isPaused = false;
        BulletCount.bulletCount = 5;
        Time.timeScale = 1f;
        PlayerController.heath = 5;
        ScoreScript.scoreValue = 0;
#else
        
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        MenuPanel.isPaused = false;
        BulletCount.bulletCount = 5;
        Time.timeScale = 1f;
        PlayerController.heath = 5;
        ScoreScript.scoreValue = 0;
#endif
    }

    public void BackMenu()
    {
#if     UNITY_EDITOR
        EditorSceneManager.LoadScene(0);
#else
        
        SceneManager.LoadScene(0);
#endif
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