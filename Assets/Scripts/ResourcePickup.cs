using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResourcePickup : MonoBehaviour
{
    public string resourceType; // E.g., "Wood", "Stone"
    public int resourceAmount = 5;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        ResourceManager resourceManager = collision.GetComponent<ResourceManager>();
        if (resourceManager != null)
        {
            resourceManager.AddResource(resourceType, resourceAmount);
            Destroy(gameObject);
        }
    }
}
