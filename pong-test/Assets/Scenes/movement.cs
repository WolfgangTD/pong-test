using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class movement : MonoBehaviour
{
    public Rigidbody2D rb;
    public float speed;
    public KeyCode keytopress1;
    public KeyCode keytopress2;
    // Start is called before the first frame update
    void Start()
    {
        speed = 0.01f;
    }

    // Update is called once per frame
    void Update()
    {
        rb.velocity = Vector3.zero;
        if (Input.GetKey(keytopress1))
        {
            rb.position += Vector2.up * speed;
        }
        else if (Input.GetKey(keytopress2)) 
        {
            rb.position -= Vector2.up * speed;
        }
    }
}
