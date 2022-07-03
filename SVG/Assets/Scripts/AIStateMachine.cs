using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIStateMachine 
{
    public AIState[] states;
    public AIAgent agent;
    public AIStateId currentState;

    public AIStateMachine(AIAgent agent)
    {
        this.agent = agent;
        int numStates = System.Enum.GetNames(typeof(AIStateId)).Length;
        states = new AIState[numStates];
    }

    public void RegisterState(AIState state)
    {
        int index = (int)state.GetId();
        states[index] = state;
    }

    public AIState GetState(AIStateId stateId) 
    {
        int index = (int)stateId;
        return states[index];
    }

    public void Update()
    {
        GetState(currentState)?.Update(agent);
    }

    public void ChangeState(AIStateId newState)
    {
        GetState(currentState)?.Exit(agent);
        currentState = newState; 
        GetState(currentState)?.Enter(agent);
    }
}

