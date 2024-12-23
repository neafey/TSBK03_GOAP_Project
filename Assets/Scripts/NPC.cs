using UnityEngine;

public class NPC : MonoBehaviour
{
    public HungerSystem hungerSystem;
    public HealthSystem healthSystem;

    public void TakeDamage(float healthDamage, float hungerDamage)
    {
        if (healthSystem != null)
        {
            healthSystem.TakeDamage(healthDamage);
        }

        if (hungerSystem != null)
        {
            hungerSystem.currentHunger -= hungerDamage;
            hungerSystem.currentHunger = Mathf.Clamp(hungerSystem.currentHunger, 0, hungerSystem.maxHunger);
        }

        Debug.Log($"NPC took {healthDamage} health damage and {hungerDamage} hunger damage.");
    }
}
