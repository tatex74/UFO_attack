using UnityEngine;

public class Ennemi_3 : MonoBehaviour, IEnnemi
{
    // The explosion prefab to be instantiated when the Ennemi_3 is destroyed.
    public GameObject explosion;

    // The energy ball arc prefab to be instantiated when the Ennemi_3 fires.
    public GameObject energy_ball_arc_prefab;

    // The energy ball prefab to be instantiated when the Ennemi_3 fires.
    public GameObject energy_ball_prefab;

    // The laser prefab to be instantiated when the Ennemi_3 fires.
    public GameObject laser_prefab;

    // The instantiated energy ball arc game object.
    private GameObject energy_ball_arc;

    // The instantiated energy ball game object.
    private GameObject energy_ball;

    // The instantiated laser game object.
    private GameObject laser;

    // The x position at which the Ennemi_3 stops moving.
    private float x_stop = 7;

    // The number of hit points the Ennemi_3 has.
    private int pv = 3;

    // The pause gap between firing.
    private const float pause_gap = 3;

    // The time remaining until the Ennemi_3 can fire again.
    private float pause_time;

    // The target y position of the Ennemi_3.
    private float target_y_pos;

    // Flag to indicate if the Ennemi_3 has fired.
    private bool done_fire;

    // The rigidbody component of the Ennemi_3.
    private Rigidbody2D rb;
    void Start()
    {
        gameObject.name = "Ennemi_3";
        gameObject.tag = "Ennemi";
        transform.position = new Vector3(8, Random.Range(-4f, 3f), 0);
        rb = gameObject.GetComponent<Rigidbody2D>();
        rb.velocity = new Vector2(-5, 0);

        energy_ball_arc = Instantiate(energy_ball_arc_prefab, new Vector3(transform.position.x-1, transform.position.y, transform.position.z), Quaternion.identity);
        energy_ball = Instantiate(energy_ball_prefab, new Vector3(transform.position.x-1, transform.position.y, transform.position.z), Quaternion.identity);
        energy_ball.name = "EnergyBall";
        laser = Instantiate(laser_prefab, new Vector3(transform.position.x-1, transform.position.y, transform.position.z), Quaternion.identity);
        laser.name = "Laser";
    }

    // Update is called once per frame
    void Update()
    {
        Mouvement();

    }

    /// <summary>
    /// Movement function for the Ennemi_3 object.
    /// This function handles the movement of the object based on its position and velocity.
    /// It also handles the firing of the object and pausing its movements.
    /// </summary>
    public void Mouvement() {
        // First approach
        if (transform.position.x <= x_stop && rb.velocity.x != 0) {
            Fire();
            rb.velocity = new Vector2(0, 0);
            pause_time = pause_gap;
        }
        // Stop mouvement when target_position is reached
        if ((rb.velocity.y < 0 && transform.position.y <= target_y_pos) || (rb.velocity.y > 0 && transform.position.y >= target_y_pos)) {
            Fire();
            rb.velocity = new Vector2(0, 0);
        }
        // Counting time when mouvements are stopped
        if (rb.velocity.x == 0 && rb.velocity.y == 0) {
            pause_time -= Time.deltaTime;
        }
        // Create a new target position and start mouvements
        if (pause_time <= 0 && rb.velocity.x == 0) {
            target_y_pos = Random.Range(-4f, 4f);
            if (target_y_pos < transform.position.y) {
                rb.velocity = new Vector2(0, -5);
            }
            else {
                rb.velocity = new Vector2(0, 5);
            }
            pause_time = pause_gap;
        }
    }

    /// <summary>
    /// Fires lasers, energy balls, and energy ball arcs.
    /// </summary>
    public void Fire() {
        Animator laser_anim = laser.GetComponent<Animator>();
        Animator energy_ball_anim = energy_ball.GetComponent<Animator>();
        Animator energy_ball_arc_anim = energy_ball_arc.GetComponent<Animator>();

        laser.transform.position = new Vector3(transform.position.x-1, transform.position.y, transform.position.z);
        energy_ball.transform.position = new Vector3(transform.position.x-1, transform.position.y, transform.position.z);
        energy_ball_arc.transform.position = new Vector3(transform.position.x-1, transform.position.y, transform.position.z);

        laser_anim.Play("Laser");
        energy_ball_anim.Play("EnergyBall");
        energy_ball_arc_anim.Play("EnergyBallArc");

        FindObjectOfType<SoundManagerUFO>().PlaySound(5);
    }

    /// <summary>
    /// Decreases the player's health when it collides with the player's bullet.
    /// If the player's health reaches 0, the player is destroyed.
    /// If the player collides with the player, the enemy is destroyed.
    /// </summary>
    /// <param name="collision">The collision information.</param>
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
    /// Destroy the enemy and play sound and score adjustments.
    /// </summary>
    public void DestroyEnnemi() {
        // Instantiate explosion effect
        GameObject new_explosion = Instantiate(explosion, 
        new Vector3(transform.position.x, transform.position.y, transform.position.z), 
        Quaternion.identity);
        // Set scale of explosion
        new_explosion.transform.localScale = new Vector3(0.3f, 0.3f, 0);
        // Destroy enemy game object
        Destroy(gameObject);
        // Play enemy destruction sound
        FindObjectOfType<SoundManagerUFO>().PlaySound(8);
        // Adjust player score
        FindObjectOfType<ScoreManager>().AddScore(EnemyType.Enemy3);
    }
}
