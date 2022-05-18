using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{

    public Animator animator;

    public float transitionTime = 1f;

    public void PlayGame()
    {
        StartCoroutine(LoadLevel());
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    IEnumerator LoadLevel()
    {
        animator.SetTrigger("Start");

        yield return new WaitForSeconds(transitionTime);

        SceneManager.LoadScene(1);
    }
}
