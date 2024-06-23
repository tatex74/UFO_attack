using UnityEngine;
using System.Collections;
using TMPro;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public BallController ball {get; private set;}
    public PaddleController paddle { get; private set;}
    public GameObject[] liveSprites;
    public TextMeshPro scoreText;
    public GameObject readyPanel;
    public int score;
    public int lives;

    private void Awake(){
        ball = FindObjectOfType<BallController>();
        paddle = FindObjectOfType<PaddleController>();
    }

    private void Start(){
        NewGame();
    }

    private void Update(){
        if (Input.GetKeyDown(KeyCode.Escape)){
            SceneManager.LoadScene(0);
        }
    }

    public void NewGame(){
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

    private void updateScore(){
        scoreText.SetText("Score = " + score);
    }

    private void updateLives(){
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

    private void resetPositions(){
        ball.ResetBall();
        ShowReady();
        paddle.ResetPaddle();
    }

    public void ShowReady(){
        if (readyPanel != null)
        {
            StartCoroutine(ShowPanel());
        }
    }

    private IEnumerator ShowPanel(){
        readyPanel.SetActive(true); // Show the panel
        yield return new WaitForSeconds(2); // Wait for 2 seconds
        readyPanel.SetActive(false); // Hide the panel
    }

    public void HideReady(){
        readyPanel.SetActive(false);
    }

    private void ResetLevel(){
         // Destroy all existing bricks
        Brick[] existingBricks = FindObjectsOfType<Brick>();
        if (existingBricks.Length > 0){
            foreach (Brick brick in existingBricks)
            {
                Destroy(brick.gameObject);
            }
        }

        // Regenerate the bricks
        FindObjectOfType<LevelGenerator>().Start();
    }

    private void GameOver(){
        SoundManagerBB.Instance.PlayGameOverSound();

        FindObjectOfType<GameOverManager>().ShowGameOver(score);
    
    }

    
    public void Miss(){
        lives--;
        updateLives();
        SoundManagerBB.Instance.PlayPointLoss();
        if (score >= 500){
            score-=500;
        }else{
            score = 0;
        }

        updateScore();

        if (lives > 0) {
            resetPositions();
        }else {
            GameOver();
        }
    }

    public void CheckRemainingBricks(){
        Brick[] remainingBricks = FindObjectsOfType<Brick>();
        if (remainingBricks.Length == 1){
            ResetLevel();
        }
    }

    public void Hit(Brick brick){
        score += brick.points;
        updateScore();
    }
}
