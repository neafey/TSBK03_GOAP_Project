using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;

public class GOAPPlanner : MonoBehaviour
{
    public List<GOAPGoal> goals = new List<GOAPGoal>();
    public List<GOAPAction> actions = new List<GOAPAction>();
    private GOAPAction currentAction;

    [Header("UI")]
    public TextMeshProUGUI currentActionText;

    void Start()
    {
        actions.AddRange(GetComponents<GOAPAction>());

        // Hunger goal
        HungerSystem hungerSystem = GetComponent<HungerSystem>();
        goals.Add(new GOAPGoal(
            "Increase Hunger",
            () =>
            {
                float currentHunger = hungerSystem.currentHunger;
                return currentHunger < 50 ? 10 : (currentHunger < 80 ? 5 : 1); // Dynamic priority based on hunger level
            },
            () => hungerSystem != null && GameObject.FindGameObjectsWithTag("Food").Length > 0
        ));

        // Craft Arrows goal
        ResourceManager resourceManager = GetComponent<ResourceManager>();
        goals.Add(new GOAPGoal(
            "Craft Arrows",
            () =>
            {
                int arrowCount = resourceManager.arrowCount;
                return arrowCount < 5 ? 7 : 2; // Higher priority when arrows are below 5
            },
            () => resourceManager != null &&
                ((GameObject.FindGameObjectsWithTag("Wood").Length > 0) ||
                (GameObject.FindGameObjectsWithTag("Stone").Length > 0))
        ));

        goals.Add(new GOAPGoal(
            "Handle Enemies",
            () =>
            {
                return resourceManager.arrowCount > 0 ? 4 : 0; // Higher priority if arrows are available
            },
            () => GameObject.FindGameObjectsWithTag("Enemy").Length > 0
        ));
    }


    void Update()
    {
        if (ShouldChangeAction())
        {
            ChooseNextGoal(); // Switch to a higher priority action if needed
        }
        else if (currentAction == null || currentAction.IsDone)
        {
            ChooseNextGoal(); // Continue with the next available action
        }
        else
        {
            currentAction.Perform();
        }
        UpdateCurrentActionText();
    }

    private bool ShouldChangeAction()
    {
        // Check if a higher-priority goal has become relevant
        var relevantGoals = goals
            .Where(goal => goal.IsRelevant())
            .OrderByDescending(goal => goal.GetPriority())
            .ToList();

        if (relevantGoals.Count > 0)
        {
            var highestPriorityGoal = relevantGoals[0];
            if (currentAction != null && currentAction.CanExecute(highestPriorityGoal))
            {
                // If the current action is aligned with the highest-priority goal, no need to switch
                return false;
            }

            // If another action can better serve the highest-priority goal, switch action
            return true;
        }

        return false;
    }

    private void ChooseNextGoal()
    {
        var relevantGoals = goals
            .Where(goal => goal.IsRelevant())
            .OrderByDescending(goal => goal.GetPriority())
            .ToList();


        if (relevantGoals.Count > 0)
        {
            foreach (var action in actions)
            {
                if (action.CanExecute(relevantGoals[0]))
                {
                    currentAction = action;
                    action.ResetAction();
                    return;
                }
            }
        }

        currentAction = null; // No valid action found
    }

    private void UpdateCurrentActionText()
    {
        if (currentActionText != null)
        {
            if (currentAction != null)
            {
                currentActionText.text = $"Action: {FormatActionName(currentAction.GetType().Name)}";
            }
            else
            {
                currentActionText.text = "Action: Idle";
            }
        }
    }

    private string FormatActionName(string actionName)
    {
        if (actionName.EndsWith("Action"))
        {
            return actionName.Replace("Action", "").Replace("Gather", "Gathering");
        }
        return actionName;
    }
}
