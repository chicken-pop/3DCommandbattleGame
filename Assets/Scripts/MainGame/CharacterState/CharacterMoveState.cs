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
        if (pointOfAttack == null)
        {
            var enemy = GameCharacterDataProvider.Instance.EnemyCharacterContorllers.FirstOrDefault();
            pointOfAttack = enemy.PointOfAttack;
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
            //1ëOêiÇ∑ÇÈÇ∆Ç´
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
            Debug.Log("a");
            //å„ëﬁÇ∑ÇÈÇ∆Ç´
            mainGameCharacterController.GetCharacterPrefabTransform.position =
                Vector3.Lerp(mainGameCharacterController.GetCharacterPrefabTransform.position,
                mainGameCharacterController.transform.position, Time.deltaTime);

            if ((mainGameCharacterController.GetCharacterPrefabTransform.position - mainGameCharacterController.transform.position).magnitude < nearDistance)
            {
                mainGameCharacterController.GetCharacterStateMachine.TransitionTo(mainGameCharacterController.GetCharacterStateMachine.waitState);
            }
        }
    }

    public void Exit()
    {
    }
}
