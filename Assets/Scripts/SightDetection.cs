using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SightDetection : MonoBehaviour
{
    //EnemyBehaviour eb;
    public GameObject enemy;
    
    // Start is called before the first frame update

    void Awake()
    {

    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "player")
        {
            enemy.GetComponent<EnemyBehaviour>().canSee = true;
        }
    }
}
