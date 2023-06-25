using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class CharacterClickHandler : MonoBehaviour, IPointerClickHandler
{
    public void OnPointerClick(PointerEventData eventData)
    {
        //�v���C���[���A�^�b�N����^�[�Q�b�g���w�肷��
        var pointOfAttack = this.transform.GetComponent<MainGameCharacterController>().PointOfAttack;
        GameCharacterDataProvider.Instance.PointOfAttack = pointOfAttack;
    }
}
