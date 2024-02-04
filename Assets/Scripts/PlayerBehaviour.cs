using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerBehaviour : MonoBehaviour
{
    public Transform enemy;
    GameObject player;
    GameObject PlayerTarget;
    
    CapsuleCollider playerBody;
    
    Transform sword;
    Rigidbody rb;
    public float x;
    public float y;
    public float z;
    public float thrust;
    bool isBlocking;
    [System.NonSerialized] public bool swordIsPaired;
    HitDetection hd;
    Collider WinZone;
    Text WinText;
    Transform fakeSword;
    public bool endless;
    

    // Start is called before the first frame update
    void Awake()
    {
        
        //GameObject enemycylinder = GameObject.FindGameObjectWithTag("enemy");
        //enemy = enemycylinder.transform;
        player = GameObject.Find("Player");
        sword = GameObject.FindGameObjectWithTag("sword").transform;
        if(fakeSword != null)
        {
            fakeSword = GameObject.Find("FakeSword").transform;
        }
        
        playerBody = GameObject.Find("PlayerBody").GetComponent<CapsuleCollider>();
        rb = GameObject.Find("Player").GetComponent<Rigidbody>();
        //WinText = GameObject.Find("WinText").GetComponent<Text>();
        
        
        x = sword.transform.localScale.x;
        y = sword.transform.localScale.y;
        z = sword.transform.localScale.z;

    }
    void Start()
    {
        if (!endless)
        {
            sword.gameObject.SetActive(false);
        }
        
    }

    public void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "fakesword")
        {
            print("swordispaired");
            sword.gameObject.SetActive(true);
            fakeSword.gameObject.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    

    void Swing()
    {
        isBlocking = false;
        sword.transform.localScale = new Vector3(x, y, z);
    }

    void Block()
    {
        print("Blocking");
        isBlocking = true;
        sword.transform.localScale = new Vector3(z, y, x);
    }

    

    void OnEnable()
    {
    }

    void OnDisable()
    {
    }

}

