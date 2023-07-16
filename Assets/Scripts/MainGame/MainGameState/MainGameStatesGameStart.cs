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
            //UI��Initialize
            GameCharacterDataProvider.Instance.CharacterUIRoots[i].CharacterUIInitialize(GameCharacterDataProvider.Instance.PlayerCharacterControllers[i].GetCharacterData);
            //�L�����N�^�[�̐���
            GameCharacterDataProvider.Instance.PlayerCharacterControllers[i].CharacterInstantiate();
        }

        for (int i = 0; i < GameCharacterDataProvider.Instance.EnemyCharacterContorllers.Count(); i++)
        {
            //�L�����N�^�[���Y��
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
