using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class CharacterMoveState : ICharacterState
{
    CharacterData characterData;

    private Transform pointOfAttack;

    private bool forward = true;

    private MainGameCharacterController mainGameCharacterController;

    public CharacterMoveState(MainGameCharacterController mainGameCharacterController)
    {
        this.characterData = mainGameCharacterController.GetCharacterData;
        this.mainGameCharacterController = mainGameCharacterController;
    }

    private float nearDistance = 0.2f;

    public void Enter()
    {
        this.pointOfAttack = GameCharacterDataProvider.Instance.PointOfAttack;

        //敵だった場合
        if (characterData.IsEnemy && mainGameCharacterController.IsActionChoiced)
        {
            pointOfAttack = GameCharacterDataProvider.Instance.PlayerCharacterControllers.FirstOrDefault(chara => !chara.GetIsDead).PointOfAttack;
            //攻撃目標を決める
            GameCharacterDataProvider.Instance.PointOfAttack = pointOfAttack;
        }

        //プレイヤーのアタックターゲットが無い場合
        if (!characterData.IsEnemy && pointOfAttack == null)
        {
            var enemy = GameCharacterDataProvider.Instance.EnemyCharacterContorllers.FirstOrDefault(chara=> !chara.GetIsDead).PointOfAttack;
            GameCharacterDataProvider.Instance.PointOfAttack = pointOfAttack;
        }

        if (mainGameCharacterController.IsActionChoiced)
        {
            mainGameCharacterController.GetGameCharacterAnimator.Play("Run");
        }
        else
        {
            mainGameCharacterController.GetGameCharacterAnimator.Play("BackRun");
        }
    }

    public void Update()
    {
        if (mainGameCharacterController.IsActionChoiced)
        {
            //1前進するとき
            mainGameCharacterController.GetCharacterPrefabTransform.position =
                Vector3.Lerp(mainGameCharacterController.GetCharacterPrefabTransform.position,
                pointOfAttack.position, Time.deltaTime);

            if ((mainGameCharacterController.GetCharacterPrefabTransform.position - pointOfAttack.position).magnitude < nearDistance)
            {
                mainGameCharacterController.GetCharacterStateMachine.TransitionTo(mainGameCharacterController.GetCharacterStateMachine.attackState);
            }
        }
        else
        {
            //後退するとき
            mainGameCharacterController.GetCharacterPrefabTransform.position =
                Vector3.Lerp(mainGameCharacterController.GetCharacterPrefabTransform.position,
                mainGameCharacterController.transform.position, Time.deltaTime * 3);

            if ((mainGameCharacterController.GetCharacterPrefabTransform.position - mainGameCharacterController.transform.position).magnitude < nearDistance)
            {
                mainGameCharacterController.GetCharacterStateMachine.TransitionTo(mainGameCharacterController.GetCharacterStateMachine.waitState);
            }
        }
    }

    public void Exit()
    {
        pointOfAttack = null;
    }
}
