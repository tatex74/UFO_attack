using UnityEngine;

/// <summary>
/// LevelGenerator generates a grid of bricks with a specified size and probability of spawning.
/// The bricks are placed in a folder specified by the brickFolder Transform.
/// </summary>
public class LevelGenerator : MonoBehaviour
{
    // Brick prefab to spawn
    public GameObject brickPrefab;

    // Size of the grid
    public int gridSizeX = 10;
    public int gridSizeY = 10;

    // Probability of spawning a brick at a given position
    public float probability = 0.5f;

    // Folder to store brick instances
    public Transform brickFolder;

    /// <summary>
    /// Generates the grid of bricks.
    /// </summary>
    public void Start()
    {
        // Center the grid
        float centerX = gridSizeX / 2f;
        float centerY = gridSizeY / 2f - 2;

        for (int x = 0; x < gridSizeX; x+=2)
        {
            for (int y = 0; y < gridSizeY; y++)
            {
                // Spawn a brick with probability
                if (Random.value < probability)
                {
                    // Calculate the position of the brick
                    float brickX = x - centerX;
                    float brickY = y - centerY;

                    // Instantiate the brick
                    GameObject brick = Instantiate(brickPrefab, new Vector3(brickX, brickY, 0), Quaternion.identity);

                    // Set the parent of the brick to the brick folder
                    brick.transform.parent = brickFolder;
                }
            }
        }
    }
}
