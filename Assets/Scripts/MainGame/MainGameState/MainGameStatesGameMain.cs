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
        //Debug.Log("MainGameStatesGameMain Enter");
        //ゲームのメインに入った場合、プレイヤーの待つターンにする
        stateMachine.ChangeState(MainGameStateManager.Instance.MainGameStatesWaitTurn);
    }

    public override void Exit()
    {
        //Debug.Log("MainGameStatesGameMain Exit");
    }

    public override void Update()
    {
        //負けた場合
        if (GameCharacterDataProvider.Instance.PlayerCharacterControllers.All(x => x.GetIsDead))
        {
            stateMachine.ChangeState(MainGameStateManager.Instance.MainGameStatesGameLoseResult);
        }

        //勝った場合
        if (GameCharacterDataProvider.Instance.EnemyCharacterContorllers.All(x=>x.GetIsDead))
        {
            stateMachine.ChangeState(MainGameStateManager.Instance.MainGameStatesGameWinResult);
        }
        
    }
}
