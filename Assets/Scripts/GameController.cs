using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public float fallSpeed = 1;

    public GameObject coinPrefab;
    public float spawnDelay;
    public float spawnDelayReset = 2;

    public bool gameOver = false;
    public int score = 0;
    public int fails = 0;

    // Start is called before the first frame update
    void Start()
    {
        spawnDelay = spawnDelayReset;
    }

    // Update is called once per frame
    void Update()
    {
        // Counts down spawnDelay by 1 * Time.deltatime
        spawnDelay -= Time.deltaTime;

        // When spawnDelay hits zero, run code and restart
        if (spawnDelay <= 0)
        {
            if (gameOver != true)
            {
                // Spawns coin prefab
                Instantiate(coinPrefab, new Vector3(Random.Range(-8.5F, 8.5F), 8, 0), coinPrefab.transform.rotation);
            }

            // Reset spawnDelay
            spawnDelay = spawnDelayReset;
        }

        if (fails >= 3)
        {
            gameOver = true;
        }
    }
}
