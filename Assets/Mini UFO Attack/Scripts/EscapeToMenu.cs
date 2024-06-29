using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// This class handles the escape key input and loads the menu scene when the key is pressed.
/// </summary>
public class EscapeToMenu : MonoBehaviour
{
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape)){
            SceneManager.LoadScene(0);
        }
    }
}
