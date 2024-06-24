using UnityEngine;

public class bomb_pickup : MonoBehaviour
{
    public int pointToAdd;
    private AudioSource coinPickupEffect;
    private ScoreManager scoreManager;
    private ElevadorTrigger elevadorTrigger;

    void Start()
    {
        coinPickupEffect = GetComponent<AudioSource>();
        scoreManager = FindObjectOfType<ScoreManager>();
        elevadorTrigger = FindObjectOfType<ElevadorTrigger>();
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("player"))
        {
            if (scoreManager != null)
            {
                scoreManager.AddPoints(pointToAdd);
            }

            if (coinPickupEffect != null)
            {
                coinPickupEffect.Play();
            }

            SpriteRenderer spriteRenderer = GetComponentInChildren<SpriteRenderer>();
            if (spriteRenderer != null)
            {
                spriteRenderer.enabled = false;
            }

            Collider collider = GetComponent<Collider>();
            if (collider != null)
            {
                collider.enabled = false;
            }

            if (elevadorTrigger != null)
            {
                elevadorTrigger.CollectBomb();
            }

            Destroy(gameObject, 0.5f);
        }
    }
}
