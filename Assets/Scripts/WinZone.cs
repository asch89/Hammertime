using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WinZone : MonoBehaviour
{

    Text WinText;
    [SerializeField] bool InZone = false;
    public GameObject PlayerRB;
    // Start is called before the first frame update

    void Awake()
    {
        WinText = GameObject.Find("WinText").GetComponent<Text>();
    }
    void Start()
    {
        
        WinText.text = "";
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject == PlayerRB)
        {
            WinText.text = "LEVEL COMPLETE";
            InZone = true;
        }
        
        
    }
}
