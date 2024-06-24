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

        uiController = FindObjectOfType<UIController>();
    }

    void OnTriggerEnter(Collider other)
    {

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
                    uiController.ShowWarning();
                }
            }
        }
    }

    public void CollectBomb()
    {
        bombCollected = true;
        Debug.Log("Bomb collected.");
    }
}
