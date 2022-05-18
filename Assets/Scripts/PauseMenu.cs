using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{

    public GameObject pausePanel;
    public Animator animator;


    public bool isPaused;
    
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            isPaused = !isPaused;
        }

        if (isPaused)
        {
            ActivatePauseMenu();
        }
        else
        {
            DisablePauseMenu();
        }
    }

    void ActivatePauseMenu()
    {
        pausePanel.SetActive(true);
        Time.timeScale = 0;
    }

    void DisablePauseMenu()
    {
        pausePanel.SetActive(false);
        Time.timeScale = 1;
    }

    public void QuitGame()
    {
        Debug.Log("Quit Game");
        Application.Quit();
    }
}
