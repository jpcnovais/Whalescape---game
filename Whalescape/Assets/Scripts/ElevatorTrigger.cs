using UnityEngine;

public class ElevadorTrigger : MonoBehaviour
{
    private bool bombCollected = false;

    void OnTriggerEnter(Collider other)
    {

        if (other.CompareTag("player"))
        {
            if (bombCollected)
            {
                Debug.Log("Player collected the bomb and collided with the elevator.");

            }
            else
            {
                Debug.Log("Player collided with the elevator but hasn't collected the bomb.");
            }
        }
    }


    public void CollectBomb()
    {
        bombCollected = true;
        Debug.Log("Bomb collected.");
    }
}
