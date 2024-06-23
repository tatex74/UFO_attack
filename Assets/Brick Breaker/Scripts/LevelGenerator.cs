using UnityEngine;

public class LevelGenerator : MonoBehaviour
{
    public GameObject brickPrefab;
    public int gridSizeX = 10;
    public int gridSizeY = 10;
    public float probability = 0.5f;
    public Transform brickFolder; // Folder to store brick instances

    public void Start()
    {
        // Center the grid
        float centerX = gridSizeX / 2f;
        float centerY = gridSizeY / 2f - 2;

        for (int x = 0; x < gridSizeX; x+=2)
        {
            for (int y = 0; y < gridSizeY; y++)
            {
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