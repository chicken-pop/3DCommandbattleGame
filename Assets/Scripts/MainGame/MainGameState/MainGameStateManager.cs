using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainGameStateManager : SingletonMonoBehaviour<MainGameStateManager>
{
    private MainGameStateMachine stateMachine;

    public MainGameStateMachine GetMainGameState
    {
        get { return stateMachine; }
    }

    public override void Awake()
    {
        isSceneinSingleton = true;
    }

    public MainGameStatesGameInit MainGameStatesGameInit;
    public MainGameStatesGameStart MainGameStatesGameStart;

    //Main部分
    public MainGameStatesGameMain MainGameStatesGameMain;
    public MainGameStatesWaitTurn MainGameStatesWaitTurn;
    public MainGameStatesAttackTurn MainGameStatesAttackTurn;
    public MainGameStatesChoiceTurn MainGameStatesChoiceTurn;

    public MainGameStatesGameLoseResult MainGameStatesGameLoseResult;
    public MainGameStatesGameWinResult MainGameStatesGameWinResult;

    [SerializeField]
    private MainGameRenderingManager mainGameRenderingManager;

    private void Start()
    {
        stateMachine = new MainGameStateMachine();
        MainGameStatesGameInit = new MainGameStatesGameInit(stateMachine);
        MainGameStatesGameStart = new MainGameStatesGameStart(stateMachine);

        MainGameStatesGameMain = new MainGameStatesGameMain(stateMachine);
        MainGameStatesWaitTurn = new MainGameStatesWaitTurn(stateMachine);
        MainGameStatesChoiceTurn = new MainGameStatesChoiceTurn(stateMachine);
        MainGameStatesAttackTurn = new MainGameStatesAttackTurn(stateMachine);


        MainGameStatesGameLoseResult = new MainGameStatesGameLoseResult(stateMachine, mainGameRenderingManager);
        MainGameStatesGameWinResult = new MainGameStatesGameWinResult(stateMachine, mainGameRenderingManager);

        //Initからスタート
        stateMachine.ChangeState(MainGameStatesGameInit);
    }

    public bool IsMainGameState(MainGameState mainGameState)
    {
        return mainGameState == stateMachine.GetMainGameState;
    }

    private void Update()
    {
        stateMachine.Update();
    }
}
