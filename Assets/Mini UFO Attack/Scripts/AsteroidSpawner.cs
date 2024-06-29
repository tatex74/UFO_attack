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

    float big_time;
    float mid_time;
    float small_time;

    // Start is called before the first frame update
    void Start()
    {
        big_time = Random.Range(0, 5);
        mid_time = Random.Range(0, 5);
        small_time = Random.Range(0, 3);
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
            asteroid.transform.position = new UnityEngine.Vector3(12, Random.Range(-5, 5), 10);
            rigidbody = asteroid.GetComponent<Rigidbody2D>();
            rigidbody.velocity = new UnityEngine.Vector2(-1, 0);
            rigidbody.angularVelocity = Random.Range(10, 20);
            spriteRenderer = asteroid.GetComponent<SpriteRenderer>();
            spriteRenderer.sprite = big_asteroids[Random.Range(0, big_asteroids.Length-1)];
            big_time = Random.Range(4, 8);
        }


        if (mid_time <= 0) {
            asteroid = Instantiate(asteroid_prefab);
            asteroid.transform.position = new UnityEngine.Vector3(12, Random.Range(-5, 5), 9);
            rigidbody = asteroid.GetComponent<Rigidbody2D>();
            rigidbody.velocity = new UnityEngine.Vector2(-2, 0);
            rigidbody.angularVelocity = Random.Range(10, 20);
            spriteRenderer = asteroid.GetComponent<SpriteRenderer>();
            spriteRenderer.sprite = mid_asteroids[Random.Range(0, mid_asteroids.Length-1)];
            mid_time = Random.Range(3, 6);
        }
        
        
        if (small_time <= 0) {
            asteroid = Instantiate(asteroid_prefab);
            asteroid.transform.position = new UnityEngine.Vector3(12, Random.Range(-5, 5), 8);
            rigidbody = asteroid.GetComponent<Rigidbody2D>();
            rigidbody.velocity = new UnityEngine.Vector2(-4, 0);
            rigidbody.angularVelocity = Random.Range(10, 20);
            spriteRenderer = asteroid.GetComponent<SpriteRenderer>();
            spriteRenderer.sprite = small_asteroids[Random.Range(0, small_asteroids.Length-1)];
            small_time = Random.Range(1, 3);
        }
        
        
    }
}
