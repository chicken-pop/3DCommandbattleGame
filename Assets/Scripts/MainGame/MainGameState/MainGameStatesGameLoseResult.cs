using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainGameStatesGameLoseResult : MainGameState
{
    public MainGameStatesGameLoseResult(MainGameStateMachine stateMachine) : base(stateMachine)
    {
    }

    public override void Enter()
    {
        Debug.Log("MainGameStatesResult Enter");
        MainGameCameraManager.Instance.LoseCameraSetteing();
    }

    public override void Exit()
    {
        Debug.Log("MainGameStatesResult Exit");
    }

    public override void Update()
    {
        Debug.Log("MainGameStatesResult Update");
    }
}
