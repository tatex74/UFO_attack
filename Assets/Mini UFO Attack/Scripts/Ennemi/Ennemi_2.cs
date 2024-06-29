using UnityEngine;

/// <summary>
/// Ennemi_2 is an enemy that moves horizontally and fires bullets in pairs.
/// </summary>
public class Ennemi_2 : MonoBehaviour, IEnnemi
{
    // Bullet prefab to instantiate
    public GameObject bullet;
    // Explosion prefab to instantiate when enemy is destroyed
    public GameObject explosion;
    // PowerUp prefab to instantiate randomly when enemy is destroyed
    public GameObject powerUp;
    // Sprite for the after image
    public Sprite after_image_sprite;
    // GameObject for the after image
    public GameObject after_image;
    // Timer for the after image
    private float after_image_timer = 0;
    // Rigidbody2D component of this object
    private Rigidbody2D rb;
    // Health points of the enemy
    private int pv = 5;
    // Movement velocity of the enemy
    private Vector2 velocity = new Vector2(-3, 0);
    // Timer for the enemy's movements
    private float pause_time = 2f;
    // Flag indicating if the enemy is moving
    private bool isMoving = true;
    // Timer for bullet firing
    private float fire_frequency = 1f;

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

    void Update()
    {
        Mouvement();
        AfterImage();
        Fire();

        if (transform.position.x < -13) {
            Destroy(gameObject);
        }
    }

    /// <summary>
    /// Moves the enemy horizontally and changes direction every two seconds.
    /// </summary>
    public void Mouvement()
    {
        pause_time -= Time.deltaTime;
        if (pause_time <= 0)
        {
            if (isMoving)
            {
                rb.velocity = new Vector2(0, 0);
                isMoving = false;
            }
            else
            {
                rb.velocity = velocity;
                isMoving = true;
            }
            pause_time = 2f;
        }
    }

    /// <summary>
    /// Fires bullets in pairs every second.
    /// </summary>
    public void Fire()
    {
        fire_frequency -= Time.deltaTime;
        if (fire_frequency <= 0)
        {
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

    /// <summary>
    /// Called when the enemy collides with another object.
    /// </summary>
    /// <param name="collision">The collision that occurred.</param>
    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "Bullet")
        {
            pv -= 1;
            if (pv <= 0)
            {
                DestroyEnnemi();
            }
        }
        else if (collision.gameObject.name == "Player Starter")
        {
            DestroyEnnemi();
        }
    }

    /// <summary>
    /// Spawns an after image every 0.1 seconds.
    /// </summary>
    void AfterImage()
    {
        after_image_timer += Time.deltaTime;

        if (after_image_timer >= 0.1f)
        {
            after_image_timer = 0f;

            Instantiate(after_image, new Vector3(transform.position.x, transform.position.y, 6), Quaternion.identity);
        }
    }

    /// <summary>
    /// Destroys the enemy and spawns an explosion. Also increases the score and plays a sound. 
    /// A powerUp is spawned with a 1/7 chance.
    /// </summary>
    public void DestroyEnnemi()
    {
        GameObject new_explosion = Instantiate(explosion, new Vector3(transform.position.x, transform.position.y, transform.position.z), Quaternion.identity);
        new_explosion.transform.localScale = new Vector3(0.3f, 0.3f, 0);
        Destroy(gameObject);
        FindObjectOfType<SoundManagerUFO>().PlaySound(7);
        FindObjectOfType<ScoreManager>().AddScore(EnemyType.Enemy2);

        if (Random.Range(0, 7) == 0)
        {
            GameObject newPowerUp = Instantiate(powerUp, new Vector3(transform.position.x, transform.position.y, 0), Quaternion.identity);
            Rigidbody2D rb = newPowerUp.GetComponent<Rigidbody2D>();
            rb.velocity = new Vector2(-4f, 0);
        }
    }
}
