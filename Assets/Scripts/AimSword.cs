using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AimSword : MonoBehaviour
{
    public float speed;
    public GameObject player;
    public Joystick joystick;

    Vector2 aim;


    float minX = -11.5f;
    float maxX = 11.5f;

    [SerializeField] Vector3 mousePos;
    void Awake()
    {

    }
    void Start()
    {
    }

    // Update is called once per framey
    void FixedUpdate()
    {

        mousePos = Input.mousePosition;
        mousePos.z = 5.23f;
        /*
        if(mousePos.x > maxX)
        {
            mousePos.x = maxX;
        }

        if (mousePos.x < minX)
        {
            mousePos.x = minX;
        }
        */
        Vector3 objectPos = Camera.main.WorldToScreenPoint(transform.position);
        mousePos.x = mousePos.x - objectPos.x;
        mousePos.y = mousePos.y - objectPos.y;

        float angle = Mathf.Atan2(mousePos.x, mousePos.y) * Mathf.Rad2Deg;
           
        Quaternion qTo = Quaternion.Euler(new Vector3(0, angle, 0));
        transform.rotation = Quaternion.Slerp(transform.rotation, qTo, speed * Time.deltaTime);
            
            
        

        //var mouse = Input.mousePosition;
        //var screenPoint = Camera.main.WorldToScreenPoint(transform.localPosition);
        //var offset = new Vector2(mouse.x - screenPoint.x, mouse.y - screenPoint.y);
        //var angle = Mathf.Atan2(offset.y, offset.x) * Mathf.Rad2Deg;
        //transform.rotation = Quaternion.Euler(0, angle, 0);
        //var targetPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        //targetPos.y = transform.position.y;
        // transform.position = Vector3.MoveTowards(transform.position, targetPos, Time.deltaTime);
        

        Vector3 lookVec = new Vector3(aim.x, 0, aim.y);
        transform.LookAt(transform.position + lookVec);
    }

    void OnEnable()
    {
    }

    void OnDisable()
    {
    }
}
