using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class MainGameStatesChoiceTurn : MainGameStatesGameMain
{
    public MainGameStatesChoiceTurn(MainGameStateMachine stateMachine) : base(stateMachine)
    {
    }

    public override void Enter()
    {
        var gaugeFullCharacterData = MainGameUISettingManager
            .Instance.GetCharacterUIRoots
            .Find(gauge => gauge.IsGaugeFull).GetCharacterUIData;
        var gaugeFullPlayer = GameCharacterDataProvider.Instance
            .PlayerCharacterControllers.Find(player => player.GetCharacterData == gaugeFullCharacterData);

        MainGameUISettingManager.Instance.SetButton(gaugeFullPlayer);

    }

    public override void Exit()
    {

    }

    public override void Update()
    {
        base.Update();

        if (GameCharacterDataProvider.Instance.PlayerCharacterControllers.Any(player => player.IsActionChoiced))
        {
            stateMachine.ChangeState(MainGameStateManager.Instance.MainGameStatesAttackTurn);
        }


    }
}
