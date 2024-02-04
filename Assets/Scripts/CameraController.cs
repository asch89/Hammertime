using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform player;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 playerposition = new Vector3(player.position.x, player.position.y + 12, player.position.z-10);
        transform.position = Vector3.Slerp(transform.position, new Vector3(playerposition.x, playerposition.y, playerposition.z), Time.deltaTime * 10.0f);
    }
}
