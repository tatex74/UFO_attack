using UnityEngine;
using System.Collections;
using TMPro;
using UnityEngine.SceneManagement;

/// <summary>
/// Manages the game state and gameplay.
/// </summary>
public class GameManager : MonoBehaviour
{
    public BallController ball { get; private set; }
    public PaddleController paddle { get; private set; }
    public GameObject[] liveSprites;
    public TextMeshPro scoreText;    public GameObject readyPanel;
    public int score;
    public int lives;

    /// <summary>
    /// Finds the BallController and PaddleController components at startup.
    /// </summary>
    private void Awake()
    {
        ball = FindObjectOfType<BallController>();
        paddle = FindObjectOfType<PaddleController>();
    }

    /// <summary>
    /// Initializes the game at the start of the game or after a game over.
    /// </summary>
    private void Start()
    {
        NewGame();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            SceneManager.LoadScene(0);
        }
    }

    /// <summary>
    /// Initializes a new game.
    /// </summary>
    public void NewGame()
    {
        score = 0;
        lives = 3;
        updateScore();
        updateLives();
        FindObjectOfType<GameOverManager>().HideGameOver();
        ResetLevel();
        resetPositions();
        HideReady();
        ShowReady();

        SoundManagerBB.Instance.PlayIntroSound();
    }

    /// <summary>
    /// Updates the score text with the current score.
    /// </summary>
    private void updateScore()
    {
        scoreText.SetText("Score = " + score);
    }

    /// <summary>
    /// Updates the lives UI based on the number of lives remaining.
    /// </summary>
    private void updateLives()
    {
        for (int i = 0; i < liveSprites.Length; i++)
        {
            if (i < lives)
            {
                liveSprites[i].SetActive(true);
            }
            else
            {
                liveSprites[i].SetActive(false);
            }
        }
    }

    /// <summary>
    /// Resets the positions of the ball and paddle to their initial positions.
    /// </summary>
    private void resetPositions()
    {
        ball.ResetBall();
        ShowReady();
        paddle.ResetPaddle();
    }

    /// <summary>
    /// Shows the ready panel.
    /// </summary>
    public void ShowReady()
    {
        if (readyPanel != null)
        {
            StartCoroutine(ShowPanel());
        }
    }

    /// <summary>
    /// Shows the ready panel for 2 seconds.
    /// </summary>
    /// <returns>An IEnumerator that will wait for 2 seconds before hiding the panel.</returns>
    private IEnumerator ShowPanel()
    {
        readyPanel.SetActive(true); // Show the panel
        yield return new WaitForSeconds(2); // Wait for 2 seconds
        readyPanel.SetActive(false); // Hide the panel
    }

    /// <summary>
    /// Hides the ready panel.
    /// </summary>
    public void HideReady()
    {
        readyPanel.SetActive(false);
    }

    /// <summary>
    /// Resets the level by destroying all existing bricks and regenerating them.
    /// </summary>
    private void ResetLevel()
    {
        Brick[] existingBricks = FindObjectsOfType<Brick>();

        if (existingBricks.Length > 0)
        {
            foreach (Brick brick in existingBricks)
            {
                Destroy(brick.gameObject);
            }
        }

        FindObjectOfType<LevelGenerator>().Start();
    }

    /// <summary>
    /// Ends the game.
    /// </summary>
    private void GameOver()
    {
        SoundManagerBB.Instance.PlayGameOverSound();

        FindObjectOfType<GameOverManager>().ShowGameOver(score);
    }

    /// <summary>
    /// Decreases the number of lives and updates the lives display.
    /// </summary>
    public void Miss()
    {
        lives--;
        updateLives();
        SoundManagerBB.Instance.PlayPointLoss();

        if (score >= 500)
        {
            score -= 500;
        }
        else
        {
            score = 0;
        }

        updateScore();

        if (lives > 0)
        {
            resetPositions();
        }
        else
        {
            GameOver();
        }
    }

    /// <summary>
    /// Checks if there is only one brick left.
    /// </summary>
    public void CheckRemainingBricks()
    {
        Brick[] remainingBricks = FindObjectsOfType<Brick>();

        if (remainingBricks.Length == 1)
        {
            ResetLevel();
        }
    }

    /// <summary>
    /// Increases the score when a brick is hit.
    /// </summary>
    /// <param name="brick">The brick that was hit.</param>
    public void Hit(Brick brick)
    {
        score += brick.points;
        updateScore();
    }
}
