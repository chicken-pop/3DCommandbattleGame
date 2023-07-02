using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CharacterUIRoot : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI nameText;

    [SerializeField]
    private TextMeshProUGUI hitPointText;

    [SerializeField]
    private TextMeshProUGUI magicPointText;

    [SerializeField]
    private Image hitPointGauge;

    [SerializeField]
    private Image magicPointGauge;

    [SerializeField]
    private Image waitGauge;

    private CharacterData characterUIData;

    public CharacterData GetCharacterUIData
    {
        get { return characterUIData; }
    }

    private float waitGaugeLimit = 100f;

    private float waitSpeed = 0f;

    private float waitUISpeed = 0f;

    [SerializeField]
    private MainGameUIButtonsManager mainGameUIButtonsManager;

    public bool IsGaugeFull = false;

    public void CharacterUIInitialize(CharacterData characterData)
    {
        characterUIData = characterData;
        nameText.text = characterUIData.Name;

        hitPointText.text = $"{characterUIData.HitPoint}/{characterUIData.GetMaxHitPoint}";
        magicPointText.text = $"{characterUIData.MagicPoint}/{characterUIData.GetMaxMagicPoint}";

        waitSpeed = characterData.Speed;
        waitGauge.fillAmount = 0f;
    }

    private void Update()
    {
        if (characterUIData == null)
        {
            return;
        }

        if (waitGauge.fillAmount >= 1 && !IsGaugeFull)
        {
            IsGaugeFull = true;
            waitUISpeed = 0f;
            return;
        }

        hitPointText.text = $"{characterUIData.HitPoint}/{characterUIData.GetMaxHitPoint}";
        magicPointText.text = $"{characterUIData.MagicPoint}/{characterUIData.GetMaxMagicPoint}";

        //waitのターンの場合、ゲージを進める
        if (MainGameStateManager.Instance.GetMainGameState.IsState(MainGameStateManager.Instance.MainGameStatesWaitTurn))
        {
            IsGaugeFull = false;
            waitUISpeed += waitSpeed * Time.deltaTime;
            waitGauge.fillAmount = waitUISpeed / waitGaugeLimit;
        }
    }

}
