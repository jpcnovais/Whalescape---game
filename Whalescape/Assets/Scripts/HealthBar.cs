using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public Slider healthSlider;
    public float maxHealth = 100f;
    public float health;

    void Start()
    {
        health = maxHealth;
        healthSlider.maxValue = maxHealth;
        healthSlider.value = health;
    }

    void Update()
    {
        if (healthSlider.value != health)
        {
            healthSlider.value = health;
        }
    }

    public void TakeDamage(float damage)
    {
        health -= damage;
        if (health < 0)
        {
            health = 0;
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Bomb"))
        {
            TakeDamage(15);

            Destroy(collision.gameObject);
        }
    }
}
