using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainGameStatesGameStart : MainGameState
{

    private List<CharacterUIRoot> characterUIRoots = new List<CharacterUIRoot>();
    public MainGameStatesGameStart(MainGameStateMachine stateMachine, List<CharacterUIRoot> characterUIRoots) : base(stateMachine)
    {
        this.characterUIRoots = characterUIRoots;
    }

    public override void Enter()
    {
        Debug.Log("MainGameStatesGameStart Enter");
    }

    public override void Exit()
    {
        Debug.Log("MainGameStatesGameStart Exit");
    }

    public override void Update()
    {
        Debug.Log("MainGameStatesGameStart Update");

        stateMachine.ChangeState(new MainGameStatesGameMain(stateMachine));
    }
}
