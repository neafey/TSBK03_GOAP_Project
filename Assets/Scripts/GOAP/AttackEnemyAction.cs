using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackEnemyAction : GOAPAction
{
    private Transform targetEnemy;
    private float speed = 5f; // Movement speed
    private bool isDone;
    private ResourceManager resourceManager;

    void Start()
    {
        resourceManager = GetComponent<ResourceManager>();
    }

    public override bool CanExecute(GOAPGoal goal)
    {
        if (goal.Name != "Handle Enemies") return false;

        targetEnemy = FindClosestEnemy();
        return resourceManager != null && resourceManager.arrowCount > 0 && targetEnemy != null;
    }

    public override void Perform()
    {
        if (targetEnemy == null)
        {
            isDone = true;
            return;
        }


        Vector2 direction = (targetEnemy.position - transform.position).normalized;
        transform.position += (Vector3)direction * speed * Time.deltaTime;

        if (Vector2.Distance(transform.position, targetEnemy.position) < 0.1f)
        {
            isDone = true;
        }
    }

    public override bool IsDone => isDone;

    public override void ResetAction()
    {
        isDone = false;
        if (targetEnemy == null || !targetEnemy.gameObject.activeInHierarchy)
        {
            targetEnemy = null;
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

