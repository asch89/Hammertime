using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Transform target;
    Quaternion rotation;
    void Awake()
    {

    }
    // Start is called before the first frame update
    void Start()
    {
        rotation = transform.rotation;
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //transform.rotation = rotation;
        transform.position = target.position;
    }
}
