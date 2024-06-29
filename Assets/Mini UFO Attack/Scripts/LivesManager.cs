using UnityEngine;
using UnityEngine.UI;

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

    // Call this function when the player loses a life
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
            Debug.Log("Game Over!");
        }
    }

    // Call this function when the player gains a life
    public void GainLife()
    {
        // Increment the current number of lives
        currentLives++;

        // Instantiate a new life sprite
        GameObject life = Instantiate(lifePrefab, livesContainer);
        life.transform.localPosition = new Vector3((currentLives - 1) * lifeSpacing, 0, 0);
    }
}