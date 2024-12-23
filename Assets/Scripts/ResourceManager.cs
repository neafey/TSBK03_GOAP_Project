using UnityEngine;
using TMPro;

public class ResourceManager : MonoBehaviour
{
    public int woodCount = 0;
    public int stoneCount = 0;
    public int arrowCount = 0; 
    public TextMeshProUGUI woodText;
    public TextMeshProUGUI stoneText;
    public TextMeshProUGUI arrowText;

    void Start()
    {
        UpdateResourceText();
    }

    public void AddResource(string resourceType, int amount)
    {
        if (resourceType == "Wood")
        {
            woodCount += amount;
        }
        else if (resourceType == "Stone")
        {
            stoneCount += amount;
        }
        UpdateResourceText();
        TryCreateArrows(); // Try to create arrows after adding resources
    }

    private void TryCreateArrows()
    {
        while (woodCount >= 5 && stoneCount >= 5) // Keep creating arrows as long as resources are enough
        {
            woodCount -= 5;
            stoneCount -= 5;
            arrowCount += 5;
        }
        UpdateResourceText();
    }

    public void UpdateResourceText()
    {
        if (woodText != null)
        {
            woodText.text = $"Wood: {woodCount}";
        }
        if (stoneText != null)
        {
            stoneText.text = $"Stone: {stoneCount}";
        }
        if (arrowText != null)
        {
            arrowText.text = $"Arrows: {arrowCount}";
        }
    }
}
