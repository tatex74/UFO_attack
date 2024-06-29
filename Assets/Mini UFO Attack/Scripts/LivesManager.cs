using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Class responsible for managing the player's lives and displaying
/// the corresponding life sprites.
/// </summary>
public class LivesManager : MonoBehaviour
{
    // The prefab of the life sprite
    public GameObject lifePrefab;

    // The container where the life sprites will be instantiated
    public Transform livesContainer;
    
    // The spacing between life sprites
    public float lifeSpacing = 20f;

    // The initial number of lives
    public int initialLives = 10;

    // The current number of lives
    private int currentLives;

    void Start()
    {
        // Initialize the current number of lives
        currentLives = initialLives;

        // Instantiate the life sprites
        for (int i = 0; i < currentLives; i++)
        {
            GameObject life = Instantiate(lifePrefab, livesContainer);
            life.transform.localPosition = new Vector3(i * lifeSpacing, 0, 0);
        }
    }

    /// <summary>
    /// Called when the player loses a life.
    /// </summary>
    public void LoseLife()
    {
        // Decrement the current number of lives
        currentLives--;

        // Remove the last life sprite from the container
        Transform lastLife = livesContainer.GetChild(livesContainer.childCount - 1);
        Destroy(lastLife.gameObject);

        // Check if the player has no lives left
        if (currentLives <= 0)
        {
            // Game over! You can add your own game over logic here
            FindObjectOfType<Player>().GameOver();
        }
    }

    /// <summary>
    /// Called when the player gains a life.
    /// </summary>
    public void GainLife()
    {
        // Increment the current number of lives
        if (currentLives < initialLives){
            currentLives++;
        }

        // Instantiate a new life sprite
        GameObject life = Instantiate(lifePrefab, livesContainer);
        life.transform.localPosition = new Vector3((currentLives - 1) * lifeSpacing, 0, 0);
    }
}
