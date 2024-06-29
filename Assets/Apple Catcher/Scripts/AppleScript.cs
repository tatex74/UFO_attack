using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

/// <summary>
/// Script that represents an apple in the game, and deals with its lifecycle and collision.
/// </summary>
public class AppleScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.y < -10.0f)
        {
            Destroy(gameObject);
        }
    }

    //React to a collision (collision start)
    /// <summary>
    /// Destroys the game object when collided with another object.
    /// </summary>
    /// <param name="col">The collision data.</param>
    void OnCollisionEnter2D(Collision2D col)
    {
        Destroy(gameObject);
    }
}
