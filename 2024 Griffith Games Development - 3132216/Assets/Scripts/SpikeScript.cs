using UnityEngine;

public class SpikeScript : MonoBehaviour
{
    public GameManagerScript gameManager; //creates a variable to hold the GameManagerScript
    public float scoreValue; //creates a variable to hold the score value of the object

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Player"))
        {
            gameManager.TakeDamage(scoreValue); //runs the AddScore method from the GameManagerScript, passing the scoreValue as an argument
        }
    }
}