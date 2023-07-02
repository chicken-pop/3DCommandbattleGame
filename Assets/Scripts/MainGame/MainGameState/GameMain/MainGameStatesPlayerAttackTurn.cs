using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class MainGameStatesPlayerAttackTurn : MainGameStatesGameMain
{
    public MainGameStatesPlayerAttackTurn(MainGameStateMachine stateMachine) : base(stateMachine)
    {
    }
    private MainGameCharacterController currentMainGameCharacterController;

    public override void Enter()
    {
        currentMainGameCharacterController = 
            GameCharacterDataProvider.Instance.PlayerCharacterControllers.Find(player => player.IsActionChoiced);

        MainGameCameraManager.Instance.SetFollowCamera(currentMainGameCharacterController.transform);
    }

    public override void Exit()
    {
        MainGameCameraManager.Instance.RevertCameraPos();
    }

    public override void Update()
    {
        base.Update();

        //�A�j���[�V�������I�������WaitTurn�Ɉڍs����
        if(GameCharacterDataProvider.Instance.PlayerCharacterControllers.All(player => !player.IsActionChoiced))
        {
            stateMachine.ChangeState(MainGameStateManager.Instance.MainGameStatesPlayerWaitTurn);
            MainGameCameraManager.Instance.DetouchFollowCamera();
        }
    }
}
