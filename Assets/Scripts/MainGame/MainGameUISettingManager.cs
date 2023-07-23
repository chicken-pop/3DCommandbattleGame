using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainGameUISettingManager : SingletonMonoBehaviour<MainGameUISettingManager>
{
    [SerializeField]
    private List<CharacterUIRoot> characterUIRoots = new List<CharacterUIRoot>();

    public List<CharacterUIRoot> GetCharacterUIRoots
    {
        get { return characterUIRoots; }
    }

    [SerializeField]
    private MainGameUIButtonsManager mainGameUIButtonsManager;

    [SerializeField]
    private MainGameCharacterController mainGameCharacterController;

    public override void Awake()
    {
        isSceneinSingleton = true;
    }

    public void SetButton(MainGameCharacterController mainGameCharacterController)
    {
        mainGameUIButtonsManager.gameObject.SetActive(true);
        mainGameUIButtonsManager.SetButtonActions(mainGameCharacterController.ButtonActions);
    }

    //�S�Ă�Character�̃p�����[�^�[UI���\���ɂ���
    public void AllInvisibleCharacterUIs()
    {
        foreach (var uiRoot in characterUIRoots)
        {
            uiRoot.gameObject.SetActive(false);
        }
    }
}
