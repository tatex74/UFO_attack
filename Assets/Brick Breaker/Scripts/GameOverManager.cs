using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

/// <summary>
/// Manages the game over screen and provides methods to restart, go to the main menu, and exit the game.
/// </summary>
public class GameOverManager : MonoBehaviour
{
    public GameObject gameOverPanel;
    public TextMeshPro scoreText;

    private void Start()
    {
        HideGameOver();
    }

    /// <summary>
    /// Shows the game over panel with the given score.
    /// </summary>
    /// <param name="score">The score to display.</param>
    public void ShowGameOver(int score)
    {
        gameOverPanel.SetActive(true);
        scoreText.SetText( "Score = " + score);
        Time.timeScale = 0; // Pause the game
    }

    /// <summary>
    /// Hides the game over panel.
    /// </summary>
    public void HideGameOver()
    {
        gameOverPanel.SetActive(false);
        Time.timeScale = 1; // Resume the game
    }

    /// <summary>
    /// Restarts the game by reloading the current scene.
    /// </summary>
    public void RestartGame()
    {
        Time.timeScale = 1; // Resume the game in case it was paused
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    /// <summary>
    /// Goes back to the main menu scene.
    /// </summary>
    public void MainMenu()
    {
        Time.timeScale = 1; // Resume the game in case it was paused
        SceneManager.LoadScene(0);
    }

    /// <summary>
    /// Exits the game.
    /// </summary>
    public void ExitGame()
    {
        Application.Quit();
    }
}
