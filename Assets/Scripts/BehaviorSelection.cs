using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BehaviorSelection : MonoBehaviour
{
    public static BehaviorType SelectedBehavior { get; private set; }

    public enum BehaviorType { GOAP, ST }

    public void SelectGOAP()
    {
        SelectedBehavior = BehaviorType.GOAP;
        LoadGameScene();
    }

    public void SelectST()
    {
        SelectedBehavior = BehaviorType.ST;
        LoadGameScene();
    }

    private void LoadGameScene()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("MainScene"); 
    }
}

