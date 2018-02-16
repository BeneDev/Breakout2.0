using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LivesManager : MonoBehaviour {

    [SerializeField] Text livesCount;
    private RacketController player;
    private int playerHealth;
    private GameObject bricks;
    private int currentScene;
    private int maxLevel;
    private GameObject firstBall;
    public int ballCount = 0;
    private BallPower bP;

    // Use this for initialization
    void Start () {
        player = FindObjectOfType<RacketController>();
        currentScene = SceneManager.GetActiveScene().buildIndex;
        maxLevel = SceneManager.sceneCountInBuildSettings - 1;
        bricks = GameObject.FindGameObjectWithTag("Bricks");
        bP = FindObjectOfType<BallPower>();
    }
	
	// Update is called once per frame
	void Update ()
    {
        playerHealth = player.GetHealth();
        livesCount.text = "Lives: " + playerHealth.ToString();
        HandleDying();
        if(bricks.transform.childCount <= 0)
        {
            LoadNextLevel();
        }
        if (Input.GetKeyDown(KeyCode.Space) && Time.timeScale == 0.0f)
        {
            SceneManager.LoadScene(0);
            Time.timeScale = 1.0f;
        }
        if(ballCount <= 0)
        {
            ballCount = 0;
            bP.Trigger();
        }
    }

    void LoadNextLevel()
    {
        if (currentScene < maxLevel)
        {
            currentScene++;
            SceneManager.LoadScene(currentScene);
        }
        else
        {
            Time.timeScale = 0.0f;
            livesCount.text = "You Won, press Space to Reload the first Level.";
        }
    }

    public void DamagePlayer()
    {
        if (ballCount == 0)
        {
            playerHealth = player.GetHealth();
            player.SetHealth(playerHealth - 1);
        }
    }

    private void HandleDying()
    {
        if (playerHealth <= 0)
        {
            Time.timeScale = 0.0f;
            livesCount.text = "You Lost, press Space to Reload the first Level.";
        }
    }
}
