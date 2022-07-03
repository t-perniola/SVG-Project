using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AILocomotion : MonoBehaviour
{
    Animator animator;
    public NavMeshAgent agent;
    LookAt lookAt;
    

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
        if(agent.hasPath) {
            animator.SetFloat("Speed",agent.velocity.magnitude);
        } 
        else
        {
            animator.SetFloat("Speed",0);
        }
        

         
        if (lookAt)
            lookAt.lookAtTargetPosition = agent.steeringTarget + transform.forward;
        
    }
}
