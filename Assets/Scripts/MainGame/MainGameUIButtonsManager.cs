using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class MainGameUIButtonsManager : MonoBehaviour
{
    /*
    public Button primaryButton;
    private TextMeshProUGUI primaryButtonNameText;

    public Button secondaryButton;
    private TextMeshProUGUI secondaryButtonText;

    public Button tertiaryButton;
    private TextMeshProUGUI tertiaryButtonNameText;
    */

    public List<Button> AbilityButttons = new List<Button>();

    public class ButtonAction
    {
        public string buttonName = string.Empty;
        public UnityAction buttonAction = null;
        public Sprite buttonSprite = null;

        public ButtonAction(string buttonName, UnityAction buttonAction, Sprite buttonSprite)
        {
            this.buttonName = buttonName;
            this.buttonAction = buttonAction;
            this.buttonSprite = buttonSprite;
        }
    }

    private void Start()
    {
        this.gameObject.SetActive(false);
    }

    public void SetButtonActions(List<ButtonAction> actions)
    {
        foreach (var abilityButton in AbilityButttons) 
        {
            abilityButton.onClick.RemoveAllListeners();
            abilityButton.gameObject.SetActive(false);
        }

        for (int i = 0; i < actions.Count; i++)
        {
            AbilityButttons[i].gameObject.SetActive(true);
            var buttonActions = actions[i].buttonAction;
            var index = i;
            AbilityButttons[i].onClick.AddListener(
                () =>
                {
                    GameCharacterDataProvider.Instance.CharacterAbilityChoiceIndex = index;
                    buttonActions.Invoke();
                    this.gameObject.SetActive(false);
                });
            var abilityBuyyonText = AbilityButttons[i].GetComponentInChildren<TextMeshProUGUI>();
            abilityBuyyonText.text = actions[i].buttonName;
            var abilityButtonImage = AbilityButttons[i].GetComponentInChildren<Image>();
            abilityButtonImage.sprite = actions[i].buttonSprite;
        }
    }
}
