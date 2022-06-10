using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpaceAttack : MonoBehaviour
{
    [SerializeField]Transform target;
    [SerializeField]Laser laser;

    Vector3 hitPosition;
    
    void Update(){
        InFront();
        HaveLineOfSight();
        if(InFront() && HaveLineOfSight())
        {
            FireLaser();
            Debug.Log("fire laser");
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
}
