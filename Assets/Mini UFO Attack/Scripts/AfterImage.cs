using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

/// <summary>
/// AfterImage script controls the movement and lifespan of the after images.
/// </summary>
public class AfterImage : MonoBehaviour
{
    public int direction = -1;

    // Start is called before the first frame update
    void Start()
    {
        Rigidbody2D rb = gameObject.GetComponent<Rigidbody2D>();
        rb.velocity = new Vector3(direction/Mathf.Abs(direction)*10, 0, 0);
    }

    // Update is called once per frame
    void Update()
    {
        // Destroy the after image if it goes out of bounds or the scale is too small
        if (transform.position.x < -13 || transform.position.x > 13 || transform.localScale.x < 0.15) {
            Destroy(gameObject);
        }
    }
}
