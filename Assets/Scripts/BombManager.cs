using UnityEngine;
using UnityEngine.UI;

public class BombManager : MonoBehaviour
{
    // The prefab of the bomb sprite
    public GameObject bombPrefab;

    // The prefab of the dull bomb sprite
    public GameObject dullBombPrefab;

    // The parent object that contains the bomb sprites
    public Transform bombsParent;

    // The initial number of bombs
    public int initialBombs = 4;

    // The spacing between bomb sprites
    public float bombSpacing = 0.5f;

    // The current number of bombs
    private int currentBombs;

    void Start()
    {
        // Initialize the current number of bombs
        currentBombs = initialBombs;

        // Instantiate the bomb sprites
        for (int i = 0; i < currentBombs; i++)
        {
            GameObject bomb = Instantiate(bombPrefab, bombsParent);
            bomb.transform.localPosition = new Vector3(i * bombSpacing, 0, 0);
        }
    }

    // Call this function when the player uses a bomb
    public void UseBomb()
    {
        // Decrement the current number of bombs
        currentBombs--;

        // Replace the last bomb sprite with a dull bomb sprite
        Transform lastBomb = bombsParent.GetChild(bombsParent.childCount - 1);
        Destroy(lastBomb.gameObject);
        GameObject dullBomb = Instantiate(dullBombPrefab, lastBomb.position, lastBomb.rotation, bombsParent);
        dullBomb.transform.localPosition = lastBomb.localPosition;
    }

    // Call this function when the player gains a bomb
    public void GainBomb()
    {
        // Increment the current number of bombs
        currentBombs++;

        // Instantiate a new bomb sprite
        GameObject bomb = Instantiate(bombPrefab, bombsParent);
        bomb.transform.localPosition = new Vector3((currentBombs - 1) * bombSpacing, 0, 0);
    }
}