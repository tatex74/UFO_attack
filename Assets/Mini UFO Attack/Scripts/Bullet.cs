using UnityEngine;

/// <summary>
/// The bullet that the player fires.
/// </summary>
public class bullet : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        gameObject.name = "Bullet";
    }

    // Update is called once per frame
    void Update()
    {
        // Destroy the bullet if it goes off the screen
        if (transform.position.x > 13) {
            Destroy(gameObject);
        }
    }

    /// <summary>
    /// Destroys the bullet if it collides with another object that is not the player, a bullet, a laser, or a powerup.
    /// </summary>
    /// <param name="collision">The collision that occurred.</param>
    public void OnCollisionEnter2D(Collision2D collision)
    {
        if ((collision.gameObject.name != "Player Starter")&&(collision.gameObject.name != "Ennemi_Bullet")&&(collision.gameObject.name != "Laser")&&(collision.gameObject.name != "PowerUp")){
            Destroy(gameObject);
        }
    }
}
