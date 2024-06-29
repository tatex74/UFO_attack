using UnityEngine;

/// <summary>
/// This class represents the first enemy in the game.
/// It moves left and has an after image.
/// </summary>
public class Ennemi_1 : MonoBehaviour, IEnnemi
{
    // The explosion prefab to instantiate when the enemy is destroyed
    public GameObject explosion;

    // The sprite to use for the after image
    public Sprite after_image_sprite;

    // The game object to instantiate as the after image
    public GameObject after_image;

    // The timer for the after image
    private float after_image_timer = 0;

    // The rigidbody2D component of the enemy
    private Rigidbody2D rb;

    // The time after which the enemy changes direction
    private float time = 1;

    // The number of hits the enemy can take before it is destroyed
    private int pv = 1;
    
    // Start is called before the first frame update
    void Start()
    {
        gameObject.name = "Ennemi_1";
        gameObject.tag = "Ennemi";
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

    /// <summary>
    /// Moves the enemy left and changes its direction after a certain time.
    /// </summary>
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

    /// <summary>
    /// Destroys the enemy when it collides with a bullet.
    /// </summary>
    /// <param name="collision">The collision info.</param>
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

    /// <summary>
    /// Instantiates the after image every 0.1 seconds.
    /// </summary>
    private void AfterImage() {

        after_image_timer += Time.deltaTime;

        if (after_image_timer >= 0.1f)
        {
            after_image_timer = 0f;
        
            Instantiate(after_image, new Vector3(transform.position.x, transform.position.y, 6), Quaternion.identity);
        }
    }

    /// <summary>
    /// Destroys the enemy, plays a sound and increases the score.
    /// </summary>
    public void DestroyEnnemi(){
        GameObject new_explosion = Instantiate(explosion, new Vector3(transform.position.x, transform.position.y, transform.position.z), Quaternion.identity);
        new_explosion.transform.localScale = new Vector3(0.3f, 0.3f, 0);
        Destroy(gameObject);
        FindObjectOfType<SoundManagerUFO>().PlaySound(6);
        FindObjectOfType<ScoreManager>().AddScore(EnemyType.Enemy1);
    }
}
