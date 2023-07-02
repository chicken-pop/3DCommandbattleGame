using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class MainGameStatesWaitTurn : MainGameStatesGameMain
{
    private List<CharacterUIRoot> characterUIRoots;
    private float enemyWaitTime = 100f;

    public MainGameStatesWaitTurn(MainGameStateMachine stateMachine, List<CharacterUIRoot> characterUIRoots) : base(stateMachine)
    {
        this.characterUIRoots = characterUIRoots;
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
        if(characterUIRoots.Any(uiRoot => uiRoot.IsGaugeFull))
        {
            //もしゲージがフルになったら選択するターンに移行する
            stateMachine.ChangeState(MainGameStateManager.Instance.MainGameStatesChoiceTurn);
        }
        else
        {
            Debug.Log("aaa");
        }

        if (GameCharacterDataProvider.Instance.EnemyCharacterContorllers.FirstOrDefault())
        {
            Debug.Log(enemyWaitTime);
            enemyWaitTime -= GameCharacterDataProvider
                .Instance.EnemyCharacterContorllers
                .FirstOrDefault().GetCharacterData
                .Speed * Time.deltaTime;

            if (enemyWaitTime < 0)
            {
                enemyWaitTime = 100f;
                GameCharacterDataProvider.Instance.EnemyCharacterContorllers.FirstOrDefault().SetAnimnation(0);
                stateMachine.ChangeState(MainGameStateManager.Instance.MainGameStatesAttackTurn);
            }
        }
    }
}
