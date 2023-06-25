using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class MainGameState
{
    protected MainGameStateMachine stateMachine;

    public MainGameState(MainGameStateMachine stateMachine)
    {
        this.stateMachine = stateMachine;
    }

    public virtual void Enter()
    {

    }

    public virtual void Exit()
    {

    }

    public virtual void Update()
    {

    }


}
