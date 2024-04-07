using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CharacterCustomizer;

public class SpritePanelButtonController : PanelButtonController
{
    public override void Reveal()
    {
        base.Reveal();

        if (MasterController.instance.GetCurrentAttributeType() != AttributeType.Eyebrows &&
            MasterController.instance.GetCurrentAttributeType() != AttributeType.Eyes)
        {
            this.centerSprite_.enabled = true;
            this.leftSprite_.enabled = false;
            this.rightSprite_.enabled = false;
        }
        else
        {
            this.centerSprite_.enabled = false;
            this.leftSprite_.enabled = true;
            this.rightSprite_.enabled = true;
        }
    }

    protected override void ButtonClicked()
    {
        base.ButtonClicked();

        this.EquipSprite();
    }

    private void EquipSprite()
    {
        if (MasterController.instance.GetCurrentAttributeType() != AttributeType.Eyebrows &&
            MasterController.instance.GetCurrentAttributeType() != AttributeType.Eyes)
        {
            this.EquipSingleAttributeSprite();
        }
        else
        {
            this.EquipDoubleAttributeSprites();
        }
    }

    private void EquipSingleAttributeSprite()
    {
        CharacterAttribute currentAttribute = CharacterPreview.instance.GetCachedAttribute(MasterController.instance.GetCurrentAttributeType());
        currentAttribute.SetAssetName(this.centerSprite_.sprite.name);
        currentAttribute.UpdateAttributeObject();
    }

    private void EquipDoubleAttributeSprites()
    { 
        //Check if left or right or both, then set accordingly
    }
}
