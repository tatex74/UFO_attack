using UnityEngine;
using UnityEngine.SceneManagement;

public class PlanetClickHandler : MonoBehaviour
{
    public string sceneToLoad; // The name of the scene to load when the planet is clicked

    void OnMouseDown()
    {
        // Load the scene when the planet is clicked
        SceneManager.LoadScene(sceneToLoad);
        FindObjectOfType<SoundManagerMenu>().SelectGameSound();
    }

    public void Update(){
        if(Input.GetKey(KeyCode.Escape)){
            Application.Quit();
        }
    }
}