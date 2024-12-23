using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class GOAPAction : MonoBehaviour
{
    public abstract bool CanExecute(GOAPGoal goal);
    public abstract void Perform();
    public abstract bool IsDone { get; }

    public abstract void ResetAction();
}

