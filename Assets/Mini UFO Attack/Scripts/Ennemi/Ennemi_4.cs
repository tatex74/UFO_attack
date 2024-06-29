using System.Data.Common;
using UnityEngine;

public class Ennemi_4 : MonoBehaviour, IEnnemi
{
    public GameObject bulletPrefab;
    public GameObject explosion;
    public GameObject powerUp;
    public Sprite after_image_sprite;
    public GameObject after_image;
    private float after_image_timer = 0;
    private Rigidbody2D rb;
    public float pv;
    public float pause_time;
    private bool isMoving = true;
    private bool goingDown = false;
    public Vector2 velocity;

    public float bulletSpeed;
    public float angleRange;
    public float fireRate;
    private float nextFireTime = 0f;
    private float angle = 0f;
    private bool up = true;

     void Start()
    {
        gameObject.name = "Ennemi_4";
        gameObject.tag = "Ennemi";
        transform.position = new Vector3(13, Random.Range(-4, 3), 0);
        rb = gameObject.GetComponent<Rigidbody2D>();
        rb.velocity = velocity;

        SpriteRenderer sr = after_image.GetComponent<SpriteRenderer>();
        sr.sprite = after_image_sprite;

        GameObject newPowerUp = Instantiate(powerUp, new Vector3(transform.position.x, transform.position.y, 0), Quaternion.identity);
        Rigidbody2D rbtest = newPowerUp.GetComponent<Rigidbody2D>();
        rbtest.velocity = new Vector2(-4f, 0);
    }

    void Update()
    {
        Mouvement();
        AfterImage();
        if (Time.time >= nextFireTime){
            Fire();
            nextFireTime = Time.time + fireRate;
        }

        if (transform.position.x < -13) {
            Destroy(gameObject);
        }
    }

    public void Mouvement() {
        pause_time -= Time.deltaTime;
        if ((pause_time <= 0) && isMoving){
            rb.velocity = new Vector2(0, 0);
            isMoving = false;
        }
        if (!isMoving){
            if (goingDown) {
                rb.velocity = new Vector2(0, -1);
                if (transform.position.y < -4) {
                    goingDown = false;
                }
            } else {
                rb.velocity = new Vector2(0, 1);
                if (transform.position.y > 4) {
                    goingDown = true;
                }
            }
        }
    }

    private void Fire()
    {
        // Create a new bullet
        GameObject bullet = Instantiate(bulletPrefab, transform.position, Quaternion.identity);

        // Calculate the direction of the bullet
        Vector3 direction = Quaternion.Euler(0, 0, angle) * new Vector3(-1, 0, 0);

        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();

        // Set the bullet's velocity
        rb.velocity = direction * bulletSpeed;

        if (up){
            angle += 8f;
            if (angle > angleRange){
                up = false;
            }
        }else{
            angle -= 8f;
            if (angle < -angleRange){
                up = true;
            }
        }

        FindObjectOfType<SoundManagerUFO>().PlaySound(4);
    }

    void AfterImage() {

        after_image_timer += Time.deltaTime;

        if (after_image_timer >= 0.1f)
        {
            after_image_timer = 0f;
        
            Instantiate(after_image, new Vector3(transform.position.x, transform.position.y, 6), Quaternion.identity);
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

    public void DestroyEnnemi() {
        GameObject new_explosion = Instantiate(explosion, new Vector3(transform.position.x, transform.position.y, transform.position.z), Quaternion.identity);
        new_explosion.transform.localScale = new Vector3(0.3f, 0.3f, 0);
        Destroy(gameObject);
        FindObjectOfType<SoundManagerUFO>().PlaySound(10);
        FindObjectOfType<ScoreManager>().AddScore(EnemyType.Enemy4);

        if (Random.Range(0, 5) == 0) {
            GameObject newPowerUp = Instantiate(powerUp, new Vector3(transform.position.x, transform.position.y, 0), Quaternion.identity);
            Rigidbody2D rb = newPowerUp.GetComponent<Rigidbody2D>();
            rb.velocity = new Vector2(-4f, 0);
        }
    }
}