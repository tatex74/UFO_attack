using UnityEngine;

/// <summary>
/// PowerUpShield is a script that controls the behavior of the shield power-up.
/// It changes the name of the game object to "PowerUp" and destroys it when it goes offscreen.
/// When the power-up collides with the player, it destroys itself, plays a sound, and gives the player an extra life.
/// </summary>
public class PowerUpShield : MonoBehaviour
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
    /// Called when the game object collides with another object.
    /// If the collided object is the player, destroys the game object, plays a sound, and gives the player an extra life.
    /// </summary>
    /// <param name="collision">The collision that occurred.</param>
    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "Player Starter"){
            Destroy(gameObject);
            FindObjectOfType<SoundManagerUFO>().PlaySound(13); //PowerUp sound
            FindObjectOfType<LivesManager>().GainLife();
        }
    }
}
