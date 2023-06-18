using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class MainGameStatesPlayerAttackTurn : MainGameStatesGameMain
{
    public MainGameStatesPlayerAttackTurn(MainGameStateMachine stateMachine) : base(stateMachine)
    {
    }

    public override void Enter()
    {
        base.Enter();
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void Update()
    {
        base.Update();

        //�A�j���[�V�������I�������WaitTurn�Ɉڍs����
        if(GameCharacterDataProvider.Instance.PlayerCharacterControllers.All(player => !player.IsActionChoiced))
        {
            stateMachine.ChangeState(MainGameStateManager.Instance.MainGameStatesPlayerWaitTurn);
        }
    }
}
