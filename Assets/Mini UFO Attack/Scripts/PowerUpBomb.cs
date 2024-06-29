using UnityEngine;

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

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "Player Starter"){
            Destroy(gameObject);
            FindObjectOfType<SoundManagerUFO>().PlaySound(13); //PowerUp sound
            FindObjectOfType<BombManager>().GainBomb();
        }
    }
}
