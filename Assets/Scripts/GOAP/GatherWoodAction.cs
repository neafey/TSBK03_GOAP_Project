using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GatherWoodAction : GOAPAction
{
    private ResourceManager resourceManager;
    private Transform targetWood;
    private float speed = 5f; // Movement speed
    private bool isDone;

    void Start()
    {
        resourceManager = GetComponent<ResourceManager>();
    }

    public override bool CanExecute(GOAPGoal goal)
    {
        if (goal.Name != "Craft Arrows") return false;

        targetWood = FindClosestWood();
        return resourceManager != null && targetWood != null;
    }

    public override void Perform()
    {
        if (targetWood == null)
        {
            isDone = true;
            return;
        }

        // Move towards the wood
        Vector2 direction = (targetWood.position - transform.position).normalized;
        transform.position += (Vector3)direction * speed * Time.deltaTime;

        // Check if NPC has reached the wood
        if (Vector2.Distance(transform.position, targetWood.position) < 0.1f)
        {
            isDone = true;
        }
    }

    public override bool IsDone => isDone;

    public override void ResetAction()
    {
        isDone = false;
        if (targetWood == null || !targetWood.gameObject.activeInHierarchy)
        {
            targetWood = null;
        }
    }


    private Transform FindClosestWood()
    {
        GameObject[] woodObjects = GameObject.FindGameObjectsWithTag("Wood");
        float closestDistance = Mathf.Infinity;
        Transform closestWood = null;

        foreach (GameObject wood in woodObjects)
        {
            float distance = Vector2.Distance(transform.position, wood.transform.position);
            if (distance < closestDistance)
            {
                closestDistance = distance;
                closestWood = wood.transform;
            }
        }

        return closestWood;
    }
}

