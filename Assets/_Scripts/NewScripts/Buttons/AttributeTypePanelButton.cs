using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CharacterCustomizer;

public class AttributeTypePanelButton : PanelButton
{
/*
    [SerializeField]
    private AttributeType _attributeType;

    public override void Reveal()
    {
        base.Reveal();

        this.UpdateEquippedAttributeSprite();
    }

    public override void SelectButton()
    {
        base.SelectButton();

        ButtonPanelManager.instance.DisplayNewPanel(1);
        CurrentCustomizerData.instance.SetCurrentAttributeType(this._attributeType);
    }

    private void UpdateEquippedAttributeSprite()
    {
        string folderName = "";
        string spriteName = "";

        if (this._attributeType == AttributeType.Eyebrows || this._attributeType == AttributeType.Eyes)
        {
            return;
        }

        spriteName = AttributeSettings.CurrentSettings.GetAttributeSettingsData(this._attributeType).name;

        bool isDoubleAttribute = false;

        switch (this._attributeType)
        {
            case AttributeType.BaseCabbage:
                folderName = "Base";
                break;
            case AttributeType.Headpiece:
                folderName = "Headpiece";
                break;
            case AttributeType.Eyebrows:
                folderName = "Eyebrows";
                isDoubleAttribute = true;
                break;
            case AttributeType.Eyes:
                folderName = "Eyes";
                isDoubleAttribute = true;
                break;
            case AttributeType.Nose:
                folderName = "Nose";
                break;
            case AttributeType.Mouth:
                folderName = "Mouth";
                break;
            case AttributeType.Acc1:
            case AttributeType.Acc2:
            case AttributeType.Acc3:
                folderName = "Accessory";
                break;
            default:
                Debug.LogError("Unknown AttributeType: " + this._attributeType);    
                break;
        }

        if (isDoubleAttribute == true)
        {
            //Do something
        }
        else if (spriteName != "")
        {
            this.centerAttributeSprite.sprite = Resources.Load<Sprite>("CharacterCreator/" + folderName + "/" + spriteName);
        }
        
    }
    */
}
