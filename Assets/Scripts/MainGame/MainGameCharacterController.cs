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

    private bool isDead;

    public bool GetIsDead
    {
        get { return isDead; }
    }

    private Animator gameCharacterAnimator;

    public Animator GetGameCharacterAnimator
    {
        get { return gameCharacterAnimator; }
    }

    [SerializeField]
    //private CharacterUIRoot characterUIRoot;

    public MainGameUIButtonsManager.ButtonAction primaryButtonAction;
    public MainGameUIButtonsManager.ButtonAction secondaryButtonAction;
    public MainGameUIButtonsManager.ButtonAction tertiaryButtonAction;

    public bool IsActionChoiced = false;

    private static string AnimationActionType = "ActionType";

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

        primaryButtonAction = new MainGameUIButtonsManager.ButtonAction("Attack", () => SetAnimnation(0));

        characterStateMachine.Initialize(characterStateMachine.waitState);

        characterAnimatorFunctionController = characterPrefab.GetComponent<CharacterAnimatorFunctionController>();

        if (characterAnimatorFunctionController != null)
        {
            characterAnimatorFunctionController.AttackFunction = PhysicsAttackFunction;
        }
    }

    private void Update()
    {
        characterStateMachine.Update();
    }

    public void SetAnimnation(int actionType)
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

    public IEnumerator SetActionAnimation(int actionType)
    {
        gameCharacterAnimator.SetInteger(AnimationActionType, actionType);

        yield return new WaitWhile(() => gameCharacterAnimator.GetCurrentAnimatorStateInfo(0).normalizedTime <= 1.0f);

        gameCharacterAnimator.SetInteger(AnimationActionType, -1);

        yield return new WaitWhile(() => !gameCharacterAnimator.GetCurrentAnimatorStateInfo(0).IsName("Idle"));

        IsActionChoiced = false;
    }

    private void PhysicsAttackFunction()
    {
        GameCharacterDataProvider.Instance.PointOfAttack
            .GetComponentInParent<MainGameCharacterController>()
            .Damage(gameCharacterData.PhysicalAttackPower);
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
