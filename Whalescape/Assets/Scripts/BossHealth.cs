using UnityEngine;
using UnityEngine.UI;

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
            Die(); // Implemente esta função se quiser que o boss morra ao atingir 0 de vida
        }
    }

    void UpdateHealthBar()
    {
        healthSlider.value = currentHealth;
    }

    void Die()
    {
        // Implemente a lógica de morte do boss aqui (por exemplo, destruir o objeto do boss)
        Destroy(gameObject);
    }
}
