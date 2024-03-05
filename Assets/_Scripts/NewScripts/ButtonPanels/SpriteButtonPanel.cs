using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using CharacterCustomizer;

public class SpriteButtonPanel : ButtonPanel
{    
    private PageButtonPanel _pageButtonPanel;

    private Sprite[] _attributeSprites;

    private float timeBetweenPageChanges = 0.6f;

    public override void DisplayPanel()
    {
        this._pageButtonPanel = GetComponentInChildren<PageButtonPanel>();    
    
        this.LoadAttributeSprites();

        this.DisplayPageButtonPanel();

        this.UpdateButtonSprites();

        StartCoroutine(this.RevealSpriteButtons());
    }

    private void DisplayPageButtonPanel()
    {
        int startingPageIndex = 0;

        if (CurrentCustomizerData.instance.IsSingleAttribute() == true)
        {
            startingPageIndex = this.GetSingleAttributePage(CurrentCustomizerData.instance.currentAttributeSettingsData.name);
        }
        else
        {
            startingPageIndex = this.GetDoubleAttributePage(CurrentCustomizerData.instance.currentAttributeSettingsData.name);
        }

        int maxPages = Mathf.FloorToInt(this._attributeSprites.Length / this.panelButtons.Length);

        this._pageButtonPanel.SetupPageButtons(startingPageIndex, maxPages);
        this._pageButtonPanel.DisplayPanel();
    }

    public override void HidePanel()
    {
        base.HidePanel();    

        this._pageButtonPanel.HidePanel();
    }

    private void TemporarilyHidePanel()
    {
        StartCoroutine(this.HideSpriteButtons());
    }

    private IEnumerator RevealSpriteButtons()
    {
        int startingSpriteIndex = this._pageButtonPanel.currentPage * this.panelButtons.Length;

        for (int i = 0, j = startingSpriteIndex; i < this.panelButtons.Length; i++, j++)
        {
            if (j < this._attributeSprites.Length)
            {
                this.panelButtons[i].Reveal();

                yield return new WaitForSeconds(this.updatePanelSpeed_);
            }
        }

        this.RevealButtonsCallback();
    }

    protected override void RevealButtonsCallback()
    {
        int startingSpriteIndex = this._pageButtonPanel.previousPage * this.panelButtons.Length;

        for (int i = 0, j = startingSpriteIndex; i < this.panelButtons.Length; i++, j++)
        {
            if (j < this._attributeSprites.Length)
            {
                this.panelButtons[i].EnableButton();
            }
        }
    }

    private IEnumerator HideSpriteButtons()
    {
        int startingSpriteIndex = this._pageButtonPanel.previousPage * this.panelButtons.Length;

        for (int i = 0, j = startingSpriteIndex; i < this.panelButtons.Length; i++, j++)
        {
            if (j < this._attributeSprites.Length)
            {
                this.panelButtons[i].Hide();

                yield return new WaitForSeconds(this.updatePanelSpeed_);
            }
        }
    }

    private void LoadAttributeSprites()
    {
        switch (CurrentCustomizerData.instance.currentAttributeType)
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
                Debug.LogError("Error: Unknown AttributeType: " + CurrentCustomizerData.instance.currentAttributeType);
                break;
        }        
    }

    private int GetSingleAttributePage(string spriteName)
    {
        if (spriteName == string.Empty)
        {
            return 0;
        }
    
        Sprite targetSprite = this._attributeSprites.First(attSprite => attSprite.name == spriteName);
        int targetIndex = Array.IndexOf(this._attributeSprites, targetSprite);

        int pageIndex = Mathf.FloorToInt(targetIndex / this.panelButtons.Length);

        return pageIndex;
    }

    private int GetDoubleAttributePage(string spriteName)
    {
        return 0;
    }

    private void UpdateSingleAttributeButtonSprites()
    {
        int startingSpriteIndex = this._pageButtonPanel.currentPage * this.panelButtons.Length;

        int equippedIndex = -1;

        for (int i = 0, j = startingSpriteIndex; i < this.panelButtons.Length; i++, j++)
        {
            if (j < this._attributeSprites.Length)
            {
                this.panelButtons[i].panelButtonHelper.centerAttributeSprite.sprite = this._attributeSprites[j];

                if (this._attributeSprites[j].name == CurrentCustomizerData.instance.currentAttributeSettingsData.name)
                {
                    equippedIndex = i;
                }
            }
        }

        this.HighlightButtonAtIndex(equippedIndex);
    }

    private void UpdateDoubleAttributeButtonSprites()
    {

    }

    private void UpdateButtonSprites()
    {
        if (CurrentCustomizerData.instance.IsSingleAttribute() == true)
        {
            this.UpdateSingleAttributeButtonSprites();
        }
        else
        {
            this.UpdateDoubleAttributeButtonSprites();
        }
    }

    public void UpdateSpriteButtons(bool nextPressed)
    {
        if (nextPressed == true)
        {
            this.buttonDisplayOrigin = DisplayOrigin.UpperRight;
        }
        else
        {
            this.buttonDisplayOrigin = DisplayOrigin.UpperLeft;
        }

        this.ReorderButtons();

        StartCoroutine(this.UpdateSpriteButtonsCoroutine());
    }

    private IEnumerator UpdateSpriteButtonsCoroutine()
    {
        //Hide
        StartCoroutine(this.HideSpriteButtons());

        yield return new WaitForSeconds(this.timeBetweenPageChanges);

        this.UpdateButtonSprites();

        //Reveal
        StartCoroutine(this.RevealSpriteButtons());
    }
}
