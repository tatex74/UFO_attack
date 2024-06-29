using UnityEngine;

public class EnnemiSpawner : MonoBehaviour
{
    public GameObject[] ennemis;
    private float time_1;
    private float time_2;
    private float time_3;
    private float time_4;

    private float spawnRateIncreaseInterval = 30f; // Interval at which spawn rates increase
    private float timePassed = 0f; // Time passed since the start or last difficulty increase

    // Start is called before the first frame update
    void Start()
    {
        InitializeSpawnTimes();
    }

    // Update is called once per frame
    void Update()
    {
        UpdateSpawnTimes();

        // Spawn enemies based on time intervals
        SpawnEnemies();
    }

    void InitializeSpawnTimes()
    {
        time_1 = 0f;
        time_2 = Random.Range(3, 6);
        time_3 = Random.Range(5, 10);
        time_4 = Random.Range(5, 10);
    }

    void UpdateSpawnTimes()
    {
        timePassed += Time.deltaTime;

        // Increase difficulty periodically
        if (timePassed >= spawnRateIncreaseInterval)
        {
            // Example: Decrease spawn times to make enemies spawn more frequently
            time_1 = Mathf.Max(time_1 - 0.5f, 1f); // Decrease by 0.5 seconds with a lower limit of 1 second
            time_2 = Mathf.Max(time_2 - 0.5f, 1f);
            time_3 = Mathf.Max(time_3 - 0.5f, 1f);
            time_4 = Mathf.Max(time_4 - 0.5f, 1f);

            // Reset timePassed for next interval
            timePassed = 0f;
        }
    }

    void SpawnEnemies()
    {
        time_1 -= Time.deltaTime;
        time_2 -= Time.deltaTime;
        time_3 -= Time.deltaTime;
        time_4 -= Time.deltaTime;

        if (time_1 <= 0) {
            Instantiate(ennemis[0], transform.position, Quaternion.identity);
            time_1 = Random.Range(1, 4);
        }
        if (time_2 <= 0) {
            Instantiate(ennemis[1], transform.position, Quaternion.identity);
            time_2 = Random.Range(3, 7);
        }
        if (time_3 <= 0) {
            Instantiate(ennemis[2], transform.position, Quaternion.identity);
            time_3 = Random.Range(5, 10);
        }
        if (time_4 <= 0) {
            Instantiate(ennemis[3], transform.position, Quaternion.identity);
            time_4 = Random.Range(5, 10);
        }
    }
}

public interface IEnnemi
{
    void DestroyEnnemi();
}
