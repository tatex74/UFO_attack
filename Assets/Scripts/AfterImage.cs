using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class AfterImage : MonoBehaviour
{
    public int direction = -1;
    //private float effect_time = 2f;
    // Start is called before the first frame update
    void Start()
    {
        Rigidbody2D rb = gameObject.GetComponent<Rigidbody2D>();
        rb.velocity = new Vector3(direction/Mathf.Abs(direction)*10, 0, 0);
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.x < -13) {
            Destroy(gameObject);
        }
    }
    /*void Start()
    {
        Rigidbody2D rb = gameObject.GetComponent<Rigidbody2D>();
        rb.velocity = new Vector3(direction/Mathf.Abs(direction)*10, 0, 0);
    }

    // Update is called once per frame
    void Update()
    {
        effect_time -= Time.deltaTime;
        transform.localScale = new Vector3(transform.localScale.x*(effect_time/2f), transform.localScale.y*(effect_time/2f), 0);

        if (effect_time <= 0) {
            Destroy(gameObject);
        }
    }*/
}
