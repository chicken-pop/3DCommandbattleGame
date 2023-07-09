using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterAttackState : ICharacterState
{
    private CharacterData characterData;
    private MainGameCharacterController mainGameCharacterController;
    public CharacterAttackState(MainGameCharacterController mainGameCharacterController)
    {
        this.characterData = mainGameCharacterController.GetCharacterData;
        this.mainGameCharacterController = mainGameCharacterController;
    }

    public void Enter()
    {
        Debug.Log("attack");
        mainGameCharacterController.GetGameCharacterAnimator.Play("Action0");
    }

    public void Update()
    {
        //攻撃のアニメーションが終わったら
        if (mainGameCharacterController.GetGameCharacterAnimator.GetCurrentAnimatorStateInfo(0).normalizedTime >= 1.0f)
        {
            if (characterData.CharacterType == CharacterData.CharacterTypes.SpellCaster)
            {
                mainGameCharacterController.GetCharacterStateMachine.TransitionTo(mainGameCharacterController.GetCharacterStateMachine.waitState);
            }
            else
            {
                mainGameCharacterController.GetCharacterStateMachine.TransitionTo(mainGameCharacterController.GetCharacterStateMachine.moveState);
            }
        }
    }

    public void Exit()
    {
        mainGameCharacterController.IsActionChoiced = false;
        //攻撃地点の初期化
        GameCharacterDataProvider.Instance.PointOfAttack = null;
    }
}
