using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MarioMove : MonoBehaviour
{
    public GameObject mario;

    public Sprite stand;
    public Sprite walk1;
    public Sprite walk2;
    public Sprite walk3;
    public Sprite jump;

    public float speed = 3;
    public float jumpHeight = 300;

    public float delay;
    public float delayReset = 1;

    public int walkingImage = 1;

    public bool isWalking = false;
    public bool isJumping = false;

    public int direction = 0;       // 0 = right 1 = left

    // Start is called before the first frame update
    void Start()
    {
        delay = delayReset;
    }

    // Update is called once per frame
    void Update()
    {
        delay -= 1 * Time.deltaTime;

        if (delay <= 0)
        {
            if (isWalking == true)
            {
                Walk();
            }

            delay = delayReset;
        }

        if (isJumping == true)
        {
            mario.GetComponent<SpriteRenderer>().sprite = jump;
        }

        if (Input.GetKey(KeyCode.RightArrow) == true)
        {
            mario.transform.Translate(Vector3.right * speed * Time.deltaTime);
            isWalking = true;
            direction = 0;
            FaceDirection();
        }

        if (Input.GetKey(KeyCode.LeftArrow) == true)
        {
            mario.transform.Translate(Vector3.left * speed * Time.deltaTime);
            isWalking = true;
            direction = 1;
            FaceDirection();
        }

        if (Input.GetKeyDown(KeyCode.Space) == true)
        {
            if (isJumping != true)
            {
                mario.GetComponent<Rigidbody2D>().AddForce(Vector2.up * jumpHeight);
                isJumping = true;
            }
        }

        if (Input.GetKey(KeyCode.RightArrow) != true && Input.GetKey(KeyCode.LeftArrow) != true && isJumping != true)
        {
            // Sets the sprite for mario to stand
            mario.GetComponent<SpriteRenderer>().sprite = stand;
            isWalking = false;
        }
    }

    public void Walk()
    {
        if (walkingImage == 1)
        {
            // Sets the sprite for mario to walk1
            mario.GetComponent<SpriteRenderer>().sprite = walk1;
            walkingImage = 2;
            delay = delayReset;
        }

        else if (walkingImage == 2)
        {
            // Sets the sprite for mario to walk2
            mario.GetComponent<SpriteRenderer>().sprite = walk2;
            walkingImage = 3;
            delay = delayReset;
        }

        else
        {
            // Sets the sprite for mario to walk3
            mario.GetComponent<SpriteRenderer>().sprite = walk3;
            walkingImage = 1;
            delay = delayReset;
        }
    }

    public void FaceDirection()
    {
        // if the x scale is negative, it's facing left
        if (mario.transform.localScale.x < 0)
        {
            if (direction == 0)     // if Mario should be facing right, update it
            {
                // set a new scale using the current values and multiplying x by -1 to turn it positive
                mario.transform.localScale = new Vector3(mario.transform.localScale.x * -1, mario.transform.localScale.y, mario.transform.localScale.z);
            }
        }

        // if the x scale is positive, it's facing right
        if (mario.transform.localScale.x > 0)
        {
            if (direction == 1)     // if Mario should be facing left, update it
            {
                // set a new scale using the current values and multiplying x by -1 to turn it negative
                mario.transform.localScale = new Vector3(mario.transform.localScale.x * -1, mario.transform.localScale.y, mario.transform.localScale.z);
            }
        }
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "Ground")
        {
            isJumping = false;
        }
    }
}