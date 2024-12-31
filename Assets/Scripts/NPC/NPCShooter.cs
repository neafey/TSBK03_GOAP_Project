using UnityEngine;

public class NPCShooter : MonoBehaviour
{
    public float shootRange = 5f; // Range to detect enemies
    public ResourceManager resourceManager;
    private NPC npc;

    private void Start()
    {
        npc = GetComponent<NPC>();
    }

    void Update()
    {
        ShootClosestEnemy();
    }

    void ShootClosestEnemy()
    {
        if (resourceManager.arrowCount <= 0) return; // No arrows to shoot

        Enemy closestEnemy = null;
        float closestDistance = Mathf.Infinity;

        // Find the closest enemy within range
        foreach (var enemy in FindObjectsOfType<Enemy>())
        {
            float distance = Vector2.Distance(transform.position, enemy.transform.position);
            if (distance < shootRange && !enemy.isHit && distance < closestDistance)
            {
                closestEnemy = enemy;
                closestDistance = distance;
            }
        }

        // Shoot the closest enemy
        if (closestEnemy != null)
        {
            resourceManager.arrowCount--;
            resourceManager.UpdateResourceText();
            npc.IncrementEnemiesKilled();
            closestEnemy.GetHit();
        }
    }
}

