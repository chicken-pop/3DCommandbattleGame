using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainGameStateMachine
{
    private MainGameState currentState;

    public MainGameState GetMainGameState
    {
        get { return currentState; }
    }

    public bool IsState(MainGameState state)
    {
        return currentState == state;
    }

    public void ChangeState(MainGameState newState)
    {
        if(currentState != null)
        {
            currentState.Exit();
        }

        currentState = newState;
        currentState.Enter();
    }

    public void Update()
    {
        if(currentState != null)
        {
            currentState.Update();
        }
    }
}
