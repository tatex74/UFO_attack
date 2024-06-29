using UnityEngine;

/// <summary>
/// Controller class for the paddle.
/// </summary>
public class PaddleController : MonoBehaviour
{
    public float speed = 10f;
    public float boundary = 7.5f; // Assuming the boundary of the game is at x = ±7.5
    public float maxBounceAngle = 75f;

    /// <summary>
    /// Update is called once per frame
    /// </summary>
    void Update()
    {
        float move = Input.GetAxis("Horizontal") * speed * Time.deltaTime;

        Vector3 newPosition = transform.position + new Vector3(move, 0, 0);

        // Clamping the position to stay within the boundaries
        newPosition.x = Mathf.Clamp(newPosition.x, -boundary, boundary);

        transform.position = newPosition;
    }

    /// <summary>
    /// Resets the paddle to the initial position
    /// </summary>
    public void ResetPaddle(){
        transform.position = new Vector2(0f, transform.position.y);
    }

    /// <summary>
    /// Handles the collision with the ball
    /// </summary>
    /// <param name="collision">Collision info</param>
    private void OnCollisionEnter2D(Collision2D collision){
        BallController ball = collision.gameObject.GetComponent<BallController>();

        if (ball != null){
            Vector3 paddlePosition = this.transform.position;
            Vector2 contactPoint = collision.GetContact(0).point;

            float offset = paddlePosition.x - contactPoint.x;
            float width = collision.otherCollider.bounds.size.x / 2;

            float currentAngle = Vector2.SignedAngle(Vector2.up, ball.rigidbody.velocity);
            float bounceAngle = (offset / width) * this.maxBounceAngle;
            float newAngle = Mathf.Clamp(currentAngle + bounceAngle, -maxBounceAngle, maxBounceAngle);

            Quaternion rotation = Quaternion.AngleAxis(newAngle, Vector3.forward);
            ball.rigidbody.velocity = rotation * Vector2.up * ball.rigidbody.velocity.magnitude;
        }
    }
}
