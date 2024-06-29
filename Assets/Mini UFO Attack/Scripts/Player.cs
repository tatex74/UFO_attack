using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEditor.Callbacks;
using UnityEngine;

public class Player : MonoBehaviour
{
    public GameObject bullet;
    public GameObject after_image;
    public GameObject explosion;

    private float mouv_speed = 8f;
    private Vector3 start_position = new Vector3(-5, 0, 0);
    private Rigidbody2D rb;
    private float after_image_timer = 0;
    private float bullet_timer = 0;

    /// <summary>
    /// Called when the game starts. Sets the GameObject's position to the target position and plays the music loop.
    /// </summary>
    void Start()
    {
        // Set the GameObject's position to the target position
        transform.position = start_position;

        // Play music loop
        FindObjectOfType<SoundManagerUFO>().PlaySound(11);
    }

    // Update is called once per frame
    void Update()
    {
        PlayerMouvement();

        Fire();

        AfterImage();

    }

    /// <summary>
    /// Moves the player based on keyboard input.
    /// </summary>
    void PlayerMouvement() {
        if (Input.GetKey(KeyCode.RightArrow)) {
            if (transform.position.x < -2.5f) {
                transform.Translate(mouv_speed * Time.deltaTime, 0, 0);
            }
        }
        else if (Input.GetKey(KeyCode.LeftArrow)) {
            if (transform.position.x > -7f) {
                transform.Translate(-mouv_speed * Time.deltaTime, 0, 0);
            }
        }
        else if (Input.GetKey(KeyCode.UpArrow)) {
            if (transform.position.y < 3f) {
                transform.Translate(0,mouv_speed * Time.deltaTime, 0);
            }
        }
        else if (Input.GetKey(KeyCode.DownArrow)) {
            if (transform.position.y > -4f) {
                transform.Translate(0, -mouv_speed * Time.deltaTime, 0);
            }
        } 
    }

    /// <summary>
    /// Fires a bullet based on keyboard input and plays a sound.
    /// </summary>
    void Fire()
    {
        bullet_timer -= Time.deltaTime;
        if (Input.GetKey(KeyCode.Space) && bullet_timer <= 0)
        {
            GameObject new_bullet = Instantiate(bullet, new Vector3(transform.position.x, transform.position.y, 0), Quaternion.identity);
            rb = new_bullet.GetComponent<Rigidbody2D>();
            rb.velocity = new Vector3(20, 0, 0);
            bullet_timer = 0.15f;
            FindObjectOfType<SoundManagerUFO>().PlaySound(1);
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
    /// Called when the game object collides with another object.
    /// If the collided object is not a bullet or power up, loses a life, plays a sound, and destroys the game object.
    /// </summary>
    /// <param name="collision">The collision that occurred.</param>
    public void OnCollisionEnter2D(Collision2D collision) {
        if ((collision.gameObject.name != "Bullet") && (collision.gameObject.name != "PowerUp")) {
            FindObjectOfType<LivesManager>().LoseLife();
            FindObjectOfType<SoundManagerUFO>().PlaySound(2);
        }
    }

    /// <summary>
    /// Called when the game is over. Spawns an explosion, stops all audio sources, plays sounds, waits for 2 seconds, then shows the game over screen.
    /// </summary>
    public async void GameOver() {
        GameObject new_explosion = Instantiate(explosion, new Vector3(transform.position.x, transform.position.y, transform.position.z), Quaternion.identity);
        new_explosion.transform.localScale = new Vector3(0.8f, 0.8f, 0);
        Destroy(gameObject);
        FindObjectOfType<SoundManagerUFO>().StopAllAudioSources();
        FindObjectOfType<SoundManagerUFO>().PlaySound(14);
        // Wait for the specified delay
        await Task.Delay(2 * 1000);
        // Execute the action
        FindObjectOfType<SoundManagerUFO>().PlaySound(15);
        FindObjectOfType<GameOver>().ShowGameOver(FindObjectOfType<ScoreManager>().GetCurrentScore());
    }

}
