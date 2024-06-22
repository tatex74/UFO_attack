using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class EnnemiSpawner : MonoBehaviour
{
    public GameObject[] ennemis;
    private float time_1;
    private float time_2;
    private float time_3;
    // Start is called before the first frame update
    void Start()
    {
        time_1 = Random.Range(5, 10);
        time_2 = Random.Range(5, 10);
        time_3 = Random.Range(5, 10);
    }

    // Update is called once per frame
    void Update()
    {
        time_1 -= Time.deltaTime;
        time_2 -= Time.deltaTime;
        time_3 -= Time.deltaTime;

        if (time_1 <= 0) {
            Instantiate(ennemis[0]);
            time_1 = Random.Range(5, 10);
        }
        if (time_2 <= 0) {
            Instantiate(ennemis[1]);
            time_2 = Random.Range(5, 10);
        }
        if (time_3 <= 0) {
            Instantiate(ennemis[2]);
            time_3 = Random.Range(5, 10);
        }
    }
}
