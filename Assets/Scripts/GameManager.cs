
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }
    public static GameManager manager;
    public Transform playerSpawn;
    public Transform[] zombieSpawn;
    public GameObject playerPreFab;
    public GameObject zombiePreFab;
    public int currentLevel;
    public int score;
    public int zombieCount;
    public float gameTime;
    public float levelChange;
    public float zombieSpeed;
    public int lives;
    public int maxLives = 3;
    public int Level;
    public TextMeshProUGUI levelText;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI gameOverText;
    private void Awake()
    {
        Instance = this;
        score = 0;
        levelText.text = Level.ToString();
        currentLevel = 0;
        gameTime = 0;
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
        //Cursor.visible = false;

        Level = 0;

        ZombieSpawner();
    }
    void Update()
    {
        gameTime += Time.deltaTime;
        if (gameTime > levelChange)
        {
            ZombieSpawner();
            zombieSpeed += 0.5f;
            currentLevel += 1;
            gameTime = 0;
            levelText.text = currentLevel.ToString();
        }
        scoreText.text = score.ToString();

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
            // SceneManager.LoadScene("MainMenu");
            // Cursor.visible = true;
        }
    }
    void ZombieSpawner()
    {
        for (int x = 0; x < 4; x++)
        {
            for (int i = 0; i < zombieCount; i++)
            {
                Vector3 random = new Vector3(zombieSpawn[x].transform.position.x + Random.Range(0, 15), 0, zombieSpawn[x].transform.position.z + Random.Range(0, 15));
                GameObject zombie = (GameObject)Instantiate(zombiePreFab, random, Quaternion.identity);
            }
        }


    }
}
