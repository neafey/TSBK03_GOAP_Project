using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverManager : MonoBehaviour
{
    [Header("UI References")]
    public GameObject endStateCanvas;

    private NPC npc; 
    private bool isGameOver = false;

    void Start()
    {
        npc = FindObjectOfType<NPC>();
        endStateCanvas.SetActive(false);
    }

    void Update()
    {
        if (npc != null && npc.healthSystem != null && npc.healthSystem.currentHealth <= 0 && !isGameOver)
        {
            TriggerGameOver();
        }
    }

    void TriggerGameOver()
    {
        isGameOver = true;
        endStateCanvas.SetActive(true);
        Time.timeScale = 0f;
    }

    public void ReturnToMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("StartMenu");
    }
}
