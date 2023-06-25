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

    private Animator gameCharacterAnimator;

    [SerializeField]
    private CharacterUIRoot characterUIRoot;

    public MainGameUIButtonsManager.ButtonAction primaryButtonAction;
    public MainGameUIButtonsManager.ButtonAction secondaryButtonAction;
    public MainGameUIButtonsManager.ButtonAction tertiaryButtonAction;

    public bool IsActionChoiced = false;

    private static string AnimationActionType = "ActionType";

    public Transform PointOfAttack;

    private void Start()
    {
        if (characterData != null)
        {
            gameCharacterData = ScriptableObject.CreateInstance<CharacterData>();
            gameCharacterData.Initialize(characterData);
        }
    }

    public void CharacterInstantiate()
    {
        var characterPrefab = Instantiate(gameCharacterData.CharacterPrefab, this.transform);
        gameCharacterAnimator = characterPrefab.GetComponentInChildren<Animator>();

        var CharacterClickHandler= characterPrefab.AddComponent<CharacterClickHandler>();

        primaryButtonAction = new MainGameUIButtonsManager.ButtonAction("Attack", () => SetAnimnation(0));
    }

    public void SetAnimnation(int actionType)
    {
        IsActionChoiced = true;
        StartCoroutine(SetActionAnimation(actionType));
    }

    public IEnumerator SetActionAnimation(int actionType)
    {
        gameCharacterAnimator.SetInteger(AnimationActionType, actionType);

        yield return new WaitWhile(() => gameCharacterAnimator.GetCurrentAnimatorStateInfo(0).normalizedTime <= 1.0f);

        gameCharacterAnimator.SetInteger(AnimationActionType, -1);

        yield return new WaitWhile(() => !gameCharacterAnimator.GetCurrentAnimatorStateInfo(0).IsName("Idle"));

        IsActionChoiced = false;
    }
}
