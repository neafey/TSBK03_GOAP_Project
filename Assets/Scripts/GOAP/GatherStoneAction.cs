using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GatherStoneAction : GOAPAction
{
    private ResourceManager resourceManager;
    private Transform targetStone;
    private float speed = 5f; // Movement speed
    private bool isDone;

    void Start()
    {
        resourceManager = GetComponent<ResourceManager>();
    }

    public override bool CanExecute(GOAPGoal goal)
    {
        if (goal.Name != "Craft Arrows") return false;

        targetStone = FindClosestStone();
        return resourceManager != null && targetStone != null;
    }

    public override void Perform()
    {
        if (targetStone == null)
        {
            isDone = true;
            return;
        }

        // Move towards the stone
        Vector2 direction = (targetStone.position - transform.position).normalized;
        transform.position += (Vector3)direction * speed * Time.deltaTime;

        // Check if NPC has reached the stone
        if (Vector2.Distance(transform.position, targetStone.position) < 0.1f)
        {
            //resourceManager.AddResource("Stone", 5);
            //Destroy(targetStone.gameObject);
            isDone = true;
        }
    }

    public override bool IsDone => isDone;

    public override void ResetAction()
    {
        isDone = false;
        if (targetStone == null || !targetStone.gameObject.activeInHierarchy)
        {
            targetStone = null;
        }
    }

    private Transform FindClosestStone()
    {
        GameObject[] stoneObjects = GameObject.FindGameObjectsWithTag("Stone");
        float closestDistance = Mathf.Infinity;
        Transform closestStone = null;

        foreach (GameObject stone in stoneObjects)
        {
            float distance = Vector2.Distance(transform.position, stone.transform.position);
            if (distance < closestDistance)
            {
                closestDistance = distance;
                closestStone = stone.transform;
            }
        }

        return closestStone;
    }
}

