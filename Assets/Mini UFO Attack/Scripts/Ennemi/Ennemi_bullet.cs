using UnityEngine;

/// <summary>
/// This class represents a bullet fired by an enemy in the game.
/// It moves left and destroys itself when it collides with the player.
/// </summary>
public class Ennemi_bullet : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        gameObject.name = "Ennemi_Bullet";
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.x < -11) {
            Destroy(gameObject);
        }
    }

    /// <summary>
    /// Destroys the enemy bullet when it collides with the player.
    /// </summary>
    /// <param name="collision">The collision that occurred.</param>
    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "Player Starter"){
            Destroy(gameObject);
        }
    }
}
