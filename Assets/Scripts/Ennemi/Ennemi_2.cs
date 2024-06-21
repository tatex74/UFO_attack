using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Ennemi_2 : MonoBehaviour
{
    public GameObject bullet;
    public GameObject explosion;
    public Sprite after_image_sprite;
    public GameObject after_image;
    private float after_image_timer = 0;
    private Rigidbody2D rb;
    private int pv = 5;
    private Vector2 velocity = new Vector2(-3, 0);
    private float pause_gap = 4;
    private float pause_point = 0;
    private float pause_time = 0;
    private float time = 0;
    public float fire_frequency;
    void Start()
    {
        gameObject.name = "Ennemi_2";
        transform.position = new Vector3(13, Random.Range(-4, 4), 0);
        rb = gameObject.GetComponent<Rigidbody2D>();
        rb.velocity = velocity;

        SpriteRenderer sr = after_image.GetComponent<SpriteRenderer>();
        sr.sprite = after_image_sprite;
    }

    // Update is called once per frame
    void Update()
    {
        Mouvement();
        AfterImage();
        Fire();

        if (transform.position.x < -13) {
            Destroy(gameObject);
        }
    }

    public void Mouvement() {
        if (transform.position.x < pause_point) {
            rb.velocity = new Vector2(0, 0);
            pause_point = transform.position.x - pause_gap;
            time = pause_time;
        }
        if (time < 0) {
            rb.velocity = velocity;
        }
    }

    public void Fire() {
        fire_frequency -= Time.deltaTime;
        if (fire_frequency <= 0){
            Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
            rb.velocity = new Vector2(-2, -1.5f);
            Instantiate(bullet, new Vector3(transform.position.x, transform.position.y, 0), Quaternion.identity);
            rb.velocity = new Vector2(-2, 1.5f);
            Instantiate(bullet, new Vector3(transform.position.x, transform.position.y, 0), Quaternion.identity);
        }
    }

    public void OnCollisionEnter2D(Collision2D collision) {
        if (collision.gameObject.name == "Bullet") {
            pv -= 1;
            if (pv <= 0) {
                GameObject new_explosion = Instantiate(explosion, new Vector3(transform.position.x, transform.position.y, transform.position.z), Quaternion.identity);
                new_explosion.transform.localScale = new Vector3(0.3f, 0.3f, 0);
                Destroy(gameObject);
            }
        }
        else if (collision.gameObject.name == "Player Starter") {
            GameObject new_explosion = Instantiate(explosion, new Vector3(transform.position.x, transform.position.y, transform.position.z), Quaternion.identity);
            new_explosion.transform.localScale = new Vector3(0.3f, 0.3f, 0);
            Destroy(gameObject);
        }
        else {
            //Destroy(gameObject);
        }
    }

    void AfterImage() {

        after_image_timer += Time.deltaTime;

        if (after_image_timer >= 0.1f)
        {
            after_image_timer = 0f;
        
            Instantiate(after_image, new Vector3(transform.position.x, transform.position.y, 6), Quaternion.identity);
        }
    }
}
