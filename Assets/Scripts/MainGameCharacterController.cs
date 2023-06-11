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


    private static string AnimationActionType = "ActionType";

    private void Start()
    {
        if (characterData != null)
        {
            gameCharacterData = ScriptableObject.CreateInstance<CharacterData>();

            gameCharacterData.Initialize(characterData);

            var characterPrefab = Instantiate(gameCharacterData.CharacterPrefab, this.transform);

            gameCharacterAnimator = characterPrefab.GetComponentInChildren<Animator>();
        }
    }

    public void SetAnimnation(int actionType)
    {
        StartCoroutine(SetActionAnimation(actionType));
    }

    public IEnumerator SetActionAnimation(int actionType)
    {
        gameCharacterAnimator.SetInteger(AnimationActionType, actionType);

        yield return new WaitWhile(() => gameCharacterAnimator.GetCurrentAnimatorStateInfo(0).normalizedTime <= 1.0f);

        yield return new WaitWhile(() => gameCharacterAnimator.GetCurrentAnimatorStateInfo(0).normalizedTime <= 1.0f);

        gameCharacterAnimator.SetInteger(AnimationActionType, -1);
    }
}
