using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class MainGameUIButtonsManager : MonoBehaviour
{
    public Button primaryButton;
    private TextMeshProUGUI primaryButtonNameText;

    public Button secondaryButton;
    private TextMeshProUGUI secondaryButtonText;

    public Button tertiaryButton;
    private TextMeshProUGUI tertiaryButtonNameText;

    public class ButtonAction
    {
        public string buttonName = string.Empty;
        public UnityAction buttonAction = null;

        public ButtonAction(string buttonName, UnityAction buttonAction)
        {
            this.buttonName = buttonName;
            this.buttonAction = buttonAction;
        }
    }

    private void Start()
    {
        primaryButtonNameText = primaryButton.GetComponentInChildren<TextMeshProUGUI>();
        secondaryButtonText = secondaryButton.GetComponentInChildren<TextMeshProUGUI>();
        tertiaryButtonNameText=tertiaryButton.GetComponentInChildren<TextMeshProUGUI>();

        this.gameObject.SetActive(false);

    }

    public void SetButtonActions(ButtonAction primaryAction, ButtonAction secondaryAction=null,ButtonAction tertiaryAction = null)
    {
        primaryButton.onClick.RemoveAllListeners();
        secondaryButton.onClick.RemoveAllListeners();
        tertiaryButton.onClick.RemoveAllListeners();
        secondaryButton.gameObject.SetActive(false);
        tertiaryButton.gameObject.SetActive(false);

        if (primaryAction != null)
        {
            primaryButtonNameText.text = primaryAction.buttonName;
            primaryButton.onClick.AddListener(() =>
            {
                primaryAction.buttonAction.Invoke();
                this.gameObject.SetActive(false);
            });
        }

        if (secondaryAction != null)
        {
            secondaryButton.gameObject.SetActive(true);
            secondaryButtonText.text = secondaryAction.buttonName;
            secondaryButton.onClick.AddListener(() =>
            {
                secondaryAction.buttonAction.Invoke();
                this.gameObject.SetActive(false);
            });
        }

        if (tertiaryAction != null)
        {
            tertiaryButton.gameObject.SetActive(true);
            tertiaryButtonNameText.text = tertiaryAction.buttonName;
            tertiaryButton.onClick.AddListener(() =>
            {
                tertiaryAction.buttonAction.Invoke();
                this.gameObject.SetActive(false);
            });
        }
    }
}
