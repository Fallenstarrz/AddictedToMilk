using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    // Static instance
    public static GameManager instance;

    // Scene Variables
    public SceneSwitcher sceneScript;
    public int currentScene;

    // Variables
    public Vector3 lastCheckpoint;
    public int score;
    public int playerLives;
    public int maxLives;

    // References to Actors
    public Controller_Player player;
    public GameObject playerPrefab;

    private void Awake()
    {
        // Singleton
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(this.gameObject);
        }
        // Set Component Variables
        sceneScript = GetComponent<SceneSwitcher>();
    }

    private void Start()
    {
        // On play always load level main menu first
        sceneScript.LoadMainMenu();
    }

    private void Update()
    {
        // Set current scene to the build index
        currentScene = SceneManager.GetActiveScene().buildIndex;
        if (currentScene != 0 && currentScene != 6)
        {
            if (player == null)
            {
                // Respawn player if we have lives remaining
                if (playerLives > 0)
                {
                    if (currentScene != 4)
                    {
                        playerRespawn();
                    }
                }
                else
                {
                    // if our scene isnt the loss screen then load loss scene when we run out of lives
                    if (currentScene != 4 && currentScene != 5 && currentScene != 6)
                    {
                        sceneScript.LoadLoss();
                    }
                }
            }
        }
        else
        {
            resetGame();
        }
    }
    // Respawn player and reduce playerLives by 1
    private void playerRespawn()
    {
        playerLives -= 1;
        Instantiate(playerPrefab, lastCheckpoint, Quaternion.Euler (0,0,0));
    }
    // Reset score to 0 and lives to maxLives
    void resetGame()
    {
        score = 0;
        playerLives = maxLives;
    }
}
