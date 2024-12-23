using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class HungerSystem : MonoBehaviour
{
    public float maxHunger = 100f;
    public float currentHunger;
    public float hungerDecreaseRate = 1f;
    public float healthDamageRate = 5f;
    public TextMeshProUGUI hungerText;
    public HealthSystem health;

    void Start()
    {
        currentHunger = maxHunger;
        UpdateHungerText();
    }

    void Update()
    {
        currentHunger -= hungerDecreaseRate * Time.deltaTime;
        currentHunger = Mathf.Clamp(currentHunger, 0, maxHunger);
        UpdateHungerText();

        if (currentHunger <= 0)
        {
            Debug.Log($"{gameObject.name} is starving!");
            // Add further logic here for consequences of starvation.
            health.TakeDamage(healthDamageRate * Time.deltaTime);
        }
    }

    public void EatFood(float amount)
    {
        currentHunger += amount;
        currentHunger = Mathf.Clamp(currentHunger, 0, maxHunger);
        UpdateHungerText();
    }

    private void UpdateHungerText()
    {
        if (hungerText != null)
        {
            hungerText.text = $"Hunger: {Mathf.RoundToInt(currentHunger)}";
        }
    }
}
