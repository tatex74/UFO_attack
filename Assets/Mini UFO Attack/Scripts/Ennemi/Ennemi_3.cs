using System.Collections;
using System.Collections.Generic;
using UnityEditor.Callbacks;
using UnityEngine;

public class Ennemi_3 : MonoBehaviour, IEnnemi
{
    public GameObject explosion;
    public GameObject energy_ball_arc_prefab;
    public GameObject energy_ball_prefab;
    public GameObject laser_prefab;

    private GameObject energy_ball_arc;
    private GameObject energy_ball;
    private GameObject laser;
    private float x_stop = 7;
    private int pv = 3;

    private const float pause_gap = 3;
    private float pause_time;

    private float target_y_pos;
    private bool done_fire;

    Rigidbody2D rb;
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
        FindObjectOfType<SoundManagerUFO>().PlaySound(8);
        FindObjectOfType<ScoreManager>().AddScore(EnemyType.Enemy3);
    }
}
