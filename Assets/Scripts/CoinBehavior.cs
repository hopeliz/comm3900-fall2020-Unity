using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinBehavior : MonoBehaviour
{
    public float spinSpeed = 100;

    public GameObject gameController;
    public float coinFallSpeed;

    // Start is called before the first frame update
    void Start()
    {
        gameController = FindObjectOfType<GameController>().gameObject;

        coinFallSpeed = gameController.GetComponent<GameController>().fallSpeed;
    }

    // Update is called once per frame
    void Update()
    {
        // Set fall speed
        coinFallSpeed = gameController.GetComponent<GameController>().fallSpeed;

        // Spin on Y axis
        transform.Rotate(Vector3.up * Time.deltaTime * spinSpeed);

        // Fall downward
        transform.position += Vector3.down * Time.deltaTime * coinFallSpeed;
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "Mario")
        {
            // Gets the score in the Game Controller script and adds 1
            gameController.GetComponent<GameController>().score += 1;

            // Gets the fallSpeed in the Game Controller and adds 1
            gameController.GetComponent<GameController>().fallSpeed += 1;
        }

        if (collision.gameObject.name == "Ground")
        {
            // Gets the fails in the Game Controller script and adds 1
            gameController.GetComponent<GameController>().fails += 1;

            // Gets the fallSpeed in the Game Controller and adds 1
            gameController.GetComponent<GameController>().fallSpeed += 1;
        }

        Destroy(gameObject);
    }
}
