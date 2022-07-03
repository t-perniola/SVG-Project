using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIAgent : MonoBehaviour
{
    public AIStateMachine stateMachine;
    public AIStateId initialState;
    public UnityEngine.AI.NavMeshAgent navMeshAgent;
    public AIAgentConfig config;

    void Start()
    {
        navMeshAgent = GetComponent<UnityEngine.AI.NavMeshAgent>();
        stateMachine = new AIStateMachine(this);
        stateMachine.RegisterState(new AIChasePlayerState());
        stateMachine.ChangeState(initialState);
    }

    void Update()
    {
        stateMachine.Update();
    }
}
