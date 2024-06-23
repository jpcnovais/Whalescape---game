using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverController : MonoBehaviour
{
    public void RestartPreviousScene()
    {
        // Recupera o nome da última cena
        string lastScene = PlayerPrefs.GetString("LastScene");

        // Carrega a última cena se o nome for válido
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
