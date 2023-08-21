using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SettingsAttributeSideWidget : SettingsWidget
{
    [SerializeField]
    private AttributeSideButton leftButton;
    [SerializeField]
    private AttributeSideButton bothButton;
    [SerializeField]
    private AttributeSideButton rightButton;    

    public override void SetupWidget()
    {        
        if (AttributeSettingsManager.currentAttribute == AttributeType.EyebrowL || AttributeSettingsManager.currentAttribute == AttributeType.EyeL ||
            AttributeSettingsManager.currentAttribute == AttributeType.EyebrowR || AttributeSettingsManager.currentAttribute == AttributeType.EyeR ||
            AttributeSettingsManager.currentAttribute == AttributeType.EyebrowB || AttributeSettingsManager.currentAttribute == AttributeType.EyeB)
        {
            this.gameObject.SetActive(true);
            this.SetupButtons();
        }        
        else
        {
            this.gameObject.SetActive(false);
        }
    }

    private void SetupButtons()
    {
        if (AttributeSettingsManager.currentAttribute == AttributeType.EyebrowL ||
            AttributeSettingsManager.currentAttribute == AttributeType.EyebrowR ||
            AttributeSettingsManager.currentAttribute == AttributeType.EyebrowB)
        {
            this.leftButton.buttonAttribute = AttributeType.EyebrowL;
            this.rightButton.buttonAttribute = AttributeType.EyebrowR;
            this.bothButton.buttonAttribute = AttributeType.EyebrowB;
        }
        else if (AttributeSettingsManager.currentAttribute == AttributeType.EyeL ||
            AttributeSettingsManager.currentAttribute == AttributeType.EyeR ||
            AttributeSettingsManager.currentAttribute == AttributeType.EyeB)
        {
            this.leftButton.buttonAttribute = AttributeType.EyeL;
            this.rightButton.buttonAttribute = AttributeType.EyeR;
            this.bothButton.buttonAttribute = AttributeType.EyeB;
        }

        this.ToggleButtons();
    }

    public void UpdateAttributeSide(AttributeType newType)
    {
        AttributeSettingsManager.currentAttribute = newType;
        SettingsPanel.instance.RefreshWidgets();        
        this.ToggleButtons();
    }

    private void ToggleButtons()
    {
        switch (AttributeSettingsManager.currentAttribute)
        {
            case AttributeType.EyebrowL:
            case AttributeType.EyeL:
                this.leftButton.buttonComponent.interactable = false;
                this.bothButton.buttonComponent.interactable = true;
                this.rightButton.buttonComponent.interactable = true;
                break;
            case AttributeType.EyebrowR:
            case AttributeType.EyeR:
                this.leftButton.buttonComponent.interactable = true;
                this.bothButton.buttonComponent.interactable = true;
                this.rightButton.buttonComponent.interactable = false;
                break;
            case AttributeType.EyebrowB:
            case AttributeType.EyeB:
                this.leftButton.buttonComponent.interactable = true;
                this.bothButton.buttonComponent.interactable = false;
                this.rightButton.buttonComponent.interactable = true;
                break;
            
            default:
                Debug.LogError("Invalid Attribute Type: " + AttributeSettingsManager.currentAttribute);
                break;
        }
    }
}
