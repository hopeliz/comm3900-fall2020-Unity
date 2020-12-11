using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UITest : MonoBehaviour
{
    public Text scoreText;
    public int score;
    public RectTransform healthBar;
    public float fullHealth;
    public float health;
    public GameObject gameOverScreen;

    // Start is called before the first frame update
    void Start()
    {
        score = 0;
        fullHealth = healthBar.localScale.x;
        health = fullHealth;
    }

    // Update is called once per frame
    void Update()
    {
        scoreText.text = score.ToString();

        if (health < fullHealth/10)
        {
            gameOverScreen.SetActive(true);
        }

        // Set the health bar width
        healthBar.localScale = new Vector3(health, healthBar.localScale.y, healthBar.localScale.z);

        // Set health bar color
        if (health <= fullHealth/2 && health > fullHealth/4)
        {
            healthBar.GetComponent<Image>().color = new Color(1, 1, 0); // Yellow
        }
        else if (health <= fullHealth/4)
        {
            healthBar.GetComponent<Image>().color = new Color(1, 0, 0); // Red
        }
        else
        {
            healthBar.GetComponent<Image>().color = new Color(0, 1, 0); // Green
        }
    }

    public void AddOne()
    {
        score++;        // Equivalent to score += 1; or score = score + 1;
    }

    public void ResetScore()
    {
        score = 0;
        health = fullHealth;
    }

    public void Attack()
    {
        if (health >= fullHealth/10)
        {
            health -= fullHealth / 10;
        }
    }
}
