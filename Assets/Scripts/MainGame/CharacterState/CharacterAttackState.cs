using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class CharacterAttackState : ICharacterState
{
    private CharacterData characterData;
    private MainGameCharacterController mainGameCharacterController;

    private bool animationStateChanged = false;

    public CharacterAttackState(MainGameCharacterController mainGameCharacterController)
    {
        this.characterData = mainGameCharacterController.GetCharacterData;
        this.mainGameCharacterController = mainGameCharacterController;
    }

    public void Enter()
    {
        Debug.Log("attack");
        if (mainGameCharacterController.GetCharacterData.CharacterType == CharacterData.CharacterTypes.SpellCaster)
        {
            if (GameCharacterDataProvider.Instance.PointOfAttack == null)
            {
                GameCharacterDataProvider.Instance.PointOfAttack 
                    = GameCharacterDataProvider.Instance.EnemyCharacterContorllers.FirstOrDefault(chara => !chara.GetIsDead).PointOfAttack;
            }
        }

        mainGameCharacterController.GetGameCharacterAnimator.Play("Action0");
    }

    public void Update()
    {

        if (animationStateChanged)
        {
            animationStateChanged = true;
            mainGameCharacterController.GetGameCharacterAnimator.Play("Action0");
            return;
        }

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
        animationStateChanged = false;
        mainGameCharacterController.IsActionChoiced = false;
        //攻撃地点の初期化
        GameCharacterDataProvider.Instance.PointOfAttack = null;
    }
}
