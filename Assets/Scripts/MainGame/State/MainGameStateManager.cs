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

    public MainGameStatesPlayerWaitTurn MainGameStatesPlayerWaitTurn;
    public MainGameStatesPlayerAttackTurn MainGameStatesPlayerAttackTurn;
    public MainGameStatesPlayerChoiceTurn MainGameStatesPlayerChoiceTurn;

    public MainGameStatesGameResult MainGameStatesGameResult;

    [SerializeField] 
    private List<CharacterUIRoot> CharacterUIRoots = new List<CharacterUIRoot>();

    private void Start()
    {
        stateMachine = new MainGameStateMachine();
        MainGameStatesGameInit = new MainGameStatesGameInit(stateMachine);
        MainGameStatesGameStart = new MainGameStatesGameStart(stateMachine, CharacterUIRoots);

        MainGameStatesGameMain = new MainGameStatesGameMain(stateMachine);
        MainGameStatesPlayerWaitTurn = new MainGameStatesPlayerWaitTurn(stateMachine, CharacterUIRoots);
        MainGameStatesPlayerChoiceTurn = new MainGameStatesPlayerChoiceTurn(stateMachine);
        MainGameStatesPlayerAttackTurn = new MainGameStatesPlayerAttackTurn(stateMachine);


        MainGameStatesGameResult = new MainGameStatesGameResult(stateMachine);

        //Initからスタート
        stateMachine.ChangeState(MainGameStatesGameInit);
    }

    private void Update()
    {
        stateMachine.Update();
    }
}
