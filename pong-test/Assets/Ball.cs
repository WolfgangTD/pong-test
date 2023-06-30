using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{

    public float speed = 1f;
    Vector2 direction;
    bool start = false;
    Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {   
        // right now can make multiple InitialLaunches for testing
        if(Input.GetKey(KeyCode.Space))
        {
            InitialLaunch();
        }
        if(start)
        {
            rb.velocity = direction * speed;
        }
    }

    void InitialLaunch()
    {
        // an angle is generated for each sides potential start, cant be too close to 0 or it will just start bouncing on walls for a while.
        float rand_angle_right = Random.Range(35,125);
        float rand_angle_left = Random.Range(235,325);
        float start_side = Random.Range(0,2)*2-1; //chooses starter side

        start = true;
        float angleInRadians = (rand_angle_right-90) * Mathf.Deg2Rad;
        direction = new Vector2(Mathf.Cos(angleInRadians), Mathf.Sin(angleInRadians));

        
    }
}
