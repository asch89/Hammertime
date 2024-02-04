using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public float moveSpeed = 5;
    float minX = -11.5f;
    float maxX = 11.5f;
    // Start is called before the first frame update

    void Awake()
    {

    }

    void Update()
    {
        transform.Translate(moveSpeed * Input.GetAxis("Horizontal") * Time.deltaTime, 0f, moveSpeed * Time.deltaTime, Space.World);
        //transform.Translate(moveSpeed * joystick.Horizontal * Time.deltaTime, 0f, moveSpeed * joystick.Vertical * Time.deltaTime);

        if (transform.position.x > maxX)
        {
            transform.position = new Vector3 (maxX, transform.position.y, transform.position.z);
        }

        if (transform.position.x < minX)
        {
            transform.position = new Vector3(minX, transform.position.y, transform.position.z);
        }
    }
}
