using UnityEngine;

public class Brick : MonoBehaviour
{
    public SpriteRenderer spriteRenderer { get; private set; }
    public Sprite[] states;
    public int health { get; private set; }
    public int points = 50;

    private void Awake(){
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void Start(){
        health = states.Length;
        spriteRenderer.sprite = states[health - 1];
    }

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

    private void OnCollisionEnter2D(Collision2D collision){
        if (collision.gameObject.name == "Ball"){
            Hit();
        }
    }
}
