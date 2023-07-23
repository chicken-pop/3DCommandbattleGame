using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class CommandAbilityData : ScriptableObject
{
    [SerializeField]
    public string CommandAbilityName;
    [SerializeField]
    public string CommandAbilityDescription;
    [SerializeField]
    public Sprite CommandAbilityIcon;

    [SerializeField]
    public enum AbilityTypes
    {
        Invalide = -1, //�^�C�v�Ȃ�
        PhysicsAttack,�@//�����U��
        MagicAttack,�@//���@�U��
        Buff,�@//�o�t
        Debuff,�@//�f�o�t
    }

    [SerializeField]
    public AbilityTypes AbilityType;

    //�U���l��񕜒l
    [SerializeField]
    public float Point;

    //�t������|�C���g
    [SerializeField]
    public float SideEffectPoint;

    //���@����ɕK�v�ȃR�X�g
    [SerializeField]
    public float MagicCost;

    //�̗͏���ɕK�v�ȃR�X�g
    [SerializeField]
    public float HitPointCost;
}
