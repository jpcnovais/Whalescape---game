using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bomb_pickup : MonoBehaviour
{
    public int pointToAdd;
    private AudioSource coinPickupEffect;
    private ScoreManager scoreManager;

    void Start()
    {
        coinPickupEffect = GetComponent<AudioSource>();
        scoreManager = FindObjectOfType<ScoreManager>();
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<Player>() == null)
            return;

        if (scoreManager != null)
        {
            scoreManager.AddPoints(pointToAdd);
        }

        if (coinPickupEffect != null)
        {
            coinPickupEffect.Play(); // Toca o som
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

        Destroy(gameObject, 0.5f);
    }
}
