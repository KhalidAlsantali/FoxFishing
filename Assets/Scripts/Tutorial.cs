using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tutorial : MonoBehaviour
{

    public PauseMenu pauseMenu;
    public GameObject tutorial;



    // Start is called before the first frame update
    void Start()
    {
        if(PlayerPrefs.GetInt("Tutorial", 0) == 0)
        {
            pauseMenu.gameObject.SetActive(false);
            tutorial.gameObject.SetActive(true);
        }
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if(PlayerPrefs.GetInt("Tutorial", 0) == 0)
            {
                tutorial.gameObject.SetActive(false);
                pauseMenu.gameObject.SetActive(true);
                PlayerPrefs.SetInt("Tutorial", 1);
            }
        } 
    }
}
