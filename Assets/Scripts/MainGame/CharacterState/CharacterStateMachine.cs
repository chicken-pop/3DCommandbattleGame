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

    public event Action<ICharacterState> stateChange;

    //CharacterStateMachineを作成したときのコンストラクタ
    public CharacterStateMachine(CharacterData characterData)
    {
        this.waitState = new CharacterWaitState(characterData);
        this.moveState = new CharacterMoveState(characterData);
        this.attackState = new CharacterAttackState(characterData);
    }

    //CharacterStateがセットされたときに呼ばれる
    public void Initialize(ICharacterState state)
    {
        CurrentState = state;
        state.Enter();
        stateChange?.Invoke(state);
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
