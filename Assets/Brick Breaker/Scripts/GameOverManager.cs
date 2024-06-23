using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class GameOverManager : MonoBehaviour
{
    public GameObject gameOverPanel;
    public TextMeshPro scoreText;

    private void Start()
    {
        HideGameOver();
    }

    public void ShowGameOver(int score)
    {
        gameOverPanel.SetActive(true);
        scoreText.SetText( "Score = " + score);
        Time.timeScale = 0; // Pause the game
    }

    public void HideGameOver()
    {
        gameOverPanel.SetActive(false);
        Time.timeScale = 1; // Resume the game
    }

    public void RestartGame()
    {
        Time.timeScale = 1; // Resume the game in case it was paused
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void MainMenu()
    {
        Time.timeScale = 1; // Resume the game in case it was paused
        SceneManager.LoadScene(0);
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}
