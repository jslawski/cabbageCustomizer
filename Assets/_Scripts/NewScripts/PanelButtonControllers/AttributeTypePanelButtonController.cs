using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CharacterCustomizer;

public class AttributeTypePanelButtonController : PanelButtonController
{
    [SerializeField]
    private AttributeType _attributeType;

    public override void Reveal()
    {
        base.Reveal();

        this.SetEquippedAttributeSprite();
    }

    protected override void ButtonClicked()
    {
        base.ButtonClicked();

        Debug.LogError("Current Attribute: " + this._attributeType);
        
        CurrentCustomizerData.instance.SetCurrentAttributeType(this._attributeType);
    }

    private void SetEquippedAttributeSprite()
    {
        if (this._attributeType == AttributeType.Eyebrows || this._attributeType == AttributeType.Eyes)
        {
            this.centerSprite_.enabled = false;
            this.leftSprite_.enabled = true;
            this.rightSprite_.enabled = true;
            this.SetDoubleAttributeSprites();
        }
        else
        {
            this.centerSprite_.enabled = true;
            this.leftSprite_.enabled = false;
            this.rightSprite_.enabled = false;
            this.SetSingleAttributeSprite();
        }
    }

    private void SetDoubleAttributeSprites()
    {
        string folderName = "CharacterCreator/";
        string leftSpriteName = "";
        string rightSpriteName = "";

        if (this._attributeType == AttributeType.Eyebrows)
        {
            folderName += "Eyebrows/";
            leftSpriteName = AttributeSettings.CurrentSettings.GetAttributeSettingsData(AttributeType.EyebrowL).name;
            rightSpriteName = AttributeSettings.CurrentSettings.GetAttributeSettingsData(AttributeType.EyebrowR).name;
            Debug.LogError("Left Eyebrow Sprite Name: " + leftSpriteName);
            Debug.LogError("Right Eyebrow Sprite Name: " + rightSpriteName);
        }
        else if (this._attributeType == AttributeType.Eyes)
        {
            folderName += "Eyes/";
            leftSpriteName = AttributeSettings.CurrentSettings.GetAttributeSettingsData(AttributeType.EyeL).name;
            rightSpriteName = AttributeSettings.CurrentSettings.GetAttributeSettingsData(AttributeType.EyeR).name;
            Debug.LogError("Left Eye Sprite Name: " + leftSpriteName);
            Debug.LogError("Right Eye Sprite Name: " + rightSpriteName);
        }

        if (leftSpriteName != "")
        {
            Debug.LogError("Left Directory: " + folderName + leftSpriteName);
            this.leftSprite_.sprite = Resources.Load<Sprite>(folderName + leftSpriteName);
        }
        if (rightSpriteName != "")
        {
            Debug.LogError("Right Directory: " + folderName + rightSpriteName);
            this.rightSprite_.sprite = Resources.Load<Sprite>(folderName + rightSpriteName);
        }
    }

    private void SetSingleAttributeSprite()
    {
        string folderName = "CharacterCreator/";
        string spriteName = AttributeSettings.CurrentSettings.GetAttributeSettingsData(this._attributeType).name;

        Debug.LogError(this._attributeType.ToString() + " Sprite Name: " + spriteName);

        if (spriteName == "")
        {
            return;
        }

        switch (this._attributeType)
        {
            case AttributeType.BaseCabbage:
                folderName += "Base/";
                break;
            case AttributeType.Headpiece:
                folderName += "Headpiece/";
                break;
            case AttributeType.Nose:
                folderName += "Nose/";
                break;
            case AttributeType.Mouth:
                folderName += "Mouth/";
                break;
            case AttributeType.Acc1:
            case AttributeType.Acc2:
            case AttributeType.Acc3:
                folderName += "Accessory/";
                break;
            default:
                Debug.LogError("Unknown AttributeType: " + this._attributeType);
                break;
        }
        
        this.centerSprite_.sprite = Resources.Load<Sprite>(folderName + spriteName);
    }
}
