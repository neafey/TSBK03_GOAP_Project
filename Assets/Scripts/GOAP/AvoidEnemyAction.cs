using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AvoidEnemyAction : GOAPAction
{
    private Transform closestEnemy;
    private float speed = 5f; // Movement speed
    private bool isDone;

    public override bool CanExecute(GOAPGoal goal)
    {
        if (goal.Name != "Handle Enemies") return false;

        closestEnemy = FindClosestEnemy();
        return closestEnemy != null;
    }

    public override void Perform()
    {
        if (closestEnemy == null)
        {
            Debug.LogWarning("No enemy available. Skipping AvoidEnemyAction.");
            isDone = true;
            return;
        }

        Debug.Log($"Moving away from enemy at {closestEnemy.position}");
        Vector2 direction = (transform.position - closestEnemy.position).normalized;
        transform.position += (Vector3)direction * speed * Time.deltaTime;

        // Stop avoiding after moving a certain distance away
        if (Vector2.Distance(transform.position, closestEnemy.position) > 5f) // Example: keep 5 units away
        {
            Debug.Log("Enemy avoided!");
            isDone = true;
        }
    }

    public override bool IsDone => isDone;

    public override void ResetAction()
    {
        isDone = false;
        if (closestEnemy == null || !closestEnemy.gameObject.activeInHierarchy)
        {
            closestEnemy = null;
        }
    }

    private Transform FindClosestEnemy()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
        float closestDistance = Mathf.Infinity;
        Transform closestEnemy = null;

        foreach (GameObject enemy in enemies)
        {
            float distance = Vector2.Distance(transform.position, enemy.transform.position);
            if (distance < closestDistance)
            {
                closestDistance = distance;
                closestEnemy = enemy.transform;
            }
        }

        return closestEnemy;
    }
}

