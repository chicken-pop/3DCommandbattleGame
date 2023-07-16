using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainGameStatesGameInit : MainGameState
{
    public MainGameStatesGameInit(MainGameStateMachine stateMachine) : base(stateMachine)
    {
    }

    public override void Enter()
    {
        Debug.Log("MainGameStatesGameInit Enter");
        GameCharacterDataProvider.Instance.SetCharacterUIRoots();
    }

    public override void Exit()
    {
        Debug.Log("MainGameStatesInit Exit");
    }

    public override void Update()
    {
        Debug.Log("MainGameStatesGameInit Update");
        stateMachine.ChangeState(MainGameStateManager.Instance.MainGameStatesGameStart);
    }
}
