using UnityEngine;

/// <summary>
/// PowerUpBomb class represents a bomb power-up in the game.
/// It has a collision detection with the player and destroys itself when it reaches the left side of the screen.
/// Also, it plays a sound and increases the player's bomb count when collided with the player.
/// </summary>
public class PowerUpBomb : MonoBehaviour
{   
    void Start()
    {
        gameObject.name = "PowerUp";
    }

    void Update()
    {
        if (transform.position.x < -11) {
            Destroy(gameObject);
        }
    }

    /// <summary>
    /// Handles the collision with the player.
    /// </summary>
    /// <param name="collision">The collision data.</param>
    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "Player Starter"){
            Destroy(gameObject);
            FindObjectOfType<SoundManagerUFO>().PlaySound(13); //PowerUp sound
            FindObjectOfType<BombManager>().GainBomb();
        }
    }
}
