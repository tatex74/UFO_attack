using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AfterImage : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Rigidbody2D rb = gameObject.GetComponent<Rigidbody2D>();
        rb.velocity = new Vector3(-10, 0, 0);
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.x < -10) {
            Destroy(gameObject);
        }
    }
}
