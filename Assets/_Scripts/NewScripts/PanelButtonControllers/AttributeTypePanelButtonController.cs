using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CharacterCustomizer;

public class AttributeTypePanelButtonController : PanelButtonController
{
    [SerializeField]
    protected AttributeType attributeType_;

    [SerializeField]
    protected Sprite defaultSprite_;

    public override void Reveal()
    {
        base.Reveal();

        this.SetEquippedAttributeSprite();
    }

    protected override void ButtonClicked()
    {
        base.ButtonClicked();
        
        MasterController.instance.SetCurrentAttributeType(this.attributeType_);
    }

    protected virtual void SetEquippedAttributeSprite()
    {
        this.centerSprite_.enabled = true;
        this.leftSprite_.enabled = false;
        this.rightSprite_.enabled = false;
        this.SetAttributeSprite();
    }

    protected virtual void SetAttributeSprite()
    {
        string folderName = "CharacterCreator/";
        string spriteName = AttributeSettings.CurrentSettings.GetAttributeSettingsData(this.attributeType_).name;

        if (spriteName == "")
        {
            this.centerSprite_.sprite = this.defaultSprite_;
            return;
        }

        switch (this.attributeType_)
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
                Debug.LogError("Unknown AttributeType: " + this.attributeType_);
                break;
        }
        
        this.centerSprite_.sprite = Resources.Load<Sprite>(folderName + spriteName);
    }
}
