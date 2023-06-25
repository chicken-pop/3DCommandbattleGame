using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameCharacterDataProvider : SingletonMonoBehaviour<GameCharacterDataProvider>
{
    public List<MainGameCharacterController> PlayerCharacterControllers = new List<MainGameCharacterController>();
    public List<MainGameCharacterController> EnemyCharacterContorllers=new List<MainGameCharacterController>();

    public Transform PointOfAttack = null;

    public override void Awake()
    {
        isSceneinSingleton = true;
    }
}
