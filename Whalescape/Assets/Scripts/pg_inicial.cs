using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class pg_inicial : MonoBehaviour
{

    [SerializeField] GameObject settingsMenu;


    public void Start()
    {

        settingsMenu.SetActive(false);
    }
    public void Pausa()
    {

        settingsMenu.SetActive(false);
        Time.timeScale = 0;
    }
    public void Resume()
    {
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
        settingsMenu.SetActive(true);
    }
    public void CloseSettings()
    {
        settingsMenu.SetActive(false);
    }
    public void Quit()
    {
        Application.Quit();

    }

    public void PlayGame()
    {
        PlayerPrefs.SetInt("score", 0);
        SceneManager.LoadScene("cenario1");
    }
}
