using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterDeadState : ICharacterState
{
    private MainGameCharacterController mainGameCharacterController;

    public CharacterDeadState(MainGameCharacterController _mainGameCharacterControlle)
    {
        this.mainGameCharacterController = _mainGameCharacterControlle;
    }
    public void Enter()
    {
        Debug.Log("Dead");
        mainGameCharacterController.GetGameCharacterAnimator.Play("Dead");

    }

}
