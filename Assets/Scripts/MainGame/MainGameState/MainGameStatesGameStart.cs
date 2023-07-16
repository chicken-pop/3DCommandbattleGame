using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class MainGameStatesGameStart : MainGameState
{
    public MainGameStatesGameStart(MainGameStateMachine stateMachine) : base(stateMachine)
    {
        
    }

    public override void Enter()
    {
        Debug.Log("MainGameStatesGameStart Enter");

        for (int i = 0; i < GameCharacterDataProvider.Instance.PlayerCharacterControllers.Count(); i++)
        {
            //UIのInitialize
            GameCharacterDataProvider.Instance.CharacterUIRoots[i].CharacterUIInitialize(GameCharacterDataProvider.Instance.PlayerCharacterControllers[i].GetCharacterData);
            //キャラクターの生成
            GameCharacterDataProvider.Instance.PlayerCharacterControllers[i].CharacterInstantiate();
        }

        for (int i = 0; i < GameCharacterDataProvider.Instance.EnemyCharacterContorllers.Count(); i++)
        {
            //キャラクターを産む
            GameCharacterDataProvider.Instance.EnemyCharacterContorllers[i].CharacterInstantiate();
        }

    }

    public override void Exit()
    {
        Debug.Log("MainGameStatesGameStart Exit");
    }

    public override void Update()
    {
        Debug.Log("MainGameStatesGameStart Update");

        stateMachine.ChangeState(MainGameStateManager.Instance.MainGameStatesGameMain);
    }
}
