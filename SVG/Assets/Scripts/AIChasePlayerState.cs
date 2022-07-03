using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AIChasePlayerState : AIState
{
    public Transform playerTransform;
    float timer = 0.0f;


    public AIStateId GetId()
    {
        return AIStateId.ChasePlayer;
    }
    public void Enter(AIAgent agent)
    {
        if (playerTransform == null)
        {
            playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
        }
    }
    public void Update(AIAgent agent)
    {
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
        if (!agent.navMeshAgent.enabled)
        {
            return;
        }

        timer -= Time.deltaTime;
        if(!agent.navMeshAgent.hasPath)
        {
            agent.navMeshAgent.destination = playerTransform.position;
        }

        timer -= Time.deltaTime;
        if(timer < 0.0f)
        {
            Vector3 direction = (playerTransform.position - agent.navMeshAgent.destination);
            direction.y = 0;
            if(direction.sqrMagnitude > agent.config.maxDistance * agent.config.maxDistance)
            {
                if(agent.navMeshAgent.pathStatus != NavMeshPathStatus.PathPartial)
                {
                    agent.navMeshAgent.destination = playerTransform.position;
                }
              
            }
        timer = agent.config.maxTime;
        }
        
        

    }
    public void Exit(AIAgent agent)
    {

    }

}
