using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{

    public float speed = 1f;

    int player1_score = 0;
    int player2_score = 0;
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
        if(Input.GetKey(KeyCode.Space) && !start)
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
        float rand_angle = Random.Range(35,125);
        float start_side = Random.Range(0,2)*2-1; //chooses starter side

        start = true;
        float angleInRadians = (rand_angle+(90*start_side)) * Mathf.Deg2Rad;
        direction = new Vector2(Mathf.Cos(angleInRadians), Mathf.Sin(angleInRadians));
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        //bounce vertical if wall horizontal if paddle
        if(collision.gameObject.CompareTag("Wall"))
        {
            direction.y = -direction.y;
        }else if(collision.gameObject.CompareTag("Player1") || collision.gameObject.CompareTag("player2"))
        {
            direction.x = -direction.x;
        }else if(collision.gameObject.CompareTag("Goal"))
        {
            //calls the controller once to track scores before resetting to original position and stop speed
            if(collision.gameObject.name == "Goal1")
            {
                PlayerScore(1);
            }else{
                PlayerScore(2);
            }
            transform.position = new Vector3(0f,0f,0f);
            start = false;
            rb.velocity = Vector2.zero;
        }
    }

    //Called once when ball hits a goal, 1 for Goal1 2 for Goal2
    public void PlayerScore(int player)
    {
        if(player==1)
        {
            player1_score+=1;
        }else{
            player2_score+=1;
        }
    }
}
