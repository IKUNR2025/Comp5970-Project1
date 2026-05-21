using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    [Header("UI Text")]
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI finalScoreText;

    [Header("UI Panels")]
    public GameObject startPanel;
    public GameObject gameOverPanel;

    private int score = 0;
    private bool gameOver = false;
    private bool gameStarted = false;

    void Awake()
    {
        Instance = this;
    }

    void Start()
    {
        score = 0;
        gameOver = false;
        gameStarted = false;

        UpdateScoreText();

        if (startPanel != null)
        {
            startPanel.SetActive(true);
        }

        if (gameOverPanel != null)
        {
            gameOverPanel.SetActive(false);
        }

        if (scoreText != null)
        {
            scoreText.gameObject.SetActive(false);
        }

        Time.timeScale = 0f;
    }

    public void StartGame()
    {
        Debug.Log("Start Game clicked");

        gameStarted = true;
        gameOver = false;

        if (startPanel != null)
        {
            startPanel.SetActive(false);
        }

        if (gameOverPanel != null)
        {
            gameOverPanel.SetActive(false);
        }

        if (scoreText != null)
        {
            scoreText.gameObject.SetActive(true);
        }

        Time.timeScale = 1f;
    }

    public void AddScore()
    {
        if (!gameStarted || gameOver)
        {
            return;
        }

        score++;
        UpdateScoreText();
    }

    void UpdateScoreText()
    {
        if (scoreText != null)
        {
            scoreText.text = "Score: " + score.ToString();
        }
        else
        {
            Debug.LogWarning("ScoreText is not assigned in GameManager.");
        }
    }

    public void GameOver()
    {
        if (!gameStarted || gameOver)
        {
            return;
        }

        gameOver = true;

        if (scoreText != null)
        {
            scoreText.gameObject.SetActive(false);
        }

        if (gameOverPanel != null)
        {
            gameOverPanel.SetActive(true);
        }

        if (finalScoreText != null)
        {
            finalScoreText.text = "Final Score: " + score.ToString();
        }
        else
        {
            Debug.LogWarning("FinalScoreText is not assigned in GameManager.");
        }

        Time.timeScale = 0f;
    }

    public bool IsGameOver()
    {
        return gameOver;
    }

    public bool IsGameStarted()
    {
        return gameStarted;
    }

    public void RestartGame()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}