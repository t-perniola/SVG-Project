using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Rooms : MonoBehaviour
{
    public string roomName;
    public GameObject roomUI;
    //public GameObject missionUI;
    public string navigationName;

    // Start is called before the first frame update
    void Start()
    {
        roomUI.SetActive(false);
        //missionUI.SetActive(false);
    }

    void OnTriggerEnter(Collider player)
    {
        if  (player.gameObject.tag == "Player")
        {
            roomUI.SetActive(true);
           // missionUI.SetActive(true);
            roomUI.GetComponent<Text>().text = roomName;
            /*if(roomName == "Officina")
            {
                missionUI.GetComponent<Text>().text = "Sali Sopra";
            }
            */
        }
    }

    void OnTriggerExit(Collider player)
    {
        if (player.gameObject.tag == "Player")
        {
            roomUI.SetActive(false);
            //missionUI.SetActive(false);
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
