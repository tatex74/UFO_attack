using UnityEngine;
using TMPro;

/// <summary>
/// ScoreManager is a MonoBehaviour that manages the score display and gradual increase.
/// </summary>
public class ScoreManager : MonoBehaviour
{
    public TextMeshPro scoreText;
    public int initialScore = 0;

    // The current score
    private int currentScore;

    // The target score for gradual increase
    private int targetScore;
    public float scoreIncreaseSpeed = 50f;

    void Start()
    {
        // Initialize the current score
        currentScore = initialScore;
        targetScore = initialScore;

        // Update the score text
        UpdateScoreText();
    }

    /// <summary>
    /// Call this function when the player defeats an enemy.
    /// </summary>
    /// <param name="enemyType">The type of enemy defeated.</param>
    public void AddScore(EnemyType enemyType)
    {
        // Calculate the score to be added based on enemy type
        int scoreToAdd = GetScoreForEnemy(enemyType);

        // Set the target score to the new score after adding
        targetScore += scoreToAdd;
    }

    public int GetCurrentScore() {
        return currentScore;
    }
    // Update is called once per frame
    void Update()
    {
        // Gradually increase the current score towards the target score
        if (currentScore < targetScore)
        {
            float increaseAmount = scoreIncreaseSpeed * Time.deltaTime;
            currentScore = Mathf.Min(currentScore + (int)increaseAmount, targetScore);

            // Update the score text
            UpdateScoreText();
        }
    }

    // Update the score text
    /// <summary>
    /// Update the score text.
    /// </summary>
    private void UpdateScoreText()
    {
        scoreText.SetText(currentScore.ToString());
    }
    
    /// <summary>
    /// Get the score value for each enemy type.
    /// </summary>
    /// <param name="enemyType">The type of enemy.</param>
    /// <returns>The score value for the enemy type.</returns>
    private int GetScoreForEnemy(EnemyType enemyType)
    {
        switch (enemyType)
        {
            case EnemyType.Enemy1:
                return 100;
            case EnemyType.Enemy2:
                return 500;
            case EnemyType.Enemy3:
                return 1000;
            case EnemyType.Enemy4:
                return 4000;
            default:
                return 0;
        }
    }
}

public enum EnemyType
{
    Enemy1,
    Enemy2,
    Enemy3,
    Enemy4
}
