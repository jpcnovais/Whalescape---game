using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{
    // Chame esta função antes de carregar a cena de Game Over
    public void LoadGameOver()
    {
        // Salva o nome da cena atual
        PlayerPrefs.SetString("LastScene", SceneManager.GetActiveScene().name);
        // Carrega a cena de Game Over
        SceneManager.LoadScene("gameover");
    }

    // Chame esta função para carregar a cena desejada
    public void LoadScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }
}
