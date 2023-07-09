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
        //�Q�[���̃��C���ɓ������ꍇ�A�v���C���[�̑҂^�[���ɂ���
        stateMachine.ChangeState(MainGameStateManager.Instance.MainGameStatesWaitTurn);
    }

    public override void Exit()
    {
        //Debug.Log("MainGameStatesGameMain Exit");
    }

    public override void Update()
    {
        //�������ꍇ
        if (GameCharacterDataProvider.Instance.PlayerCharacterControllers.All(x => x.GetIsDead))
        {
            stateMachine.ChangeState(MainGameStateManager.Instance.MainGameStatesGameLoseResult);
        }

        //�������ꍇ
        if (GameCharacterDataProvider.Instance.EnemyCharacterContorllers.All(x=>x.GetIsDead))
        {
            stateMachine.ChangeState(MainGameStateManager.Instance.MainGameStatesGameWinResult);
        }
        
    }
}
