using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCInit : MonoBehaviour
{
    private void Start()
    {
        var behavior = BehaviorSelection.SelectedBehavior;
        Debug.Log(behavior);

        if (behavior == BehaviorSelection.BehaviorType.GOAP)
        {
            GetComponent<GOAPPlanner>().enabled = true;
            if (GetComponent<SimpleTaskManager>() != null) GetComponent<SimpleTaskManager>().enabled = false;
            Debug.Log("NPC is using GOAP.");
        }
        else if (behavior == BehaviorSelection.BehaviorType.ST)
        {
            if (GetComponent<GOAPPlanner>() != null) GetComponent<GOAPPlanner>().enabled = false;
            GetComponent<SimpleTaskManager>().enabled = true;
            Debug.Log("NPC is using Simple task.");
        }
    }
}
