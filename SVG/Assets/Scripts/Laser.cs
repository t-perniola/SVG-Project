using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Light))]
[RequireComponent(typeof(LineRenderer) )]
public class Laser : MonoBehaviour{
    [SerializeField]float laserOffline = .5f;
    [SerializeField]float maxDistance = 300f;
    LineRenderer lr;
    Light laserLight;
    bool canFire;

    void Awake()
    {
        lr = GetComponent<LineRenderer>();
        laserLight = GetComponent<Light>();
    }

    void Start()
    {
        lr.enabled = false;
        laserLight.enabled = false;
    }
    
   /* void Update()
    {
        FireLaser(transform.position +(transform.forward * maxDistance));
    }
    */
    public void FireLaser(Vector3 targetPosition)
    {
        if(canFire)
        {
            lr.SetPosition(0, transform.position);
            lr.SetPosition(1, transform.position +(transform.forward * maxDistance));
            lr.enabled = true;
            laserLight.enabled = true;
            canFire = false;
        }

        Invoke("TurnOffLaser", laserOffline);
    }

    void TurnOffLaser()
    {
        lr.enabled = false;
        laserLight.enabled = false;
        canFire = true;
    } 

    //Distanza massima del laser
    public float Distance
    {
        get { return maxDistance; }
    }
}
