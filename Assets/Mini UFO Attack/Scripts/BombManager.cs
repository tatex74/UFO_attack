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
    public Transform player;

    public SpriteRenderer whiteScreenSprite;

    public float whiteScreenDuration = 1.0f;
    private bool isBombActivated = false;
    private float bombTimer = 0f;

    /// <summary>
    /// Initializes the bomb manager and sets up the initial bomb sprites.
    /// Also tries to find and store references to enemy scripts.
    /// </summary>
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

        // Initially, the white screen sprite should be disabled
        whiteScreenSprite.gameObject.SetActive(false);

        try{
            // Find and store references to enemy scripts
            // Note: This may fail if the enemy scripts are not yet initialized
            IEnnemi[] ennemis = new IEnnemi[]
            {
                FindObjectOfType<Ennemi_1>().GetComponent<Ennemi_1>(),
                FindObjectOfType<Ennemi_2>().GetComponent<Ennemi_2>(),
                FindObjectOfType<Ennemi_3>().GetComponent<Ennemi_3>(),
                FindObjectOfType<Ennemi_4>().GetComponent<Ennemi_4>()
            };
        }catch (System.NullReferenceException){
        }
    }

    /// <summary>
    /// Update is called every frame, if the MonoBehaviour is enabled.
    /// Handles the bomb activation and growing effect.
    /// </summary>
    private void Update()
    {
        // Detect key press "A"
        if (Input.GetKeyDown(KeyCode.Q) && currentBombs > 0)
        {
            UseBomb();
        }

        // If the bomb is activated, handle the timer and growing effect
        if (isBombActivated)
        {
            bombTimer += Time.deltaTime;

            // Calculate the scale factor based on the timer
            float scaleFactor = 35f * bombTimer / whiteScreenDuration;

            // Scale the white screen sprite
            whiteScreenSprite.transform.localScale = new Vector3(scaleFactor, scaleFactor, 1);

            // Center the white screen sprite on the player
            whiteScreenSprite.transform.position = player.position;

            // If the timer exceeds the duration, deactivate the effect
            if (bombTimer > whiteScreenDuration)
            {
                DeactivateBomb();
            }
        }
    }

    /// <summary>
    /// Call this function when the player uses a bomb
    /// Activates the bomb effect, destroys enemy bullets and enemies, 
    /// activates the bomb flag, resets the timer, decrements the current number of bombs, 
    /// and replaces the last bomb sprite with a dull bomb sprite.
    /// </summary>
    public void UseBomb()
    {
        // Activate the bomb effect
        whiteScreenSprite.gameObject.SetActive(true);
        whiteScreenSprite.transform.localScale = Vector3.zero;

        // Destroy enemy bullets
        GameObject[] allObjects = FindObjectsOfType<GameObject>();
        foreach (GameObject obj in allObjects)
        {
            if (obj.name == "Ennemi_Bullet")
            {
                Destroy(obj);
            }
        }

        // Destroy enemies
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Ennemi");
        foreach (GameObject enemyObject in enemies)
        {
            IEnnemi enemy = enemyObject.GetComponent<IEnnemi>();
            if (enemy != null)
            {
                enemy.DestroyEnnemi(); // Call the DestroyEnemy method
            }
        }

        // Activate the bomb flag and reset the timer
        isBombActivated = true;
        bombTimer = 0f;

        // Decrement the current number of bombs
        currentBombs--;

        // Replace the last bomb sprite with a dull bomb sprite
        Transform lastBomb = bombsParent.GetChild(currentBombs);
        Destroy(lastBomb.gameObject);
        GameObject dullBomb = Instantiate(dullBombPrefab, lastBomb.position, lastBomb.rotation, bombsParent);
        dullBomb.transform.SetSiblingIndex(currentBombs + 1);
        dullBomb.transform.localPosition = lastBomb.localPosition;

        FindObjectOfType<SoundManagerUFO>().PlaySound(12);
    }

    /// <summary>
    /// Deactivates the bomb effect.
    /// </summary>
    private void DeactivateBomb()
    {
        // Deactivate the bomb effect
        whiteScreenSprite.gameObject.SetActive(false);
        isBombActivated = false;
    }

    /// <summary>
    /// Call this function when the player gains a bomb.
    /// Increments the current number of bombs and replaces the last bomb sprite with a clear bomb sprite.
    /// </summary>
    public void GainBomb()
    {
        // Increment the current number of bombs
        if(currentBombs < initialBombs){
            currentBombs++;
        }
        
        // Replace the last bomb sprite with a clear bomb sprite
        Transform lastBomb = bombsParent.GetChild(currentBombs-1);
        Destroy(lastBomb.gameObject);
        GameObject clearBomb = Instantiate(bombPrefab, lastBomb.position, lastBomb.rotation, bombsParent);
        clearBomb.transform.SetSiblingIndex(currentBombs);
        clearBomb.transform.localPosition = lastBomb.localPosition;
    }
}
