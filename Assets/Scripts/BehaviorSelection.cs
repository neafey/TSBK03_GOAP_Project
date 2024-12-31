using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class BehaviorSelection : MonoBehaviour
{
    public static BehaviorType SelectedBehavior { get; private set; }

    public enum BehaviorType { GOAP, FSM }

    public void SelectGOAP()
    {
        SelectedBehavior = BehaviorType.GOAP;
        LoadGameScene();
    }

    public void SelectFSM()
    {
        SelectedBehavior = BehaviorType.FSM;
        LoadGameScene();
    }

    private void LoadGameScene()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("MainScene"); 
    }
}

