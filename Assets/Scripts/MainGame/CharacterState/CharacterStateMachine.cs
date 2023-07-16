using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterStateMachine
{
    public ICharacterState CurrentState { get; private set; }

    public CharacterWaitState waitState;
    public CharacterMoveState moveState;
    public CharacterAttackState attackState;
    public CharacterDeadState deadState;

    public event Action<ICharacterState> stateChange;

    //CharacterStateMachineを作成したときのコンストラクタ
    public CharacterStateMachine(MainGameCharacterController mainGameCharacterController)
    {
        this.waitState = new CharacterWaitState(mainGameCharacterController);
        this.moveState = new CharacterMoveState(mainGameCharacterController);
        this.attackState = new CharacterAttackState(mainGameCharacterController);
        this.deadState = new CharacterDeadState(mainGameCharacterController);
    }

    //CharacterStateがセットされたときに呼ばれる
    public void Initialize(ICharacterState state)
    {
        CurrentState = state;
        state.Enter();

        stateChange?.Invoke(state);
    }

    public bool IsState(ICharacterState state)
    {
        return CurrentState == state;
    }

    //別のCharacterStateに変更する際に呼ばれる
    public void TransitionTo(ICharacterState nextState)
    {
        CurrentState.Exit();
        CurrentState = nextState;
        nextState.Enter();

        stateChange?.Invoke(nextState);
    }

    public void Update()
    {
        if (CurrentState != null)
        {
            CurrentState.Update();
        }
    }
}
