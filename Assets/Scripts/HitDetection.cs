using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using EZCameraShake;

public class HitDetection : MonoBehaviour
{

    public int playerHealth = 100;
    public Text healthText;
    public bool isBody = false;
    public bool playerDead;
    Rigidbody ptrb;
    public float flashTime;
    Color originalColor;
    Renderer playerRenderer;
    PlayerBehaviour pb;
    GameObject player;
    public GameObject enemy;
    GameObject enemyHit;
    GameObject playerController;
    

    // Start is called before the first frame update
    void Awake()
    {
        healthText = GameObject.Find("HealthText").GetComponent<Text>();
        ptrb = GameObject.Find("PlayerRB").GetComponent<Rigidbody>();
        playerRenderer = GameObject.Find("Player").GetComponent<Renderer>();
        player = GameObject.Find("Player");
        playerController = GameObject.Find("Player Controller");

        originalColor = playerRenderer.material.color;
        
    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        healthText.text = playerHealth.ToString();

        if (healthText.text == "0")
        {
            playerDead = true;
            Destroy(player);
            
        }
    }

    public void OnTriggerEnter(Collider other)
    {
        if (isBody)
        {
            if (other.gameObject.tag == "enemy")
            {
                
                enemyHit = other.gameObject;
                PlayerHit(other.gameObject);
            }
        }

    }

    void PlayerHit(GameObject e)
    {
        if (e.GetComponent<EnemyBehaviour>().isAlive)
        {
            ptrb.AddForce(0, 0, -600);
            playerHealth -= 10;
            playerRenderer.material.color = Color.red;
            Invoke("ResetColor", 0.1f);
            //CameraShaker.Instance.ShakeOnce(4f, 4f, 0.1f, 1f);
        }
        
        
    }

    void ResetColor()
    {
        playerRenderer.material.color = originalColor;
    }
}
