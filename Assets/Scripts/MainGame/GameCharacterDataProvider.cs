using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameCharacterDataProvider : SingletonMonoBehaviour<GameCharacterDataProvider>
{
    public List<MainGameCharacterController> PlayerCharacterControllers = new List<MainGameCharacterController>();
    public List<MainGameCharacterController> EnemyCharacterContorllers = new List<MainGameCharacterController>();
    public List<CharacterUIRoot> CharacterUIRoots = new List<CharacterUIRoot>(); 

    public Transform PointOfAttack = null;

    public int CharacterAbilityChoiceIndex = 0;

    public override void Awake()
    {
        isSceneinSingleton = true;
    }

    public void SetCharacterUIRoots()
    {
        foreach (var characterUIRoot in CharacterUIRoots)
        {
            characterUIRoot.gameObject.SetActive(false);
        }

        for (int i = 0; i < PlayerCharacterControllers.Count; i++)
        {
            CharacterUIRoots[i].gameObject.SetActive(true);
        }
    }
}
