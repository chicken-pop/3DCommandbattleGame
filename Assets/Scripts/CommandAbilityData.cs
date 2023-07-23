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
        Invalide = -1, //タイプなし
        PhysicsAttack,　//物理攻撃
        MagicAttack,　//魔法攻撃
        Buff,　//バフ
        Debuff,　//デバフ
    }

    [SerializeField]
    public AbilityTypes AbilityType;

    //攻撃値や回復値
    [SerializeField]
    public float Point;

    //付随するポイント
    [SerializeField]
    public float SideEffectPoint;

    //魔法消費に必要なコスト
    [SerializeField]
    public float MagicCost;

    //体力消費に必要なコスト
    [SerializeField]
    public float HitPointCost;
}
