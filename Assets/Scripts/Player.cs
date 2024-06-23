using System.Collections;
using System.Collections.Generic;
using UnityEditor.Callbacks;
using UnityEngine;

public class Player : MonoBehaviour
{
    public GameObject bullet;
    public GameObject after_image;


    private int pv = 10;
    private float mouv_speed = 8f;
    private Vector3 start_position = new Vector3(-5, 0, 0);
    private Rigidbody2D rb;
    private float after_image_timer = 0;
    private float bullet_timer = 0;

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
                transform.Translate(0, mouv_speed * Time.deltaTime, 0);
            }
        }
        else if (Input.GetKey(KeyCode.DownArrow)) {
            if (transform.position.y > -4f) {
                transform.Translate(0, -mouv_speed * Time.deltaTime, 0);
            }
        } 
    }

    void Fire() {
        bullet_timer -= Time.deltaTime;
        if (Input.GetKey(KeyCode.Space) && bullet_timer <= 0) {
            GameObject new_bullet = Instantiate(bullet, new Vector3(transform.position.x, transform.position.y, 0), Quaternion.identity);
            rb = new_bullet.GetComponent<Rigidbody2D>();
            rb.velocity = new Vector3(20, 0, 0);
            bullet_timer = 0.15f;
            FindObjectOfType<SoundManagerUFO>().PlaySound(1);
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

    public void OnCollisionEnter2D(Collision2D collision) {
        if (collision.gameObject.name != "Bullet") {
            FindObjectOfType<LivesManager>().LoseLife();
            FindObjectOfType<SoundManagerUFO>().PlaySound(2);
        }
    }
}
