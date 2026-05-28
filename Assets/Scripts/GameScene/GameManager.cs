using UnityEngine;

public class GameManager : MonoBehaviour
{
    //allows any other script to access GameManager variables and methods directly via GameManager.Instance
    public static GameManager Instance { get; private set; }

    public bool isGameOver = false;

    private void Awake()
    {
        // Enforces the Singleton pattern. If an instance already exists, destroy the duplicate.
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void TriggerGameOver()
    {
        isGameOver = true;
        Debug.Log("Game Over state triggered.");
        
        // Priority 3 UI logic will be inserted here later
    }
}