using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainGameStatesGameLoseResult : MainGameState
{
    private MainGameRenderingManager mainGameRenderingManager;

    public MainGameStatesGameLoseResult(MainGameStateMachine stateMachine, MainGameRenderingManager _mainGameRenderingManager) : base(stateMachine)
    {
        mainGameRenderingManager = _mainGameRenderingManager;
    }

    public override void Enter()
    {
        Debug.Log("MainGameStatesResult Enter");
        MainGameCameraManager.Instance.LoseCameraSetteing();
        mainGameRenderingManager.SetLoseScreenRenderer();
        MainGameUISettingManager.Instance.AllInvisibleCharacterUIs();

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
