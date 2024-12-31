using System.Resources;
using UnityEngine;
using TMPro;

public class FSMController : MonoBehaviour
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
                NextTask();
                return;
            }
        }

        UpdateActionText("Gathering Wood");
        MoveToTarget();

        if (Vector2.Distance(transform.position, targetResource.position) < 0.1f)
        {
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
                NextTask();
                return;
            }
        }

        UpdateActionText("Gathering Stone");
        MoveToTarget();

        if (Vector2.Distance(transform.position, targetResource.position) < 0.1f)
        {
            targetResource = null;
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
            NextTask();
            return;
        }

        if (targetResource == null)
        {
            targetResource = FindClosestResource("Enemy");

            if (targetResource == null)
            {
                NextTask();
                return;
            }
        }

        UpdateActionText("Killing Enemy");
        MoveToTarget();

        if (targetResource != null && Vector2.Distance(transform.position, targetResource.position) < 0.1f)
        {
            targetResource = null; 
            NextTask();
        }
    }

    private void Idle()
    {
        UpdateActionText("Idling");
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
