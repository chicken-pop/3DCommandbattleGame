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

    //CharacterStateMachine���쐬�����Ƃ��̃R���X�g���N�^
    public CharacterStateMachine(CharacterData characterData)
    {
        this.waitState = new CharacterWaitState(characterData);
        this.moveState = new CharacterMoveState(characterData);
        this.attackState = new CharacterAttackState(characterData);
    }

    //CharacterState���Z�b�g���ꂽ�Ƃ��ɌĂ΂��
    public void Initialize(ICharacterState state)
    {
        CurrentState = state;
        state.Enter();
        stateChange?.Invoke(state);
    }

    //�ʂ�CharacterState�ɕύX����ۂɌĂ΂��
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
