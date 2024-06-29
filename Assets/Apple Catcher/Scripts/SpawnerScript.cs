using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerScript : MonoBehaviour
{
    public AudioClip ref_audioClip;
    protected GameObject apple_prefab;
    protected float timer = 3f;
    protected AudioSource ref_audioSource;
    protected float current_alpha = 1;

    // Start is called before the first frame update
    void Start()
    {
        
        apple_prefab = Resources.Load<GameObject>("Apple_prefab");

    }

    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime;

        if ( timer <= 0)
        {
            float randomX = Random.value * 17f - 8.5f;

            GameObject newApple = Instantiate(apple_prefab);
            newApple.transform.position = new Vector3(randomX, 6.0f, 0);

            timer = 0.5f + Random.value*1f ;
        }
        
    }
}
