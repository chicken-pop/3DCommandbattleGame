using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class CharacterData : ScriptableObject
{
    [SerializeField]
    public string Name;

    [SerializeField]
    public float HitPoint;
    private float maxHitPoint;
    public float GetMaxHitPoint
    {
        get { return maxHitPoint; }
    }

    [SerializeField]
    public float MagicPoint;
    private float maxMagicPoint;
    public float GetMaxMagicPoint
    {
        get { return maxMagicPoint; }
    }

    [SerializeField]
    public float Speed;

    [SerializeField]
    public float PhysicalAttackPower;

    [SerializeField]
    public float MagicalAttackPower;

    [SerializeField]
    public enum CharacterTypes
    {
        Invalide = -1,
        Fighter,
        SpellCaster,
    }

    [SerializeField]
    public CharacterTypes CharacterType;

    [SerializeField]
    public GameObject CharacterPrefab;

    [SerializeField]
    public bool IsEnemy;

    [SerializeField]
    public List<CommandAbilityData> CommandAbilities = new List<CommandAbilityData>();

    public void Initialize(CharacterData characterData)
    {
        Name = characterData.Name;
        HitPoint = characterData.HitPoint;
        maxHitPoint = characterData.HitPoint;
        MagicPoint = characterData.MagicPoint;
        maxMagicPoint = characterData.MagicPoint;
        Speed = characterData.Speed;
        PhysicalAttackPower = characterData.PhysicalAttackPower;
        MagicalAttackPower = characterData.MagicalAttackPower;
        CharacterType = characterData.CharacterType;
        CharacterPrefab = characterData.CharacterPrefab;
        IsEnemy = characterData.IsEnemy;
        CommandAbilities = characterData.CommandAbilities;

    }
}
