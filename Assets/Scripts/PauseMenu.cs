using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    // Start is called before the first frame update
    public static bool gameIsPaused = false;
    [SerializeField] private GameObject pauseMenuUI;
    [SerializeField] private GameObject pauseButton;
    [SerializeField] private GameObject resumeButton;
   


    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            if(gameIsPaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
    }

    public void Resume()
    {
        Time.timeScale = 1;
        gameIsPaused = false;
        pauseMenuUI.SetActive(false);
        pauseButton.SetActive(true);
        resumeButton.SetActive(false);
        AudioListener.volume = 1f;
    }

    public void Pause()
    {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0;
        gameIsPaused = true;
        pauseButton.SetActive(false);
        resumeButton.SetActive(true);
        AudioListener.volume = 0f;
    }
}
