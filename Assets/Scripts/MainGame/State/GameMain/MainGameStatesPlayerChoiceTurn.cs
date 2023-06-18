using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class MainGameStatesPlayerChoiceTurn : MainGameStatesGameMain
{
    public MainGameStatesPlayerChoiceTurn(MainGameStateMachine stateMachine) : base(stateMachine)
    {
    }

    public override void Enter()
    {

    }

    public override void Exit()
    {

    }

    public override void Update()
    {
        base.Update();

        if(GameCharacterDataProvider.Instance.PlayerCharacterControllers.Any(player => player.IsActionChoiced))
        {
            stateMachine.ChangeState(MainGameStateManager.Instance.MainGameStatesPlayerAttackTurn);
        }


    }
}
