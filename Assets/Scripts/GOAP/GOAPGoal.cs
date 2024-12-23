using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GOAPGoal
{
    public string Name { get; private set; }
    private System.Func<int> priorityCalculator; // Function to calculate priority
    public System.Func<bool> IsRelevant { get; private set; }

    public GOAPGoal(string name, System.Func<int> priorityCalculator, System.Func<bool> isRelevant)
    {
        Name = name;
        this.priorityCalculator = priorityCalculator;
        IsRelevant = isRelevant;
    }

    public int GetPriority()
    {
        return priorityCalculator.Invoke(); // Calculate the current priority dynamically
    }
}


