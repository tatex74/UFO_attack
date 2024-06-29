using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Ennemi_2 : MonoBehaviour, IEnnemi
{
    public GameObject bullet;
    public GameObject explosion;
    public GameObject powerUp;
    public Sprite after_image_sprite;
    public GameObject after_image;
    private float after_image_timer = 0;
    private Rigidbody2D rb;
    private int pv = 5;
    private Vector2 velocity = new Vector2(-3, 0);
    private float pause_time = 2f;
    private bool isMoving = true;
    private  float fire_frequency = 1f;
    void Start()
    {
        gameObject.name = "Ennemi_2";
        gameObject.tag = "Ennemi";
        transform.position = new Vector3(13, Random.Range(-4, 3), 0);
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
        pause_time -= Time.deltaTime;
        if (pause_time <= 0) {
            if (isMoving) {
                rb.velocity = new Vector2(0, 0);
                isMoving = false;
            } else {
                rb.velocity = velocity;
                isMoving = true;
            }
            pause_time = 2f;
        }
    }

    public void Fire() {
        fire_frequency -= Time.deltaTime;
        if (fire_frequency <= 0){
            GameObject new_bullet1 = Instantiate(bullet, new Vector3(transform.position.x, transform.position.y, 0), Quaternion.identity);
            GameObject new_bullet2 = Instantiate(bullet, new Vector3(transform.position.x, transform.position.y, 0), Quaternion.identity);
            Rigidbody2D rb1 = new_bullet1.GetComponent<Rigidbody2D>();
            Rigidbody2D rb2 = new_bullet2.GetComponent<Rigidbody2D>();
            rb1.velocity = new Vector2(-5, -1.5f);
            rb2.velocity = new Vector2(-5, 1.5f);
            fire_frequency = 1f;
            FindObjectOfType<SoundManagerUFO>().PlaySound(3);
        }
    }

    public void OnCollisionEnter2D(Collision2D collision) {
        if (collision.gameObject.name == "Bullet") {
            pv -= 1;
            if (pv <= 0) {
                DestroyEnnemi();
            }
        }
        else if (collision.gameObject.name == "Player Starter") {
            DestroyEnnemi();
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

    public void DestroyEnnemi() {
        GameObject new_explosion = Instantiate(explosion, new Vector3(transform.position.x, transform.position.y, transform.position.z), Quaternion.identity);
        new_explosion.transform.localScale = new Vector3(0.3f, 0.3f, 0);
        Destroy(gameObject);
        FindObjectOfType<SoundManagerUFO>().PlaySound(7);
        FindObjectOfType<ScoreManager>().AddScore(EnemyType.Enemy2);
        
        if (Random.Range(0, 7) == 0) {
            GameObject newPowerUp = Instantiate(powerUp, new Vector3(transform.position.x, transform.position.y, 0), Quaternion.identity);
            Rigidbody2D rb = newPowerUp.GetComponent<Rigidbody2D>();
            rb.velocity = new Vector2(-4f, 0);
        }
    }
}
