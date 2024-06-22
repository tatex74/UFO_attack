using System.Collections;
using System.Collections.Generic;
using Unity.Properties;
using Unity.VisualScripting.Dependencies.Sqlite;
using UnityEngine;

public class Ennemi_1 : MonoBehaviour
{
    public GameObject explosion;
    public Sprite after_image_sprite;
    public GameObject after_image;
    private float after_image_timer = 0;
    private Rigidbody2D rb;
    private float time = 1;
    private int pv = 1;
    // Start is called before the first frame update
    void Start()
    {
        gameObject.name = "Ennemi_1";
        transform.position = new Vector3(13, Random.Range(-4, 3), 0);
        rb = gameObject.GetComponent<Rigidbody2D>();
        rb.velocity = new Vector2(-5, 0);

        SpriteRenderer sr = after_image.GetComponent<SpriteRenderer>();
        sr.sprite = after_image_sprite;
    }

    // Update is called once per frame
    void Update()
    {
        Mouvement();
        AfterImage();

        if (transform.position.x < -13) {
            Destroy(gameObject);
        }
    }

    public void Mouvement() {
        if (transform.position.x <= 7 && time != 0) {
            if (time > 0) {
                rb.velocity = new Vector2(0, 0);
                time -= Time.deltaTime;
            }
            else if (time < 0) {
                 rb.velocity = new Vector2(-10, 0);
            }
            else  {
                time = 0;
            }
        }
    }

    public void OnCollisionEnter2D(Collision2D collision) {
        if (collision.gameObject.name == "Bullet") {
            pv -= 1;
            if (pv <= 0) {
                GameObject new_explosion = Instantiate(explosion, new Vector3(transform.position.x, transform.position.y, transform.position.z), Quaternion.identity);
                new_explosion.transform.localScale = new Vector3(0.3f, 0.3f, 0);
                Destroy(gameObject);
                FindObjectOfType<SoundManager>().PlaySound(6);
            }
            FindObjectOfType<ScoreManager>().AddScore(EnemyType.Enemy1);
        }
        else if (collision.gameObject.name == "Player Starter") {
            GameObject new_explosion = Instantiate(explosion, new Vector3(transform.position.x, transform.position.y, transform.position.z), Quaternion.identity);
            new_explosion.transform.localScale = new Vector3(0.3f, 0.3f, 0);
            Destroy(gameObject);
            FindObjectOfType<ScoreManager>().AddScore(EnemyType.Enemy1);
            FindObjectOfType<SoundManager>().PlaySound(6);
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
