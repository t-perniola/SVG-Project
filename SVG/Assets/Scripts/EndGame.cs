using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndGame : MonoBehaviour
{
     void OnTriggerEnter(Collider player)
    {

        if (player.gameObject.tag == "Player")
        {
            SceneManager.LoadScene("WinScreen");
        }
    }

}
