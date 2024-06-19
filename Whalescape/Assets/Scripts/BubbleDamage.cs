using UnityEngine;

public class BubbleDamage : MonoBehaviour
{
   
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("player"))
        {
            Player player = collision.gameObject.GetComponent<Player>();
            if (player != null)
            {
                player.TakeDamage();
            }
            Destroy(gameObject);
        }
    }
}
