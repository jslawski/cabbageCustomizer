using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using CharacterCustomizer;

public class DoubleAttributeTypePanelButtonController : AttributeTypePanelButtonController
{
    private AttributeTypePanelButtonController[] _leftAndRightButtons;

    private void Awake()
    {
        this._leftAndRightButtons = GetComponentsInChildren<AttributeTypePanelButtonController>();
    }

    protected override void ButtonClicked()
    {
        this._leftAndRightButtons[0].gameObject.SetActive(true);
        this._leftAndRightButtons[1].gameObject.SetActive(true);

        MasterController.instance.SetCurrentAttributeType(this.attributeType_);
    }

    protected override void SetEquippedAttributeSprite()
    {
        this.centerSprite_.enabled = false;
        this.leftSprite_.enabled = true;
        this.rightSprite_.enabled = true;

        this.SetAttributeSprite();
    }

    protected override void SetAttributeSprite()
    {
        string folderName = "CharacterCreator/";
        string leftSpriteName = "";
        string rightSpriteName = "";

        if (this.attributeType_ == AttributeType.Eyebrows)
        {
            folderName += "Eyebrows/";
            leftSpriteName = AttributeSettings.CurrentSettings.GetAttributeSettingsData(AttributeType.EyebrowL).name;
            rightSpriteName = AttributeSettings.CurrentSettings.GetAttributeSettingsData(AttributeType.EyebrowR).name;
        }
        else if (this.attributeType_ == AttributeType.Eyes)
        {
            folderName += "Eyes/";
            leftSpriteName = AttributeSettings.CurrentSettings.GetAttributeSettingsData(AttributeType.EyeL).name;
            rightSpriteName = AttributeSettings.CurrentSettings.GetAttributeSettingsData(AttributeType.EyeR).name;
        }

        if (leftSpriteName != "")
        {
            this.leftSprite_.sprite = this.GetSpritesheetSprite(folderName, leftSpriteName);
        }
        if (rightSpriteName != "")
        {
            this.rightSprite_.sprite = this.GetSpritesheetSprite(folderName, rightSpriteName);
        }

        if (leftSpriteName == "" && rightSpriteName == "")
        {
            this.centerSprite_.enabled = true;
            this.leftSprite_.enabled = false;
            this.rightSprite_.enabled = false;
            this.centerSprite_.sprite = this.defaultSprite_;
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
}
