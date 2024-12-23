using UnityEngine;

public class EatAction : GOAPAction
{
    private HungerSystem hungerSystem;
    private Transform targetFood;
    private float speed = 5f; // Movement speed
    private bool isDone;

    void Start()
    {
        hungerSystem = GetComponent<HungerSystem>();
    }

    public override bool CanExecute(GOAPGoal goal)
    {
        if (goal.Name != "Increase Hunger") return false;

        targetFood = FindClosestFood();
        return hungerSystem != null && targetFood != null;
    }

    public override void Perform()
    {
        if (targetFood == null)
        {
            isDone = true;
            return;
        }

        Vector2 direction = (targetFood.position - transform.position).normalized;
        transform.position += (Vector3)direction * speed * Time.deltaTime;

        if (Vector2.Distance(transform.position, targetFood.position) < 0.1f)
        {
            //hungerSystem.EatFood(20);
            //Destroy(targetFood.gameObject);
            isDone = true;
        }
    }

    public override bool IsDone => isDone;

    public override void ResetAction()
    {
        isDone = false;
        if (targetFood == null || !targetFood.gameObject.activeInHierarchy)
        {
            targetFood = null;
        }
    }

    private Transform FindClosestFood()
    {
        GameObject[] foodObjects = GameObject.FindGameObjectsWithTag("Food");
        float closestDistance = Mathf.Infinity;
        Transform closestFood = null;

        foreach (GameObject food in foodObjects)
        {
            float distance = Vector2.Distance(transform.position, food.transform.position);
            if (distance < closestDistance)
            {
                closestDistance = distance;
                closestFood = food.transform;
            }
        }

        return closestFood;
    }
}
