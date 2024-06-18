using UnityEngine;

public class BombController : MonoBehaviour
{
    public float bombDamage = 15f; // Quantidade de dano da bomba

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Boss"))
        {
            BossHealth bossHealth = collision.gameObject.GetComponent<BossHealth>();
            if (bossHealth != null)
            {
                bossHealth.TakeDamage(bombDamage);
            }
            Destroy(gameObject); // Destruir a bomba após colidir com o boss
        }
    }
}
