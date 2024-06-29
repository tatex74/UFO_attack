using UnityEngine;

/// <summary>
/// Handles collision with the ball and triggers the miss event in the game manager.
/// </summary>
public class MissZone : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision){
        if (collision.gameObject.name == "Ball"){
            FindObjectOfType<GameManager>().Miss();
        }
    }    
}
