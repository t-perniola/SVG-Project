using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInputLaser : MonoBehaviour
{
    [SerializeField]PlayerLaser[] laser;
    // Update is called once per frame
    void Update()
    {
        
        if(Input.GetMouseButtonDown(0))
        {
            foreach(PlayerLaser l in laser)
            {
                //Vector3 pos = transform.position + (transform.forward * l.Distance);
                l.FireLaser();
            }
        }   
    }
}
