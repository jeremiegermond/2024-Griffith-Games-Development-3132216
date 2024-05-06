using UnityEngine;

public class GameManagerScript : MonoBehaviour
{
    public float health;
    public float score;
    public Transform spawnPoint;
    public GameObject player;

    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }

    void Start()
    {
        spawnPoint = GameObject.FindGameObjectWithTag("Start").transform;
    }

    void Update()
    {
        if (health <= 0)
        {
            RespawnPlayer();
        }
    }

    public void AddScore(float scoreToAdd)
    {
        score += scoreToAdd;
    }

    public void TakeDamage(float damageToTake)
    {
        health -= damageToTake;
        if (health <= 0)
        {
            health = 0;
        }
    }

    void RespawnPlayer()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        player.transform.position = spawnPoint.position;
        health = 3;
    }
}