using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameUIScript : MonoBehaviour
{
    public TMP_Text scoreText;
    public TMP_Text healthText;
    public GameManagerScript gameManager;
    
    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManagerScript>(); //finds the GameManagerScript and sets it to the gameManager variable
    }

    // Update is called once per frame
    void Update()
    {
        scoreText.text = "Score: " + gameManager.score; //sets the text of the scoreText to the current score
        healthText.text = "Health: " + gameManager.health; //sets the text of the healthText to the current health
    }
}
