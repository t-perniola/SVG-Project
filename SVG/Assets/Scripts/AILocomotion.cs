using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AILocomotion : MonoBehaviour
{
    public Transform playerTransform;
    public NavMeshAgent agent;
    public float maxTime = 1.0f;
    public float maxDistance = 1.0f;
    Animator animator;
    LookAt lookAt;
    float timer = 0.0f;

    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();
        lookAt = GetComponent<LookAt> ();
    }

    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime;
        if(timer < 0.0f)
        {
            float sqDistance = (playerTransform.position - agent.destination).sqrMagnitude;
            if(sqDistance > maxDistance * maxDistance){
            agent.destination = playerTransform.position;  
            }
        timer = maxTime;
        }
        
        animator.SetFloat("Speed",agent.velocity.magnitude);

         
        if (lookAt)
            lookAt.lookAtTargetPosition = agent.steeringTarget + transform.forward;
    }
}
