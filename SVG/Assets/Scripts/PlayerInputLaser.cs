using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInputLaser : MonoBehaviour
{
    [SerializeField]PlayerLaser[] laser;
    public AudioClip shoot;    
    [Range(0, 1)] public float ShootAudioVolume = 0.5f; 
    // Update is called once per frame
    void Update()
    {
        
        if(Input.GetMouseButtonDown(0))
        {
            foreach(PlayerLaser l in laser)
            {
                AudioSource.PlayClipAtPoint(shoot, transform.position, ShootAudioVolume);
                //Vector3 pos = transform.position + (transform.forward * l.Distance);
                l.FireLaser();
            }
        }   
    }
}
