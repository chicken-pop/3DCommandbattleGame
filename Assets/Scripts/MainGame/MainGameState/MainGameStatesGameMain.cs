using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class MainGameStatesGameMain : MainGameState
{
    public MainGameStatesGameMain(MainGameStateMachine stateMachine) : base(stateMachine)
    {
    }

    public override void Enter()
    {
        Debug.Log("MainGameStatesGameMain Enter");
        //ゲームのメインに入った場合、プレイヤーの待つターンにする
        stateMachine.ChangeState(MainGameStateManager.Instance.MainGameStatesPlayerWaitTurn);
    }

    public override void Exit()
    {
        Debug.Log("MainGameStatesGameMain Exit");
    }

    public override void Update()
    {
        Debug.Log("MainGameStatesGameMain Update");
        //MainGameCharacterControllerのHpを取得する
        if(GameCharacterDataProvider.Instance.PlayerCharacterControllers.All(x => x.GetCharacterData.HitPoint <= 0))
        {
            //HitPointがなくなったらResultに
            stateMachine.ChangeState(MainGameStateManager.Instance.MainGameStatesGameResult);
        }
        
    }
}
