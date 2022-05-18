using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PondTransition : MonoBehaviour
{
    // Start is called before the first frame update
    public Animator animator;

    public PlayerMovement player;

    public float transitionTime = 1f;

    public bool available = false;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (available)
        {
            Debug.Log("second time");
            if (collision.gameObject.CompareTag("Player"))
            {
                player.movementOverride = true;
                player.overrideDirectionLeft = false;
                StartCoroutine(LoadLevel());
            }
        }
    }

    IEnumerator LoadLevel()
    {
        animator.SetTrigger("Start");

        yield return new WaitForSeconds(transitionTime);

        SceneManager.LoadScene(1);
    }
}
