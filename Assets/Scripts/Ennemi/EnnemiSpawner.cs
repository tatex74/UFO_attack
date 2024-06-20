using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class EnnemiSpawner : MonoBehaviour
{
    public GameObject[] ennemis;
    private float time_1 = Random.Range(5, 10);
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        time_1 -= Time.deltaTime;

        if (time_1 < 0) {
            Instantiate(ennemis[0]);
            time_1 = Random.Range(5, 10);
        }
    }
}
