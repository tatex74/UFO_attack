using System.Collections;
using System.Collections.Generic;
using UnityEditor.Callbacks;
using UnityEngine;

public class Player : MonoBehaviour
{
    private float mouv_speed = 8f;
    private Vector3 start_position = new Vector3(-5, 0, 0);
    //public GameObject player_bubble;
    public GameObject bullet;
    private Rigidbody2D rb;

    public GameObject after_image;
    private float after_image_timer = 0;

    void Start()
    {
        // Set the GameObject's position to the target position
        transform.position = start_position;
    }

    // Update is called once per frame
    void Update()
    {
        PlayerMouvement();

        //BubbleAnimation();

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

    /*void BubbleAnimation() {
        player_bubble.transform.localScale = Vector3.Lerp(player_bubble.transform.localScale, new Vector3(0, 0, 0), 1.0f * Time.deltaTime);
    }*/

    void Fire() {
        if (Input.GetKeyDown(KeyCode.Space)) {

            GameObject new_bullet = Instantiate(bullet, new Vector3(transform.position.x, transform.position.y, 10), Quaternion.identity);
            rb = new_bullet.GetComponent<Rigidbody2D>();
            rb.velocity = new Vector3(20, 0, 0);
            
            
        }
    }

    void AfterImage() {

        after_image_timer += Time.deltaTime;

        if (after_image_timer >= 0.1f)
        {
            after_image_timer = 0f;

            GameObject new_after_image = Instantiate(after_image, new Vector3(transform.position.x, transform.position.y, 20), Quaternion.identity);
            rb = new_after_image.GetComponent<Rigidbody2D>();
            rb.velocity = new Vector3(-10, 0, 0);
        }
    }
}
