using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Menu : MonoBehaviour
{
    public static bool GameIsPause = false;
    public GameObject pauseMenuUI;
    public AudioSource soundgame;

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            if (GameIsPause)
            {
                Resume();
            }
            else
            {
                {
                    Pause();
                }
            }
        }
    }
        public void Pause()
        {
            pauseMenuUI.SetActive(true);
            Time.timeScale = 0f;
            GameIsPause = true;
            AudioListener.pause = true;
        }
        public void Resume()
        {
            pauseMenuUI.SetActive(false);
            Time.timeScale = 1f;
            GameIsPause = false;
            AudioListener.pause = false;
        }
        private void LoadMenu()
        {
            Debug.Log("Load");
            Time.timeScale = 1f;
            SceneManager.LoadScene("Menu");
        }
        public void QuitGame()
        {
            Debug.Log("Quit");
            Application.Quit();
        }
        public void Settings()
        {
            Debug.Log("Settings");
            // Application.LoadScene("Settings");
        }
    
}
