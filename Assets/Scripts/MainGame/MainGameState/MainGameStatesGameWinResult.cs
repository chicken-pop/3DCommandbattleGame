using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainGameStatesGameWinResult : MainGameState
{
    private MainGameRenderingManager mainGameRenderingManager;

    public MainGameStatesGameWinResult(MainGameStateMachine stateMachine, MainGameRenderingManager _mainGameRenderingManager) : base(stateMachine)
    {
        mainGameRenderingManager = _mainGameRenderingManager;
    }

    public override void Enter()
    {
        Debug.Log("MainGameStatesResult Enter");
        MainGameCameraManager.Instance.WinCameraSetteing();
        mainGameRenderingManager.SetWinScreennRenderer();
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
