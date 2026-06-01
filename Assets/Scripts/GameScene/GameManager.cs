using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    [Header("UI Elements")]
    [SerializeField] private TextMeshProUGUI scoreText;
    [SerializeField] private GameObject gameOverPanel;
    [SerializeField] private TextMeshProUGUI finalScoreText;
    [SerializeField] private GameObject gameOverFX;

    [Header("Score Settings")]
    [SerializeField] private float baseScorePerSecond = 10f;
    [SerializeField] private int nearMissBonus = 50;

    public bool isGameOver = false;
    
    // TL;DR: Float allows for smooth fractional addition via Time.deltaTime.
    public float currentScore = 0f; 

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Update()
    {
        if (isGameOver) return;

        //Increments the score constantly while the game is active.
        currentScore += baseScorePerSecond * Time.deltaTime;

        if (scoreText != null)
        {
            //Mathf.FloorToInt drops the decimal places for cleaner UI.
            scoreText.text = $"Score: {Mathf.FloorToInt(currentScore)}";
        }
    }

#region GAMEOVER_THINGS

    public void TriggerGameOver()
    {
        isGameOver = true;
        Debug.Log("Game Over.");
        //Blood FX
        if (gameOverFX != null)
        {
            gameOverFX.SetActive(true);
        }

        int currentFinalScore = Mathf.FloorToInt(currentScore);
        int savedHighScore = PlayerPrefs.GetInt("HighScore", 0);

        if (currentFinalScore > savedHighScore)
        {
            PlayerPrefs.SetInt("HighScore", currentFinalScore);
            PlayerPrefs.Save();
        }

        if (gameOverPanel != null)
        {
            gameOverPanel.SetActive(true);
        
            finalScoreText.text = $"Final Score:  {Mathf.FloorToInt(currentScore)}";
        }
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void LoadMainMenu()
    {
        SceneManager.LoadScene("MainMenuScene");
    }

#endregion

    public void RegisterNearMiss()
    {
        if (isGameOver) return;

        // Applies a flat point bonus when the player executes a near miss.
        currentScore += nearMissBonus;
        Debug.Log("Near Miss! Bonus awarded. Score: " + Mathf.FloorToInt(currentScore));
    }
}