using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class menu_pause : MonoBehaviour
{

    [SerializeField] GameObject pausaMenu;
    [SerializeField] GameObject settingsMenu;
    


    private bool gameIsPaused;

    public void Start()
    {
        pausaMenu.SetActive(false);
        settingsMenu.SetActive(false);
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            gameIsPaused = !gameIsPaused;
            if (gameIsPaused)
            {
                Pausa();
            }
            else
            {
                Resume();
            }
        }
    }
    public void Pausa()
    {
        pausaMenu.SetActive(true);
        settingsMenu.SetActive(false);
        Time.timeScale = 0;
    }
    public void Resume()
    {
        pausaMenu.SetActive(false);
        settingsMenu.SetActive(false);
        Time.timeScale = 1;
    }
    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Time.timeScale = 1;
    }
    public void OpenSettings()
    {
        pausaMenu.SetActive(false);
        settingsMenu.SetActive(true);
    }
    public void CloseSettings()
    {
        pausaMenu.SetActive(true);
        settingsMenu.SetActive(false);
    }
    public void Quit()
    {
        SceneManager.LoadScene("paginainicial");
        //Application.Quit();

    }


}
