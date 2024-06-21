using UnityEngine;

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
        if (transform.position.x > 13) {
            Destroy(gameObject);
        }
    }

    public void OnCollisionEnter2D(UnityEngine.Collision2D collision)
    {
        if (collision.gameObject.name != "Player Starter"){
            Destroy(gameObject);
        }
    }
}
