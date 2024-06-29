using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// This class represents an asteroid in the game. It is responsible for destroying itself when it goes off screen.
/// </summary>
public class Asteroid : MonoBehaviour
{

    // Update is called once per frame
    /// <summary>
    /// Checks if the asteroid is off screen and destroys it if it is.
    /// </summary>
    void Update()
    {
        if (transform.position.x < -13) {
            Destroy(gameObject);
        }
    }
}
