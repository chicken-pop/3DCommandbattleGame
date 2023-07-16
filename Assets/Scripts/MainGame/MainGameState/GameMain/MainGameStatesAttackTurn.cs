using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class MainGameStatesAttackTurn : MainGameStatesGameMain
{
    private bool isPlayerAttack;

    public MainGameStatesAttackTurn(MainGameStateMachine stateMachine) : base(stateMachine)
    {
    }
    private MainGameCharacterController currentMainGameCharacterController;

    public override void Enter()
    {
        currentMainGameCharacterController =
            GameCharacterDataProvider.Instance.PlayerCharacterControllers.Find(player => player.IsActionChoiced);

        if (currentMainGameCharacterController != null)
        {
            isPlayerAttack = true;
        }
        else
        {
            currentMainGameCharacterController = GameCharacterDataProvider.Instance.EnemyCharacterContorllers.Find(enemy => enemy.IsActionChoiced);
            isPlayerAttack = false;
        }

        MainGameCameraManager.Instance.SetFollowCamera(currentMainGameCharacterController.transform);
    }

    public override void Exit()
    {
        MainGameCameraManager.Instance.RevertCameraPos();
    }

    public override void Update()
    {
        base.Update();

        //アニメーションが終わったらWaitTurnに移行する
        if (!currentMainGameCharacterController.IsActionChoiced)
        {
            stateMachine.ChangeState(MainGameStateManager.Instance.MainGameStatesWaitTurn);
            MainGameCameraManager.Instance.DetouchFollowCamera();
        }
    }
}
