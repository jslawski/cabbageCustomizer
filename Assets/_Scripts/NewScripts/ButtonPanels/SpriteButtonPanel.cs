using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CharacterCustomizer;

public class SpriteButtonPanel : ButtonPanel
{
    [SerializeField]
    private ButtonPanel _pageButtonPanel;

    private int totalPages = 1;

    private Sprite[] _attributeSprites;

    public override void DisplayPanel()
    {
        this.LoadAttributeSprites();

        base.DisplayPanel();

        this._pageButtonPanel.DisplayPanel();
    }

    public override void HidePanel()
    {
        base.HidePanel();

        this._pageButtonPanel.HidePanel();
    }

    private void LoadAttributeSprites()
    {
        switch (CurrentCustomizerData.currentAttributeType)
        {
            case AttributeType.BaseCabbage:
                this._attributeSprites = Resources.LoadAll<Sprite>("CharacterCreator/Base");
                this.UpdateSingleAttributeButtonImages();
                break;
            case AttributeType.Headpiece:
                this._attributeSprites = Resources.LoadAll<Sprite>("CharacterCreator/Headpiece");
                this.UpdateSingleAttributeButtonImages();
                break;
            case AttributeType.Eyebrows:
            case AttributeType.EyebrowL:
            case AttributeType.EyebrowR:
                this._attributeSprites = Resources.LoadAll<Sprite>("CharacterCreator/Eyebrows");
                this.UpdateDoubleAttributeButtonImages();
                break;
            case AttributeType.Eyes:
            case AttributeType.EyeL:
            case AttributeType.EyeR:
                this._attributeSprites = Resources.LoadAll<Sprite>("CharacterCreator/Eyes");
                this.UpdateDoubleAttributeButtonImages();
                break;
            case AttributeType.Nose:
                this._attributeSprites = Resources.LoadAll<Sprite>("CharacterCreator/Nose");
                this.UpdateSingleAttributeButtonImages();
                break;
            case AttributeType.Mouth:
                this._attributeSprites = Resources.LoadAll<Sprite>("CharacterCreator/Mouth");
                this.UpdateSingleAttributeButtonImages();
                break;
            case AttributeType.Acc1:
            case AttributeType.Acc2:
            case AttributeType.Acc3:
                this._attributeSprites = Resources.LoadAll<Sprite>("CharacterCreator/Accessory");
                this.UpdateSingleAttributeButtonImages();
                break;
            default:
                Debug.LogError("Error: Unknown AttributeType: " + CurrentCustomizerData.currentAttributeType);
                break;
        }
    }

    private int GetSingleAttributePage(string spriteName)
    {
        Sprite targetSprite = this._attributeSprites.First(attSprite => attSprite.name == spriteName);
        int targetIndex = Array.IndexOf(this._attributeSprites, targetSprite);

        int pageIndex = Mathf.FloorToInt(targetIndex / this._panelButtons.Length);

        return pageIndex;
    }

    private void UpdateSingleAttributeButtonImages()
    {
        int startingPageIndex = this.GetSingleAttributePage("00");

        int startingSpriteIndex = startingPageIndex * this._panelButtons.Length;

        for (int i = 0, j = startingSpriteIndex; i < this._panelButtons.Length; i++, j++)
        {
            if (j < this._attributeSprites.Length)
            {
                this._panelButtons[i].panelButtonHelper.centerAttributeSprite.sprite = this._attributeSprites[j];
            }            
        }
    }

    private void UpdateDoubleAttributeButtonImages()
    {

    }

    public void PrevPagePressed()
    {

    }

    public void NextPagePressed()
    {

    }

}
