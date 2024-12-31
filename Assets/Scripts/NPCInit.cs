using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class NPCInit : MonoBehaviour
{

    public TextMeshProUGUI techniqueText;

    private void Start()
    {
        var behavior = BehaviorSelection.SelectedBehavior;
        Debug.Log(behavior);

        if (behavior == BehaviorSelection.BehaviorType.GOAP)
        {
            GetComponent<GOAPPlanner>().enabled = true;
            if (GetComponent<FSMController>() != null) GetComponent<FSMController>().enabled = false;
            UpdateTechniqueText("GOAP");
        }
        else if (behavior == BehaviorSelection.BehaviorType.FSM)
        {
            if (GetComponent<GOAPPlanner>() != null) GetComponent<GOAPPlanner>().enabled = false;
            GetComponent<FSMController>().enabled = true;
            UpdateTechniqueText("FSM");
        }
    }

    private void UpdateTechniqueText(string technique)
    {
        if (techniqueText != null)
        {
            techniqueText.text = $"Technique: {technique}";
        }
    }
}
