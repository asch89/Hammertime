using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{

    HitDetection hitDetection;
    EnemyBehaviour enemyBehaviour;
    GameObject playerBody;

    GameObject restartButton;
    GameObject menuButton;

    public bool endless;

    public Transform enemy;
    public GameObject Cubes;
    public GameObject RightXs;
    public GameObject LeftXs;
    public GameObject Pyramids;
    GameObject clonePillars;
    GameObject cloneArc;
    GameObject clonePyramids;
    public Transform playerTarget;
    public float x;
    public float y;
    public float z;
    [SerializeField] Vector3 startPos = new Vector3(0,0,0);

    public float mindif;
    public float maxdif;
    public int lastInt;
    public int lastObstacle;
    public int score;
    public int highScore;
    public int scoreIncrease;

    public Text scoreText;
    public Text highScoreText;
    // Start is called before the first frame update
    void Awake()
    {
        playerBody = GameObject.Find("PlayerBody");
        playerTarget = GameObject.Find("Player").transform;
        restartButton = GameObject.Find("RestartButton");
        menuButton = GameObject.Find("MenuButton");
        scoreIncrease = 1;
    }
    void Start()
    { 
        score = 0;
        lastInt = 1;
        lastObstacle = 0;
        Time.timeScale = 1;
        Time.fixedDeltaTime = 0.02f;
        x = playerTarget.position.x;
        y = playerTarget.position.y;
        z = playerTarget.position.z;
        startPos = new Vector3(x, y, z);
        restartButton.SetActive(false);
        menuButton.SetActive(false);
        if (endless)
        {
            highScoreText.text = PlayerPrefs.GetInt("HighScore").ToString();
            SpawnEnemies();
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        if(playerBody != null)
        {
            if (playerBody.GetComponent<HitDetection>().playerHealth <= 0)
            {
                playerBody.GetComponent<HitDetection>().playerHealth = 0;
                Lose();
            }
            if (endless)
            {
                scoreText.text = score.ToString();
                if (playerTarget.transform.position.z - startPos.z >= 60)
                {
                    startPos = new Vector3(playerTarget.transform.position.x, playerTarget.transform.position.y, playerTarget.transform.position.z);
                    SpawnEnemies();
                }
            }

            if (score > highScore)
            {
                PlayerPrefs.SetInt("HighScore", score);
            }
        }
        else
        {
            Lose();
        }
        
        
    }

    public void IncreaseScore()
    {
        score++;
        print("SCORE INCREASED");
    }
    public void SpawnEnemies()
    {
        if (endless)
        {
            
            mindif = playerTarget.position.z + 30;
            maxdif = playerTarget.position.z + 70;
            for (int i = 0; i < lastInt; i++)
            {
                x = Random.Range(-14, 14);
                z = Random.Range(mindif, maxdif);
                Instantiate(enemy, new Vector3(x, 0, z), Quaternion.identity);
                if (enemy.transform.position == enemy.position)
                {
                    transform.position = new Vector3(x, 0, z);
                }
            }
            lastInt += 1;
            SpawnBlocks();
        }
    }
    
    public void SpawnBlocks()
    {
        if (endless)
        {
            int obstacleSelect = Random.Range(1, 4);
            if (obstacleSelect == 1)
            {
                if (lastObstacle == 1)
                {
                    SpawnBlocks();
                }
                else
                {
                    lastObstacle = 1;
                    GameObject cloneCubes = (GameObject)Instantiate(Cubes, new Vector3(0, 0, maxdif), Quaternion.identity);
                    Destroy(cloneCubes, 20f);
                    print("destroid");
                }
                
            }
            if (obstacleSelect == 2)
            {
                if (lastObstacle == 2)
                {
                    SpawnBlocks();
                }
                else
                {
                    lastObstacle = 2;
                    GameObject cloneRightXs = (GameObject)Instantiate(RightXs, new Vector3(0, 0, maxdif), Quaternion.identity);
                    Destroy(cloneRightXs, 20f);
                    print("destroid");
                }
                
            }
            if (obstacleSelect == 3)
            {
                if (lastObstacle == 3)
                {
                    SpawnBlocks();
                }
                else
                {
                    lastObstacle = 3;
                    GameObject cloneLeftXs = (GameObject)Instantiate(LeftXs, new Vector3(0, 0, maxdif), Quaternion.identity);
                    Destroy(cloneLeftXs, 20f);
                    print("destroid");
                }
                
            }
            if (obstacleSelect == 4)
            {
                if (lastObstacle == 4)
                {
                    SpawnBlocks();
                }
                else
                {
                    lastObstacle = 4;
                    GameObject clonePyramids = (GameObject)Instantiate(Pyramids, new Vector3(0, 0, maxdif), Quaternion.identity);
                    Destroy(clonePyramids, 20f);
                    print("destroid");
                }
                
            }
        }
    }
    
    void Lose()
    {
        Time.timeScale = 0.1f;
        Time.fixedDeltaTime = Time.timeScale * 0.02f;
        restartButton.SetActive(true);
        menuButton.SetActive(true);
    }

    public void RestartButton()
    {
        Time.timeScale = 0.1f;
        Time.fixedDeltaTime = Time.timeScale * 0.02f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void MenuButton()
    {
        Time.timeScale = 0.1f;
        Time.fixedDeltaTime = Time.timeScale * 0.02f;
        SceneManager.LoadScene("Menu");
    }


}
