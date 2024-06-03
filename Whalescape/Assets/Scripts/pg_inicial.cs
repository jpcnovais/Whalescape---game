using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class pg_inicial : MonoBehaviour
{

    //[SerializeField] GameObject pausaMenu;
    [SerializeField] GameObject settingsMenu;
    

    public void Start()
    {
        //pausaMenu.SetActive(false);
        settingsMenu.SetActive(false);
    }
    public void Pausa()
    {
        //pausaMenu.SetActive(true);
        settingsMenu.SetActive(false);
        Time.timeScale = 0;
    }
    public void Resume()
    {
        // pausaMenu.SetActive(false);
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
        //pausaMenu.SetActive(false);
        settingsMenu.SetActive(true);
    }
    public void CloseSettings()
    {
        //pausaMenu.SetActive(true);
        settingsMenu.SetActive(false);
    }
    public void Quit()
    {
        /*pausaMenu.SetActive(false);
        settingsMenu.SetActive(false);
        Time.timeScale = 1;*/
    }

    public void PlayGame()
    {
        //PlayerPrefs.SetInt("score", 0);
        SceneManager.LoadScene("cenario1");
    }
}
