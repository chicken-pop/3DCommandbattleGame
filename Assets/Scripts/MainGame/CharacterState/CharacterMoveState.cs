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

        //�G�������ꍇ
        if (characterData.IsEnemy && mainGameCharacterController.IsActionChoiced)
        {
            pointOfAttack = GameCharacterDataProvider.Instance.PlayerCharacterControllers.FirstOrDefault(chara => !chara.GetIsDead).PointOfAttack;
            //�U���ڕW�����߂�
            GameCharacterDataProvider.Instance.PointOfAttack = pointOfAttack;
        }

        //�v���C���[�̃A�^�b�N�^�[�Q�b�g�������ꍇ
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
            //1�O�i����Ƃ�
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
            //��ނ���Ƃ�
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
