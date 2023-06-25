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
        //�Q�[���̃��C���ɓ������ꍇ�A�v���C���[�̑҂^�[���ɂ���
        stateMachine.ChangeState(MainGameStateManager.Instance.MainGameStatesPlayerWaitTurn);
    }

    public override void Exit()
    {
        Debug.Log("MainGameStatesGameMain Exit");
    }

    public override void Update()
    {
        Debug.Log("MainGameStatesGameMain Update");
        //MainGameCharacterController��Hp���擾����
        if(GameCharacterDataProvider.Instance.PlayerCharacterControllers.All(x => x.GetCharacterData.HitPoint <= 0))
        {
            //HitPoint���Ȃ��Ȃ�����Result��
            stateMachine.ChangeState(MainGameStateManager.Instance.MainGameStatesGameResult);
        }
        
    }
}
