using TMPro;
using UnityEngine;

public class HealthSystem : MonoBehaviour
{
    public float maxHealth = 100f;
    public float currentHealth;
    public TextMeshProUGUI healthText;

    void Start()
    {
        currentHealth = maxHealth;
        UpdateHealthText();
    }

    public void TakeDamage(float amount)
    {
        currentHealth -= amount;
        currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth);
        UpdateHealthText();

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        Debug.Log($"{gameObject.name} has died!");
        // Add further logic here for death handling
    }

    private void UpdateHealthText()
    {
        if (healthText != null)
        {
            healthText.text = $"Health: {Mathf.RoundToInt(currentHealth)}";
        }
    }
}
