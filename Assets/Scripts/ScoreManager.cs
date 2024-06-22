using UnityEngine;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    // The TextMesh Pro component that displays the score
    public TextMeshPro scoreText;

    // The initial score
    public int initialScore = 0;

    // The current score
    private int currentScore;

    void Start()
    {
        // Initialize the current score
        currentScore = initialScore;

        // Update the score text
        UpdateScoreText();
    }

    // Call this function when the player defeats an enemy
    public void AddScore(EnemyType enemyType)
    {
        // Add the corresponding score to the current score
        switch (enemyType)
        {
            case EnemyType.Enemy1:
                currentScore += 10;
                break;
            case EnemyType.Enemy2:
                currentScore += 20;
                break;
            case EnemyType.Enemy3:
                currentScore += 30;
                break;
            case EnemyType.Enemy4:
                currentScore += 40;
                break;
        }

        // Update the score text
        UpdateScoreText();
    }

    // Update the score text
    private void UpdateScoreText()
    {
        scoreText.SetText(currentScore.ToString());
    }
}

public enum EnemyType
{
    Enemy1,
    Enemy2,
    Enemy3,
    Enemy4
}