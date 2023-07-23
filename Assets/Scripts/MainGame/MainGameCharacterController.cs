using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainGameCharacterController : MonoBehaviour
{
    /// <summary>
    /// Assetè„Ç≈ÇÃCharacterData
    /// </summary>
    [SerializeField]
    private CharacterData characterData;

    /// <summary>
    /// ÉÅÉCÉìÉQÅ[ÉÄÇ≈égÇ§CharacterData
    /// </summary>
    private CharacterData gameCharacterData;

    public CharacterData GetCharacterData
    {
        get { return gameCharacterData; }
    }

    private bool isDead = false;

    public bool GetIsDead
    {
        get { return isDead; }
    }

    private Animator gameCharacterAnimator;

    public Animator GetGameCharacterAnimator
    {
        get { return gameCharacterAnimator; }
    }

    public bool IsActionChoiced = false;

    private static string AnimationActionType = "ActionType";

    public List<MainGameUIButtonsManager.ButtonAction> ButtonActions = new List<MainGameUIButtonsManager.ButtonAction>();

    public Transform PointOfAttack;

    CharacterStateMachine characterStateMachine;
    public CharacterStateMachine GetCharacterStateMachine
    {
        get { return characterStateMachine; }
    }

    private Transform characterPrefabTransform = null;
    public Transform GetCharacterPrefabTransform
    {
        get { return characterPrefabTransform; }
    }

    private CharacterAnimatorFunctionController characterAnimatorFunctionController;

    private float enemyWaitTime = 100f;

    public int SetIndexButtonAbility = 0;

    private void Start()
    {
        if (characterData != null)
        {
            gameCharacterData = ScriptableObject.CreateInstance<CharacterData>();
            gameCharacterData.Initialize(characterData);
            characterStateMachine = new CharacterStateMachine(this);
        }
    }

    public void CharacterInstantiate()
    {
        var characterPrefab = Instantiate(gameCharacterData.CharacterPrefab, this.transform);
        gameCharacterAnimator = characterPrefab.GetComponentInChildren<Animator>();

        characterPrefabTransform = characterPrefab.transform;

        var CharacterClickHandler = characterPrefab.AddComponent<CharacterClickHandler>();

        ButtonActions.Clear();

        //ìGÇ∂Ç·Ç»Ç¢èÍçáÉ{É^ÉìÇï\é¶
        if (!characterData.IsEnemy)
        {
            for (int i = 0; i < gameCharacterData.CommandAbilities.Count; i++)
            {
                ButtonActions.Add(new MainGameUIButtonsManager.ButtonAction(gameCharacterData.CommandAbilities[i].CommandAbilityName,
                    () => SetAnimnation(), 
                    gameCharacterData.CommandAbilities[i].CommandAbilityIcon));
            }
        }

        characterStateMachine.Initialize(characterStateMachine.waitState);

        characterAnimatorFunctionController = characterPrefab.GetComponent<CharacterAnimatorFunctionController>();

        if (characterAnimatorFunctionController != null)
        {
            if (characterData.CharacterType == CharacterData.CharacterTypes.SpellCaster)
            {
                characterAnimatorFunctionController.AttackFunction = MagicAttackFunction;
            }
            else
            {
                characterAnimatorFunctionController.AttackFunction = PhysicsAttackFunction;
            }
        }
    }

    private void Update()
    {
        characterStateMachine.Update();

        if (gameCharacterData.IsEnemy)
        {
            if (characterStateMachine.IsState(characterStateMachine.waitState)
                && MainGameStateManager.Instance.IsMainGameState(MainGameStateManager.Instance.MainGameStatesWaitTurn))
            {
                enemyWaitTime -= gameCharacterData.Speed * Time.deltaTime;
                if (enemyWaitTime < 0)
                {
                    IsActionChoiced = true;
                    enemyWaitTime = 100f;
                }
            }
        }
    }

    public void SetAnimnation()
    {
        IsActionChoiced = true;
        if (characterData.CharacterType == CharacterData.CharacterTypes.SpellCaster)
        {
            characterStateMachine.TransitionTo(characterStateMachine.attackState);
        }
        else
        {
            characterStateMachine.TransitionTo(characterStateMachine.moveState);
        }

        //StartCoroutine(SetActionAnimation(actionType));
    }

    //ï®óùçUåÇÇÃèÍçá
    private void PhysicsAttackFunction()
    {
        GameCharacterDataProvider.Instance.PointOfAttack
            .GetComponentInParent<MainGameCharacterController>()
            .Damage(gameCharacterData.PhysicalAttackPower);
        MainGameCameraManager.Instance.CameraShake();

        Debug.Log("damage");
    }

    //ñÇñ@çUåÇÇÃèÍçá
    private void MagicAttackFunction()
    {
        GameCharacterDataProvider.Instance.PointOfAttack
            .GetComponentInParent<MainGameCharacterController>()
            .Damage(gameCharacterData.MagicalAttackPower);

        gameCharacterData.MagicalAttackPower -= gameCharacterData.CommandAbilities[GameCharacterDataProvider.Instance.CharacterAbilityChoiceIndex].MagicCost;
        MainGameCameraManager.Instance.CameraShake();
    }

    public void Damage(float damage)
    {
        gameCharacterData.HitPoint -= damage;

        if (gameCharacterData.HitPoint < 0)
        {
            gameCharacterData.HitPoint = 0;
            isDead = true;
        }
    }
}
