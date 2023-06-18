using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class MainGameStatesPlayerWaitTurn : MainGameStatesGameMain
{
    private List<CharacterUIRoot> characterUIRoots;
    public MainGameStatesPlayerWaitTurn(MainGameStateMachine stateMachine, List<CharacterUIRoot> characterUIRoots) : base(stateMachine)
    {
        this.characterUIRoots = characterUIRoots;
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

        //�ǂꂩ��ł��Q�[�W���t���ł����
        if(characterUIRoots.Any(uiRoot => uiRoot.IsGaugeFull))
        {
            //�����Q�[�W���t���ɂȂ�����I������^�[���Ɉڍs����
            stateMachine.ChangeState(MainGameStateManager.Instance.MainGameStatesPlayerChoiceTurn);
        }
    }
}
