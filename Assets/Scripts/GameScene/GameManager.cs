using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using System.Collections;

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

    

    [Header("Misc.")]
    public bool isGameOver = false;
    
    // TL;DR: Float allows for smooth fractional addition via Time.deltaTime.
    public float currentScore = 0f; 

#region AUDIO
    [Header("Audio Things")]
    //audio sources
    [SerializeField] private AudioSource sfxSource;
    [SerializeField] private float sfxAudioFade = 0.25f;
    [SerializeField] private AudioSource ambientAudioSource;
    [SerializeField] private float ambientAudioFadeDuration = 0.25f;
    [SerializeField] private AudioSource musicAudioSource;
    [SerializeField] private float musicAudioFadeDuration = 0.25f;
    //sfx references
    [SerializeField] private AudioClip shipDeathSFX;
    [SerializeField] private AudioClip shipNearMissSFX;
    [SerializeField] private AudioClip toxicCloudPowerDown;
    [SerializeField] private AudioClip toxicCloudPowerUp;
    [SerializeField] private AudioClip shieldPowerUp;
    [SerializeField] private AudioClip shieldExpended;
    [SerializeField] private AudioClip objectDestroyed;

    private IEnumerator FadeOutAudio(AudioSource source, float duration)
    {
        if (source == null ) yield break;

        float startVolume = source.volume;
        float timer = 0f;

        while (timer < duration)
        {
            timer += Time.deltaTime;
            float normalizedTime = timer / duration;

            //control it here
            source.volume = Mathf.Lerp(startVolume, 0f, normalizedTime);

            yield return null;
        }
        source.Stop();
    }

//<Sound Effects>
    private void PlayAudioClip(AudioClip clip)
        {
            if (clip == null || sfxSource ==  null) return;
            sfxSource.PlayOneShot(clip);
        }
        public void PowerDownSFX() => PlayAudioClip(toxicCloudPowerDown);
        public void PowerUpSFX() => PlayAudioClip(toxicCloudPowerUp);
        public void NearMissSFX() => PlayAudioClip(shipNearMissSFX);
        public void ShieldUpSFX() => PlayAudioClip(shieldPowerUp);
        public void ShieldDownSFX() => PlayAudioClip(shieldExpended);
        public void ObjectDestroyedSFX() => PlayAudioClip(objectDestroyed);
//<Sound Effects End>
#endregion

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
        //Blood FX, SoundFX
        if (gameOverFX != null && shipDeathSFX != null)
        {
            AudioSource.PlayClipAtPoint(shipDeathSFX, Camera.main.transform.position);
            gameOverFX.SetActive(true);

            StartCoroutine(FadeOutAudio(musicAudioSource, musicAudioFadeDuration));
            StartCoroutine(FadeOutAudio(ambientAudioSource, ambientAudioFadeDuration));
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
        AudioSource.PlayClipAtPoint(shipNearMissSFX, Camera.main.transform.position);
        currentScore += nearMissBonus;
        Debug.Log("Near Miss! Bonus awarded. Score: " + Mathf.FloorToInt(currentScore));
    }
}