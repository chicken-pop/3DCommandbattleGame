using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class CharacterAnimatorFunctionController : MonoBehaviour
{
    public UnityAction AttackFunction = null;

    public void AnimationAttackFunction()
    {
        Debug.Log("Attack");
        AttackFunction?.Invoke();
    }
}
