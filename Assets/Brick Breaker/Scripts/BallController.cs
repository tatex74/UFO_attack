using UnityEngine;

public class BallController : MonoBehaviour
{
    public new Rigidbody2D rigidbody { get; private set; }
    public float speed = 500f;

    private void Awake(){
        rigidbody = GetComponent<Rigidbody2D>();
    }

    public void ResetBall(){
        transform.position = new Vector2(0f, -4f);
        rigidbody.velocity = Vector2.zero;
        Invoke(nameof(SetRandomTrajectory), 3f);
    }

    private void SetRandomTrajectory(){
        Vector2 force = Vector2.zero;
        force.x = Random.Range(-0.5f, 0.5f);
        force.y = -1f;

        this.rigidbody.AddForce(force.normalized * speed);        
    }

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