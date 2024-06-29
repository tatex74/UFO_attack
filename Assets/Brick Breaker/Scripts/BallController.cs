using UnityEngine;

/// <summary>
/// Controls the ball in the Brick Breaker game.
/// </summary>
public class BallController : MonoBehaviour
{
    // The rigidbody of the ball.
    public new Rigidbody2D rigidbody { get; private set; }
    // The speed of the ball.
    public float speed = 500f;

    private void Awake(){
        rigidbody = GetComponent<Rigidbody2D>();
    }

    /// <summary>
    /// Resets the ball to its initial position and velocity.
    /// </summary>
    public void ResetBall(){
        transform.position = new Vector2(0f, -4f);
        rigidbody.velocity = Vector2.zero;
        Invoke(nameof(SetRandomTrajectory), 3f);
    }

    /// <summary>
    /// Sets a random trajectory for the ball.
    /// </summary>
    private void SetRandomTrajectory(){
        Vector2 force = Vector2.zero;
        force.x = Random.Range(-0.5f, 0.5f);
        force.y = -1f;

        this.rigidbody.AddForce(force.normalized * speed);        
    }

    /// <summary>
    /// Handles the collision with the paddle or wall.
    /// </summary>
    /// <param name="collision">The collision data.</param>
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "Paddle")
        {
            SoundManagerBB.Instance.PlayPaddleHitSound();
        }
        else if (collision.gameObject.name == "Wall")
        {
            SoundManagerBB.Instance.PlayWallHitSound();
        }
        else{
            SoundManagerBB.Instance.PlayPaddleHitSound();
        }
        
    }
}
