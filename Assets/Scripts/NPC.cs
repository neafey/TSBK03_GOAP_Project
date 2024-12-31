using TMPro;
using UnityEngine;

public class NPC : MonoBehaviour
{
    public HungerSystem hungerSystem;
    public HealthSystem healthSystem;

    private int enemiesKilled = 0;
    private float timeAlived = 0f;

    [Header("UI References")]
    public TextMeshProUGUI enemiesKilledText;
    public TextMeshProUGUI timeAlivedText;

    void Update()
    {
        timeAlived += Time.deltaTime;
        UpdateTimeAlivedUI();
    }

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

    }

    public void IncrementEnemiesKilled()
    {
        enemiesKilled++;
        UpdateEnemiesKilledUI();
    }

    private void UpdateEnemiesKilledUI()
    {
        if (enemiesKilledText != null)
        {
            enemiesKilledText.text = $"Enemies Killed: {enemiesKilled}";
        }
    }

    private void UpdateTimeAlivedUI()
    {
        if (timeAlivedText != null)
        {
            timeAlivedText.text = $"Time Alive: {Mathf.FloorToInt(timeAlived)}s";
        }
    }
}
