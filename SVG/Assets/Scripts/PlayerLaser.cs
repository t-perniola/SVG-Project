using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Light))]
[RequireComponent(typeof(LineRenderer) )]
public class PlayerLaser : MonoBehaviour{
    [SerializeField]float laserOffline = .5f;
    [SerializeField]float maxDistance = 300f;
    [SerializeField]float fireDelay = 2f;
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
        canFire = true;
    }
    
    void Update()
    {
        Debug.DrawRay( transform.position, transform.TransformDirection(Vector3.forward) * maxDistance, Color.yellow);
    }
    
    
    //Vettore per trovare se viene colpito qualcosa
    Vector3 CastRay()
    {
        RaycastHit hit;

        Vector3 fwd = transform.TransformDirection(Vector3.forward) * maxDistance;

        if(Physics.Raycast(transform.position, fwd, out hit))
        {
            Debug.Log("We hit: " + hit.transform.name);

            SpawnExplosion(hit.point, hit.transform);

            return hit.point;
        } else {
            Debug.Log("We missed....");
        }
            
        return transform.position + (transform.forward * maxDistance);
    }

    //Se colpisce qualcosa -> animazione esplosione
    void SpawnExplosion(Vector3 hitPosition, Transform target)
    {
        EnemyExplosion temp = target.GetComponent<EnemyExplosion>();
            if(temp != null)
            {
             temp.AddForce(hitPosition, transform);
            }
    }

    //Laser navicella giocatore
    public void FireLaser()
    {
        Vector3 pos = CastRay();
        FireLaser(pos);
        //FireLaser(CastRay());
     
    }

    //Nemico ci vede e spara + null parameter
    public void FireLaser(Vector3 targetPosition, Transform target = null)
    {
        if(canFire)
        {
            if(target != null) 
            {
                SpawnExplosion(targetPosition, target);
            }
                
             
            lr.SetPosition(0, transform.position);
            lr.SetPosition(1, CastRay());
            lr.enabled = true;
            laserLight.enabled = true;
            canFire = false;
            Invoke("TurnOffLaser", laserOffline);
            Invoke("CanFire", fireDelay);
        }
     
    }

    void TurnOffLaser()
    {
        lr.enabled = false;
        laserLight.enabled = false;
    } 

    //Distanza massima del laser
    public float Distance
    {
        get { return maxDistance; }
    }

    void CanFire()
    {
        canFire = true;
    }
}
