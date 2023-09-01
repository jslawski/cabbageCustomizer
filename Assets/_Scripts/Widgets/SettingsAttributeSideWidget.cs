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

    private bool IsDoubleAttribute()
    {        
        return (this.associatedAttribute.GetChildren().Length > 0);
    }
    
    public override void SetupWidget()
    {
        this.associatedAttribute = null;
    }

    public override void RefreshWidget(CabbageAttribute attObj)
    {
        //This is always the PARENT attribute
        this.associatedAttribute = CharacterPreview.instance.GetAttribute(attObj.attributeType);

        if (this.IsDoubleAttribute())
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
        this.bothButton.parentAttribute = this.associatedAttribute.attributeType;
        this.bothButton.buttonAttribute = this.associatedAttribute.attributeType;

        this.leftButton.parentAttribute = this.associatedAttribute.attributeType;
        this.leftButton.buttonAttribute = this.associatedAttribute.GetChildren()[0].childAttributeType;

        this.rightButton.parentAttribute = this.associatedAttribute.attributeType;
        this.rightButton.buttonAttribute = this.associatedAttribute.GetChildren()[1].childAttributeType;

        this.ToggleButtons();
    }

    public void UpdateAttributeSide(AttributeType newType)
    {
        //Reset eyebrows or eyes if the "both" button is clicked
        if (newType == AttributeType.Eyebrows || newType == AttributeType.Eyes)
        {
            CharacterPreview.instance.GetAttribute(newType).ResetAttribute();
            CharacterPreview.instance.GetAttribute(newType).UpdateAttributeObject();
        }

        SettingsPanel.instance.RefreshWidgets(newType);
    }    

    private void ToggleButtons()
    {
        this.EnableAndDisableButtons(SettingsPanel.instance.attributeSideCache[this.associatedAttribute.attributeType]);        
    }

    private void EnableAndDisableButtons(AttributeType attSide)
    {
        switch (attSide)
        {
            case AttributeType.Eyebrows:
            case AttributeType.Eyes:
                this.DisableBothButton();
                break;
            case AttributeType.EyebrowL:
            case AttributeType.EyeL:
                this.DisableLeftButton();
                break;
            case AttributeType.EyebrowR:
            case AttributeType.EyeR:
                this.DisableRightButton();
                break;
            default:
                Debug.LogError("Unknown AttributeType " + attSide);
                break;
        }
    }

    private void DisableBothButton()
    {
        this.leftButton.buttonComponent.interactable = true;
        this.bothButton.buttonComponent.interactable = false;
        this.rightButton.buttonComponent.interactable = true;
    }

    private void DisableLeftButton()
    {
        this.leftButton.buttonComponent.interactable = false;
        this.bothButton.buttonComponent.interactable = true;
        this.rightButton.buttonComponent.interactable = true;
    }

    private void DisableRightButton()
    {
        this.leftButton.buttonComponent.interactable = true;
        this.bothButton.buttonComponent.interactable = true;
        this.rightButton.buttonComponent.interactable = false;
    }
}
