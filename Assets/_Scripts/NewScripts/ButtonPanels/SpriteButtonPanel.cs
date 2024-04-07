using System;
using System.Linq;
using UnityEngine;
using CharacterCustomizer;

public class SpriteButtonPanel : ButtonPanel
{
    private Sprite[] _attributeSprites;

    private PageButtonPanel _pageButtonPanel;
    
    public override void Reveal()
    {
        base.Reveal();

        this._pageButtonPanel = GetComponentInChildren<PageButtonPanel>();

        this.Setup();
    }

    private void Setup()
    {
        this.LoadAttributeSpritesArray();
        this.SetupPageButtonPanel();
        this.UpdateButtonSprites();
    }

    private void HideSpriteButtons()
    {
        for (int i = 0; i < this.panelButtons_.Length; i++)
        {
            this.panelButtons_[i].Hide();
        }
    }

    private void LoadAttributeSpritesArray()
    {
        switch (MasterController.instance.GetCurrentAttributeType())
        {
            case AttributeType.BaseCabbage:
                this._attributeSprites = Resources.LoadAll<Sprite>("CharacterCreator/Base");
                break;
            case AttributeType.Headpiece:
                this._attributeSprites = Resources.LoadAll<Sprite>("CharacterCreator/Headpiece");
                break;
            case AttributeType.Eyebrows:
            case AttributeType.EyebrowL:
            case AttributeType.EyebrowR:
                this._attributeSprites = Resources.LoadAll<Sprite>("CharacterCreator/Eyebrows");
                break;
            case AttributeType.Eyes:
            case AttributeType.EyeL:
            case AttributeType.EyeR:
                this._attributeSprites = Resources.LoadAll<Sprite>("CharacterCreator/Eyes");
                break;
            case AttributeType.Nose:
                this._attributeSprites = Resources.LoadAll<Sprite>("CharacterCreator/Nose");
                break;
            case AttributeType.Mouth:
                this._attributeSprites = Resources.LoadAll<Sprite>("CharacterCreator/Mouth");
                break;
            case AttributeType.Acc1:
            case AttributeType.Acc2:
            case AttributeType.Acc3:
                this._attributeSprites = Resources.LoadAll<Sprite>("CharacterCreator/Accessory");
                break;
            default:
                Debug.LogError("Error: Unknown AttributeType: " + MasterController.instance.GetCurrentAttributeType());
                break;
        }
    }

    private void SetupPageButtonPanel()
    {
        int startingPageIndex = 0;
        int maxPages = 0;

        this._pageButtonPanel.Reveal();

        if (MasterController.instance.GetCurrentAttributeType() != AttributeType.Eyebrows &&
            MasterController.instance.GetCurrentAttributeType() != AttributeType.Eyes)
        {
            startingPageIndex = this.GetSingleAttributeStartingPageIndex(MasterController.instance.GetCurrentAttributeSettingsData().name);
            maxPages = Mathf.FloorToInt(this._attributeSprites.Length / this.panelButtons_.Length);
        }
        else
        {
            startingPageIndex = this.GetDoubleAttributeStartingPageIndex(MasterController.instance.GetCurrentAttributeSettingsData().name);
            maxPages = Mathf.FloorToInt((this._attributeSprites.Length / 2) / this.panelButtons_.Length);
        }

        this._pageButtonPanel.Setup(startingPageIndex, maxPages);
    }

    private int GetSingleAttributeStartingPageIndex(string spriteName)
    {
        if (spriteName == string.Empty)
        {
            return 0;
        }

        Sprite targetSprite = this._attributeSprites.First(attSprite => attSprite.name == spriteName);
        int targetIndex = Array.IndexOf(this._attributeSprites, targetSprite);

        int pageIndex = Mathf.FloorToInt(targetIndex / this.panelButtons_.Length);

        return pageIndex;
    }

    private int GetDoubleAttributeStartingPageIndex(string spriteName)
    {
        Debug.LogError("TODO: DO THIS LATER!");
        return 0;
    }

    private void UpdateButtonSprites()
    {
        this.HideSpriteButtons();

        if (MasterController.instance.GetCurrentAttributeType() != AttributeType.Eyebrows &&
            MasterController.instance.GetCurrentAttributeType() != AttributeType.Eyes)
        {
            this.UpdateSingleAttributeButtonSprites();
        }
        else
        {
            this.UpdateDoubleAttributeButtonSprites();
        }
        
    }

    private void UpdateSingleAttributeButtonSprites()
    {
        int startingSpriteIndex = this._pageButtonPanel.currentPage * this.panelButtons_.Length;

        int equippedIndex = -1;

        for (int i = 0, j = startingSpriteIndex; i < this.panelButtons_.Length; i++, j++)
        {
            if (j < this._attributeSprites.Length)
            {                
                this.panelButtons_[i].UpdateCenterSprite(this._attributeSprites[j]);

                if (this._attributeSprites[j].name == MasterController.instance.GetCurrentAttributeSettingsData().name)
                {
                    equippedIndex = i;
                }

                this.panelButtons_[i].Reveal();
            }
        }

        this.HighlightButtonAtIndex(equippedIndex);
    }

    private void UpdateDoubleAttributeButtonSprites()
    {
        int startingSpriteIndex = this._pageButtonPanel.currentPage * this.panelButtons_.Length;

        int equippedIndex = -1;

        for (int i = 0, j = startingSpriteIndex; i < (this.panelButtons_.Length - 1); i++, j++)
        {
            if (j < (this._attributeSprites.Length - 1))
            {
                this.panelButtons_[i].UpdateLeftRightSprite(this._attributeSprites[j], this._attributeSprites[j+1]);

                //TODO: This is incorrect for double attributes.  Fix it.
                /*
                if (this._attributeSprites[j].name == MasterController.instance.GetCurrentAttributeSettingsData().name)
                {
                    equippedIndex = i;
                }
                */
            }
        }

        this.HighlightButtonAtIndex(equippedIndex);
    }

    public void PageUpdated()
    {
        this.UpdateButtonSprites();
    }
}
