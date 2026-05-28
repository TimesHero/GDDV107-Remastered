using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class MainMenuManager : MonoBehaviour
{
    [Header("UI Elements")]
    [SerializeField] private TextMeshProUGUI highScoreDisplay;

    private void Start()
    {
        if (highScoreDisplay != null)
        {
            int currentHighScore = PlayerPrefs.GetInt("HighScore", 0);
            highScoreDisplay.text = $"High Score: {currentHighScore}";
        }
    }

    public void PlayGameScene()
    {
        SceneManager.LoadScene("GameScene");
    }
    public void MainMenuScene()
    {
        SceneManager.LoadScene("MainMenuScene");
    }

    public void QuitGame()
    {
        Application.Quit();
    }


}
