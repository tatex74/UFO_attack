using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class bullet : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.x > 10) {
            Destroy(gameObject);
        }
    }

    /*void OnCollisionEnter2D(Collision2D collision) {
        if (col)
    }*/
}
