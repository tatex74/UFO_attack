using UnityEngine;

/// <summary>
/// Brick class represents a single brick in the game. It has a sprite renderer and 
/// a set of sprite states. It also has a health property that represents how many 
/// times the brick can be hit before it is destroyed. The class also has a method to 
/// reduce health, a method to check if the brick is destroyed, and a method to detect
/// collision with the ball.
/// </summary>
public class Brick : MonoBehaviour
{
    // Reference to SpriteRenderer component
    public SpriteRenderer spriteRenderer { get; private set; }
    // Array of sprite states for the brick
    public Sprite[] states;
    // Health of the brick
    public int health { get; private set; }
    // Points rewarded for destroying the brick
    public int points = 50;

    // Initialize sprite renderer on awake
    private void Awake(){
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Set initial state of the brick on start
    private void Start(){
        health = states.Length;
        spriteRenderer.sprite = states[health - 1];
    }

    // Reduce health and change state of the brick if it is not destroyed
    private void Hit(){
        health--;

        if (health <= 0) {
            Destroy(gameObject);
            FindObjectOfType<GameManager>().CheckRemainingBricks();
        }else{
            spriteRenderer.sprite = states[health - 1];
        }

        FindObjectOfType<GameManager>().Hit(this);
    }

    // Detect collision with the ball and reduce health of the brick
    private void OnCollisionEnter2D(Collision2D collision){
        if (collision.gameObject.name == "Ball"){
            Hit();
        }
    }
}
