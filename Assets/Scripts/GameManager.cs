using UnityEngine;
using TMPro;

//C'est ici qu'on gère les vies et le score. Dcp faudra appeler tous les objets qui peuvent influer le score et les vies.
public class GameManager : MonoBehaviour
{
    public int lives;
    public int score;    
    public TextMeshPro scoreText;


    private void newGame(){
        lives = 5;
        score = 0;
        updateScore();
    }
    
    private void updateScore(){
        scoreText.SetText("Score = " + score);
    }
}
