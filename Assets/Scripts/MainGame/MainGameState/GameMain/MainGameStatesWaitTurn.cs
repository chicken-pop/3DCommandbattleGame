using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class MainGameStatesWaitTurn : MainGameStatesGameMain
{
    public MainGameStatesWaitTurn(MainGameStateMachine stateMachine) : base(stateMachine)
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

        //どれか一つでもゲージがフルであれば
        if(GameCharacterDataProvider.Instance.CharacterUIRoots.Any(uiRoot => uiRoot.IsGaugeFull))
        {
            //もしゲージがフルになったら選択するターンに移行する
            stateMachine.ChangeState(MainGameStateManager.Instance.MainGameStatesChoiceTurn);
        }

        foreach (var enemyControllers in GameCharacterDataProvider.Instance.EnemyCharacterContorllers)
        {
            if(enemyControllers.IsActionChoiced && stateMachine.IsState(MainGameStateManager.Instance.MainGameStatesWaitTurn))
            {
                enemyControllers.SetAnimnation();
                stateMachine.ChangeState(MainGameStateManager.Instance.MainGameStatesAttackTurn);
            }
        }

        /*
        if (GameCharacterDataProvider.Instance.EnemyCharacterContorllers.FirstOrDefault())
        {
            //Debug.Log(enemyWaitTime);
            enemyWaitTime -= GameCharacterDataProvider
                .Instance.EnemyCharacterContorllers
                .FirstOrDefault().GetCharacterData
                .Speed * Time.deltaTime;

            if (enemyWaitTime < 0 && !stateMachine.IsState(MainGameStateManager.Instance.MainGameStatesChoiceTurn))
            {
                enemyWaitTime = 100f;
                GameCharacterDataProvider.Instance.EnemyCharacterContorllers.FirstOrDefault().SetAnimnation(0);
                stateMachine.ChangeState(MainGameStateManager.Instance.MainGameStatesAttackTurn);
            }
        }
        */
    }
}
