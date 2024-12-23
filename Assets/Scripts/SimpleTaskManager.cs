using System.Resources;
using UnityEngine;
using TMPro;

public class SimpleTaskManager : MonoBehaviour
{
    private int currentTaskIndex = 0;
    private Transform targetResource;
    public ResourceManager resourceManager;

    public float speed = 5f; // Movement speed

    [Header("UI")]
    public TextMeshProUGUI actionText;

    void Start()
    {
        ExecuteCurrentTask();
        UpdateActionText();
    }

    void Update()
    {
        ExecuteCurrentTask();
    }

    private void ExecuteCurrentTask()
    {
        switch (currentTaskIndex)
        {
            case 0:
                GatherWood();
                break;
            case 1:
                GatherStone();
                break;
            case 2:
                Eat();
                break;
            case 3:
                KillEnemy();
                break;
            default:
                Idle();
                break;
        }
    }

    private void GatherWood()
    {
        if (targetResource == null)
        {
            targetResource = FindClosestResource("Wood");
            if (targetResource == null)
            {
                Debug.Log("No wood available. Skipping to next task.");
                NextTask();
                return;
            }
        }

        UpdateActionText("Gathering Wood");
        MoveToTarget();

        if (Vector2.Distance(transform.position, targetResource.position) < 0.1f)
        {
            Debug.Log("Wood gathered!");
            //Destroy(targetResource.gameObject);
            targetResource = null; // Reset the target
            NextTask();
        }
    }

    private void GatherStone()
    {
        if (targetResource == null)
        {
            targetResource = FindClosestResource("Stone");
            if (targetResource == null)
            {
                Debug.Log("No stone available. Skipping to next task.");
                NextTask();
                return;
            }
        }

        UpdateActionText("Gathering Stone");
        MoveToTarget();

        if (Vector2.Distance(transform.position, targetResource.position) < 0.1f)
        {
            Debug.Log("Stone gathered!");
            //Destroy(targetResource.gameObject);
            targetResource = null; // Reset the target
            NextTask();
        }
    }

    private void Eat()
    {
        if (targetResource == null)
        {
            targetResource = FindClosestResource("Food");
            if (targetResource == null)
            {
                Debug.Log("No food available. Skipping to next task.");
                NextTask();
                return;
            }
        }

        UpdateActionText("Gathering Food");
        MoveToTarget();

        if (Vector2.Distance(transform.position, targetResource.position) < 0.1f)
        {
            Debug.Log("Food eaten!");
            targetResource = null; 
            NextTask();
        }
    }

    private void KillEnemy()
    {
        if (resourceManager.arrowCount <= 0)
        {
            Debug.Log("No arrows available. Skipping KillEnemy task.");
            NextTask();
            return;
        }

        if (targetResource == null)
        {
            targetResource = FindClosestResource("Enemy");

            if (targetResource == null)
            {
                Debug.LogWarning("No enemies found. Skipping KillEnemy task.");
                NextTask();
                return;
            }
        }

        UpdateActionText("Killing Enemy");
        MoveToTarget();

        if (targetResource != null && Vector2.Distance(transform.position, targetResource.position) < 0.1f)
        {
            Debug.Log("Enemy killed!");
            targetResource = null; 
            NextTask();
        }
    }

    private void Idle()
    {
        UpdateActionText("Idling");
        Debug.Log("Idling...");
    }

    private void MoveToTarget()
    {
        if (targetResource == null) return;

        Vector2 direction = (targetResource.position - transform.position).normalized;
        transform.position += (Vector3)direction * speed * Time.deltaTime;
    }

    private Transform FindClosestResource(string tag)
    {
        GameObject[] resources = GameObject.FindGameObjectsWithTag(tag);
        float closestDistance = Mathf.Infinity;
        Transform closestResource = null;

        foreach (GameObject resource in resources)
        {
            float distance = Vector2.Distance(transform.position, resource.transform.position);
            if (distance < closestDistance)
            {
                closestDistance = distance;
                closestResource = resource.transform;
            }
        }

        return closestResource;
    }

    private void NextTask()
    {
        currentTaskIndex++;
        if (currentTaskIndex >= 4) 
        {
            currentTaskIndex = 0;
        }
        UpdateActionText();
    }

    private void UpdateActionText(string action = "Idle")
    {
        if (actionText != null)
        {
            actionText.text = $"Action: {action}";
        }
    }
}
