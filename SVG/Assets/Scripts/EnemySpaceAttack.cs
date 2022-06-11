using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpaceAttack : MonoBehaviour
{
    [SerializeField]Transform target;
    [SerializeField]Laser laser;
    [SerializeField]int distanceShip = 30;

    Vector3 hitPosition;
    Vector3 hitPositionrandom;
    float timePassed = 0f;
    public float innaccuracy = 0.9f;

    void Update(){
        if(!FindTarget()){
            return;
        }
        InFront();
        HaveLineOfSight();
        if(InFront() && HaveLineOfSight())
        {
            FireLaser();
            Debug.Log("fire laser");
        } else
        {
            timePassed += Time.deltaTime;
          if (timePassed > 5f)
            {
                 if (CloseEnought())
                  {
                    hitPositionrandom = Random.insideUnitSphere * innaccuracy;
                    Debug.Log("fire laser random");
                    FireLaser(hitPositionrandom);
                    
                    timePassed = 0f;
                  }
            }
        }
    }

     bool CloseEnought()
    {
        if(Vector3.Distance(transform.position, target.position) < distanceShip)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    bool InFront()
    {
        //Direzione fra il nemico e la navicella
        Vector3 directionToTarget = transform.position - target.position;
        float angle = Vector3.Angle(transform.forward, directionToTarget);

        //Se nel range
        if(Mathf.Abs(angle) > 90 && Mathf.Abs(angle) < 270)
        {
            Debug.DrawLine(transform.position, target.position, Color.green);
            return true;
        }
        Debug.DrawLine(transform.position, target.position, Color.yellow);
        return false;
    }

    bool HaveLineOfSight()
    {
        RaycastHit hit;

        Vector3 direction = target.position - transform.position;
        Debug.DrawRay(laser.transform.position, direction, Color.red );
        if(Physics.Raycast(laser.transform.position, direction, out hit, laser.Distance))
        {
            if(hit.transform.CompareTag("Player"))
            {
                hitPosition = hit.transform.position;
                return true;
            }
        }
        return false;
    }

    void FireLaser()
    {
        Debug.Log("Fire Lasers!!!!");
        laser.FireLaser(hitPosition, target);
    }

    void FireLaser(Vector3 hitPositionR)
    {
        Debug.Log("Fire Lasers random!!!!");
        laser.FireLaser(hitPositionR, target);
    }


    bool FindTarget()
    {
        if( target == null)
            {
                target = GameObject.FindGameObjectWithTag("Player").transform;
            }
        if( target == null)
            {
                return false;
            }
        else
            {
                return true;
            }
        
    }

    
}
