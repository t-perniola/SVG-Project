using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpaceMovement : MonoBehaviour
{
    [SerializeField]Transform target;
    [SerializeField]float movementSpeed = 10f;
    [SerializeField]float rotationalDamp = .5f;
    [SerializeField]float detectionDistance = 30f;
    [SerializeField]float followingDistance = 35f;
    

    void OnEnable()
    {
        EventManager.onSpaceFightGame  += Update;
        EventManager.onPlayerDeath += FindMainCamera;
    }

    void OnDisable()
    {   
        EventManager.onSpaceFightGame  -= Update;
        EventManager.onPlayerDeath -= FindMainCamera;
        
    }

    void SelfDestruct()
    {
        Destroy(gameObject);
    }

    void Update()
    {   
        float distance = Vector3.Distance(target.position,transform.position);
        if(distance > followingDistance)
        { 
            Pathfinding();
           if(!FindTarget())
            {
                return;
            }
            
        
            Move();
         }
        else
        {
            return;
        }
        
    }

    void Turn()
    {
        Vector3 pos = target.position - transform.position;
        Quaternion rotation = Quaternion.LookRotation(pos);
        transform.rotation = Quaternion.Slerp(transform.rotation, rotation, rotationalDamp * Time.deltaTime);
    }

    void Move()
    {
        transform.position += transform.forward * movementSpeed* Time.deltaTime;
    }

    //Metodo per trovare se qualcosa collide difronte alla nave nemica
    void Pathfinding()
    {
        RaycastHit hit;
        Vector3 raycastOffset = Vector3.zero; 

        Vector3 left = transform.position - transform.right;
        Vector3 right = transform.position + transform.right;
        Vector3 up = transform.position + transform.up;
        Vector3 down = transform.position - transform.up;  

        Debug.DrawRay(left, transform.forward * detectionDistance, Color.cyan);
        Debug.DrawRay(right, transform.forward * detectionDistance, Color.cyan);
        Debug.DrawRay(up, transform.forward * detectionDistance, Color.cyan);
        Debug.DrawRay(down, transform.forward * detectionDistance, Color.cyan);

        if(Physics.Raycast(left, transform.forward, out hit, detectionDistance))
        {
            raycastOffset += Vector3.right;
        }
        else if(Physics.Raycast(right, transform.forward, out hit, detectionDistance))
        {
            
            raycastOffset -= Vector3.right;
        }

        if(Physics.Raycast(up, transform.forward, out hit, detectionDistance))
        {
            raycastOffset += Vector3.up;
        }
        else if(Physics.Raycast(down, transform.forward, out hit, detectionDistance))
        {
            raycastOffset -= Vector3.up;
        }

        if(raycastOffset != Vector3.zero)
        {
            Debug.Log("Il nemico ha qualcosa davanti");
           transform.Rotate(raycastOffset * 5f * Time.deltaTime);
        }
        else
        {
            Turn();
        }
    }

    bool FindTarget()
    {
        if( target == null)
            {
                GameObject temp = GameObject.FindGameObjectWithTag("Player");

                if(temp != null)
                    {
                        target = temp.transform;
                    }
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

    void FindMainCamera()
    {
        target = GameObject.FindGameObjectWithTag("MainCamera").transform;
    }
}

