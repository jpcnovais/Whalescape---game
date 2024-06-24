using UnityEngine;
using UnityEngine.SceneManagement;

public class ElevadorTrigger : MonoBehaviour
{
    private bool bombCollected = false;
    private UIController uiController;

     [SerializeField]
    private string nextscene;

    void Start()
    {
        // Encontra o UIController na cena
        uiController = FindObjectOfType<UIController>();
    }

    void OnTriggerEnter(Collider other)
    {
        // Verifica se o objeto que colidiu tem a tag "Player"
        if (other.CompareTag("player"))
        {
            if (bombCollected)
            {
                Debug.Log("Player collected the bomb and collided with the elevator.");
                SceneManager.LoadScene(nextscene);
            }
            else
            {
                Debug.Log("Player collided with the elevator but hasn't collected the bomb.");
                if (uiController != null)
                {
                    uiController.ShowWarning(); // Mostra a imagem de aviso por 4 segundos
                }
            }
        }
    }

    // Função para ser chamada quando o jogador coleta a bomb
    public void CollectBomb()
    {
        bombCollected = true;
        Debug.Log("Bomb collected.");
    }
}
