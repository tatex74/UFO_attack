using UnityEngine;

public class Ennemi_2_bullet : MonoBehaviour
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

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "Player Starter"){
            Destroy(gameObject);
        }
    }
}
