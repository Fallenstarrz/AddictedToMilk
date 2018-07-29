using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSwitcher : MonoBehaviour
{
    // Load scenes, integers are decided in the build settings
    public void LoadMainMenu()
    {
        SceneManager.LoadScene(0);
    }
    public void LoadLevel1()
    {
        SceneManager.LoadScene(1);
    }
    public void LoadLevel2()
    {
        SceneManager.LoadScene(2);
    }
    public void LoadLevel3()
    {
        SceneManager.LoadScene(3);
    }
    public void LoadVictory()
    {
        SceneManager.LoadScene(4);
    }
    public void LoadLoss()
    {
        SceneManager.LoadScene(5);
    }
    public void LoadCredits()
    {
        SceneManager.LoadScene(6);
    }
    public void LoadExitGame()
    {
        Debug.Log("I quit this game!");
        Application.Quit();
    }
}
