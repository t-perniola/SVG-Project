using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Rooms : MonoBehaviour
{
    public string roomName;
    public GameObject roomUI;

    // Start is called before the first frame update
    void Start()
    {
        roomUI.SetActive(false);
    }

    void OnTriggerEnter(Collider player)
    {
        if  (player.gameObject.tag == "Player")
        {
            roomUI.SetActive(true);
            roomUI.GetComponent<Text>().text = roomName;
        }
    }

    void OnTriggerExit(Collider player)
    {
        if (player.gameObject.tag == "Player")
        {
            roomUI.SetActive(false);
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
