using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager manager;
    public Transform playerSpawn;
    public Transform zombieSpawn;
    public GameObject playerPreFab;
    public GameObject zombiePreFab;
    public float playerSpeed;
    public string currentLevel;
    public int lives;
    public int maxLives = 3;
    public int Level;
    private void Awake()
    {

        Application.targetFrameRate = 60;
        Screen.SetResolution(1920, 1080, true);
        if (manager == null)
        {
            DontDestroyOnLoad(gameObject);
            manager = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }
    void Start()
    {
        lives = maxLives;
        if (lives > 0)
        {
            GameObject player = (GameObject)Instantiate(playerPreFab, playerSpawn);
        }
        Cursor.visible = false;

        Level = 0;

        ZombieSpawner();
    }
    void ZombieSpawner()
    {
        for (int i = 0; i < 10; i++)
        {
            Vector3 random = new Vector3(zombieSpawn.transform.position.x + Random.Range(0, 15), 0, zombieSpawn.transform.position.z + Random.Range(0, 15));
            GameObject zombie = (GameObject)Instantiate(zombiePreFab, random, Quaternion.identity);
        }

    }
}
