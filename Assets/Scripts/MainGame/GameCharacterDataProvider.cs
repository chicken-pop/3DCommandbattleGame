using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameCharacterDataProvider : SingletonMonoBehaviour<GameCharacterDataProvider>
{
    public List<MainGameCharacterController> PlayerCharacterControllers = new List<MainGameCharacterController>();

    public override void Awake()
    {
        isSceneinSingleton = true;
    }
}
