using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class BossHealth : MonoBehaviour
{
    public Slider healthSlider;
    public float maxHealth = 100f;
    private float currentHealth;

    void Start()
    {
        currentHealth = maxHealth;
        UpdateHealthBar();
    }

    public void TakeDamage(float damage)
    {
        currentHealth -= damage;
        UpdateHealthBar();

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    void UpdateHealthBar()
    {
        healthSlider.value = currentHealth;
    }

    void Die()
    {
    SceneManager.LoadScene("finaljogo");
    }
}
