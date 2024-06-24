using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverController : MonoBehaviour
{
    public void RestartPreviousScene()
    {
        string lastScene = PlayerPrefs.GetString("LastScene");


        if (!string.IsNullOrEmpty(lastScene))
        {
            SceneManager.LoadScene(lastScene);
        }
        else
        {
            Debug.LogError("No previous scene found in PlayerPrefs.");
        }
    }
}
