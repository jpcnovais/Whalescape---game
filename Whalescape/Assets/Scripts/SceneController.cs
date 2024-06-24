using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{

    public void LoadGameOver()
    {

        PlayerPrefs.SetString("LastScene", SceneManager.GetActiveScene().name);

        SceneManager.LoadScene("gameover");
    }


    public void LoadScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }
}
