using UnityEngine;

public class BombController : MonoBehaviour
{
    public float bombDamage = 15f;


    AudioManager audioManager;


    private void Awake()
    {
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
    }

    void OnCollisionEnter(Collision collision)
    {
        audioManager.PlaySFX(audioManager.hit);
        if (collision.gameObject.CompareTag("Boss"))
        {
            BossHealth bossHealth = collision.gameObject.GetComponent<BossHealth>();
            if (bossHealth != null)
            {
                bossHealth.TakeDamage(bombDamage);
            }
            Destroy(gameObject);
        }
    }
}
