using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyBehaviour : MonoBehaviour
{
    public float speed;
    public Transform target;
    public Transform sword;
    Transform playerTarget;
    Rigidbody rb;
    Transform sightArea;
    public Transform enemy;

    public bool canSee;
    public bool isAlive;
    public bool endless;

    public int health;
    public int damage;

    public GameController gc;
    

    Renderer enemyRend;

    public CameraShake cameraShake;

    public GameObject canvas;

    Vector3 startPos = new Vector3(0, 0, 0);
    // Start is called before the first frame update

    private void Awake()
    {
        enemyRend = GetComponent<Renderer>();
        target = GameObject.Find("Player").transform;
        sightArea = transform.Find("SightArea").transform;
        sword = GameObject.Find("Sword").transform;
        cameraShake = GameObject.Find("Main Camera").GetComponent<CameraShake>();
        playerTarget = GameObject.Find("Player").transform;
        gc = GameObject.Find("Canvas").GetComponent<GameController>();
    }
    void Start()
    {
        speed = 15;
        health = 50;
        damage = 50;
        rb = GetComponent<Rigidbody>();
        canSee = false;
        isAlive = true;
    }

    // Update is called once per frame
    void Update()
    {
        
        if (health <= 0)
        {
            health = 0;
            isAlive = false;
        }
        else
        {
            isAlive = true;
        }
        Chase();
        
    }
    
    
     void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "hammerend")
        {
            if (isAlive)
            {
                gc.IncreaseScore();
                
                rb.AddForce(0, 400, -50);
                health -= damage;
                enemyRend.material.color = new Color(enemyRend.material.color.r, enemyRend.material.color.g - damage, enemyRend.material.color.b, enemyRend.material.color.a);
                Time.timeScale = 0.4f;
                Time.fixedDeltaTime = Time.timeScale * 0.02f;
                StartCoroutine(cameraShake.Shake(.075f, 2f));
                Invoke("ResetTimeScale", 0.1f);
                Invoke("DeleteEnemy", 5.0f);
                
            }
            
        }
        
    }

    public void Chase()
    {
        if (isAlive)
        {
            if (canSee)
            {
                if(target != null)
                {
                    canSee = true;
                    transform.LookAt(new Vector3(target.position.x, target.position.y, target.position.z));
                    rb.MovePosition(transform.position + (transform.forward * speed * Time.deltaTime));
                }
                
            }
        }
    }

    void ResetTimeScale()
    {
        Time.timeScale = 1;
        Time.fixedDeltaTime = 0.02f;
    }

    void DeleteEnemy()
    {
        Destroy(gameObject);
    }

    
}
