using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class CharacterClickHandler : MonoBehaviour, IPointerClickHandler
{
    public void OnPointerClick(PointerEventData eventData)
    {
        //プレイヤーがアタックするターゲットを指定する
        var pointOfAttack = this.transform.GetComponent<MainGameCharacterController>().PointOfAttack;
        GameCharacterDataProvider.Instance.PointOfAttack = pointOfAttack;
    }
}
