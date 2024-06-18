using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;

public class Asteroids : MonoBehaviour
{
    public GameObject asteroid_prefab;
    public Sprite[] big_asteroids;
    public Sprite[] mid_asteroids;
    public Sprite[] small_asteroids;

    float big_time = Random.Range(0, 13);
    float mid_time = Random.Range(0, 6);
    float small_time = Random.Range(0, 5);

    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        GameObject asteroid;
        Rigidbody2D rigidbody;
        SpriteRenderer spriteRenderer;        

        big_time -= Time.deltaTime;
        mid_time -= Time.deltaTime;
        small_time -= Time.deltaTime;

        
        

        if (big_time <= 0) {
            asteroid = Instantiate(asteroid_prefab);
            asteroid.transform.position = new UnityEngine.Vector3(12, Random.Range(-4, 4), 10);
            rigidbody = asteroid.GetComponent<Rigidbody2D>();
            rigidbody.velocity = new UnityEngine.Vector2(-Random.Range(1, 2), 0);
            rigidbody.angularVelocity = Random.Range(10, 20);
            spriteRenderer = asteroid.GetComponent<SpriteRenderer>();
            spriteRenderer.sprite = big_asteroids[Random.Range(0, big_asteroids.Length-1)];
            big_time = Random.Range(10, 13);
        }


        if (mid_time <= 0) {
            asteroid = Instantiate(asteroid_prefab);
            asteroid.transform.position = new UnityEngine.Vector3(12, Random.Range(-4, 4), 9);
            rigidbody = asteroid.GetComponent<Rigidbody2D>();
            rigidbody.velocity = new UnityEngine.Vector2(-Random.Range(2, 3), 0);
            rigidbody.angularVelocity = Random.Range(10, 20);
            spriteRenderer = asteroid.GetComponent<SpriteRenderer>();
            spriteRenderer.sprite = mid_asteroids[Random.Range(0, mid_asteroids.Length-1)];
            mid_time = Random.Range(3, 6);
        }
        
        
        if (small_time <= 0) {
            asteroid = Instantiate(asteroid_prefab);
            asteroid.transform.position = new UnityEngine.Vector3(12, Random.Range(-4, 4), 8);
            rigidbody = asteroid.GetComponent<Rigidbody2D>();
            rigidbody.velocity = new UnityEngine.Vector2(-Random.Range(3, 4), 0);
            rigidbody.angularVelocity = Random.Range(10, 20);
            spriteRenderer = asteroid.GetComponent<SpriteRenderer>();
            spriteRenderer.sprite = small_asteroids[Random.Range(0, small_asteroids.Length-1)];
            small_time = Random.Range(2, 5);
        }
        
        
    }
}
