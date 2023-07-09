using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainGameStatesGameResult : MainGameState
{
    public MainGameStatesGameResult(MainGameStateMachine stateMachine) : base(stateMachine)
    {
    }

    public override void Enter()
    {
        Debug.Log("MainGameStatesResult Enter");
        //ƒJƒƒ‰‚Ì‰Šú‰»
        MainGameCameraManager.Instance.DetouchFollowCamera();
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
