using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CharacterCustomizer;

public class AttributeTypePanelButtonController : PanelButtonController
{
    [SerializeField]
    private AttributeType _attributeType;

    [SerializeField]
    private Sprite _defaultSprite;

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
        }
        else if (this._attributeType == AttributeType.Eyes)
        {
            folderName += "Eyes/";
            leftSpriteName = AttributeSettings.CurrentSettings.GetAttributeSettingsData(AttributeType.EyeL).name;
            rightSpriteName = AttributeSettings.CurrentSettings.GetAttributeSettingsData(AttributeType.EyeR).name;
        }

        if (leftSpriteName == "" && rightSpriteName == null)
        {
            this.centerSprite_.enabled = true;
            this.leftSprite_.enabled = false;
            this.rightSprite_.enabled = false;
            this.centerSprite_.sprite = this._defaultSprite;
        }

        if (leftSpriteName != "")
        {
            this.leftSprite_.sprite = this.GetSpritesheetSprite(folderName, leftSpriteName);
        }        
        if (rightSpriteName != "")
        {
            this.rightSprite_.sprite = this.GetSpritesheetSprite(folderName, rightSpriteName);
        }        
    }

    private Sprite GetSpritesheetSprite(string folderName, string spriteName)
    {
        string[] spriteInfo = spriteName.Split("_");

        Sprite[] spritesheet = Resources.LoadAll<Sprite>(folderName + spriteInfo[0]);

        for (int i = 0; i < spritesheet.Length; i++)
        {
            if (spritesheet[i].name == spriteName)
            {
                return spritesheet[i];
            }
        }

        return null;
    }

    private void SetSingleAttributeSprite()
    {
        string folderName = "CharacterCreator/";
        string spriteName = AttributeSettings.CurrentSettings.GetAttributeSettingsData(this._attributeType).name;

        if (spriteName == "")
        {
            this.centerSprite_.sprite = this._defaultSprite;
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
