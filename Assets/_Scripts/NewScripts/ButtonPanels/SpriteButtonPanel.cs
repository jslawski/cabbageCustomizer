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

    private Sprite[] _attributeSprites;

    private int _currentPage = 0;
    private int _maxPages = 1;

    private float timeBetweenPageChanges = 0.6f;

    public override void DisplayPanel()
    {
        this.LoadAttributeSprites();

        this._maxPages = Mathf.FloorToInt(this._attributeSprites.Length / this.panelButtons.Length);

        base.DisplayPanel();

        this._pageButtonPanel.DisplayPanel();
    }

    public override void HidePanel()
    {
        base.HidePanel();

        this._pageButtonPanel.HidePanel();
    }

    private void DisplaySpriteButtonPanel()
    {
        base.DisplayPanel();
    }

    private void HideSpriteButtonPanel()
    {
        base.HidePanel();
    }

    private void LoadAttributeSprites()
    {
        switch (CurrentCustomizerData.instance.currentAttributeType)
        {
            case AttributeType.BaseCabbage:
                this._attributeSprites = Resources.LoadAll<Sprite>("CharacterCreator/Base");
                this.DisplayInitialSingleAttributeButtonImages();
                break;
            case AttributeType.Headpiece:
                this._attributeSprites = Resources.LoadAll<Sprite>("CharacterCreator/Headpiece");
                this.DisplayInitialSingleAttributeButtonImages();
                break;
            case AttributeType.Eyebrows:
            case AttributeType.EyebrowL:
            case AttributeType.EyebrowR:
                this._attributeSprites = Resources.LoadAll<Sprite>("CharacterCreator/Eyebrows");
                this.DisplayInitialDoubleAttributeButtonImages();
                break;
            case AttributeType.Eyes:
            case AttributeType.EyeL:
            case AttributeType.EyeR:
                this._attributeSprites = Resources.LoadAll<Sprite>("CharacterCreator/Eyes");
                this.DisplayInitialDoubleAttributeButtonImages();
                break;
            case AttributeType.Nose:
                this._attributeSprites = Resources.LoadAll<Sprite>("CharacterCreator/Nose");
                this.DisplayInitialSingleAttributeButtonImages();
                break;
            case AttributeType.Mouth:
                this._attributeSprites = Resources.LoadAll<Sprite>("CharacterCreator/Mouth");
                this.DisplayInitialSingleAttributeButtonImages();
                break;
            case AttributeType.Acc1:
            case AttributeType.Acc2:
            case AttributeType.Acc3:
                this._attributeSprites = Resources.LoadAll<Sprite>("CharacterCreator/Accessory");
                this.DisplayInitialSingleAttributeButtonImages();
                break;
            default:
                Debug.LogError("Error: Unknown AttributeType: " + CurrentCustomizerData.instance.currentAttributeType);
                break;
        }        

        this.UpdatePageButtons();
    }

    private int GetSingleAttributePage(string spriteName)
    {
        Sprite targetSprite = this._attributeSprites.First(attSprite => attSprite.name == spriteName);
        int targetIndex = Array.IndexOf(this._attributeSprites, targetSprite);

        int pageIndex = Mathf.FloorToInt(targetIndex / this.panelButtons.Length);

        return pageIndex;
    }

    private int GetDoubleAttributePage(string spriteName)
    {
        return 0;
    }

    private void DisplayInitialSingleAttributeButtonImages()
    {
        this._currentPage = this.GetSingleAttributePage("00");

        this.LoadButtonSprites();
    }

    private void DisplayInitialDoubleAttributeButtonImages()
    {

    }

    private void UpdatePageButtons()
    {
        if (CurrentCustomizerData.instance.IsSingleAttribute() == true)
        {
            this._currentPage = this.GetSingleAttributePage("00");
        }
        else
        {
            this._currentPage = this.GetDoubleAttributePage("00");
        }
        
        if (this._currentPage <= 0)
        {
            this._pageButtonPanel.panelButtons[0].panelButtonHelper.buttonBackground.color = new Color(1.0f, 1.0f, 1.0f, 0.5f);
            this._pageButtonPanel.panelButtons[0].panelButtonHelper.centerAttributeSprite.color = new Color(1.0f, 1.0f, 1.0f, 0.5f);
            this._pageButtonPanel.panelButtons[0].interactable = false;
        }
        else if (this._currentPage >= this._maxPages)
        {
            this._pageButtonPanel.panelButtons[1].panelButtonHelper.buttonBackground.color = new Color(1.0f, 1.0f, 1.0f, 0.5f);
            this._pageButtonPanel.panelButtons[1].panelButtonHelper.centerAttributeSprite.color = new Color(1.0f, 1.0f, 1.0f, 0.5f);
            this._pageButtonPanel.panelButtons[1].interactable = false;
        }
        else
        {
            this._pageButtonPanel.panelButtons[0].panelButtonHelper.buttonBackground.color = new Color(1.0f, 1.0f, 1.0f, 1.0f);
            this._pageButtonPanel.panelButtons[0].panelButtonHelper.centerAttributeSprite.color = new Color(1.0f, 1.0f, 1.0f, 1.0f);
            this._pageButtonPanel.panelButtons[0].interactable = true;
            this._pageButtonPanel.panelButtons[1].panelButtonHelper.buttonBackground.color = new Color(1.0f, 1.0f, 1.0f, 1.0f);
            this._pageButtonPanel.panelButtons[1].panelButtonHelper.centerAttributeSprite.color = new Color(1.0f, 1.0f, 1.0f, 1.0f);
            this._pageButtonPanel.panelButtons[1].interactable = true;
        }
    }

    private void LoadButtonSprites()
    {
        int startingSpriteIndex = this._currentPage * this.panelButtons.Length;

        for (int i = 0, j = startingSpriteIndex; i < this.panelButtons.Length; i++, j++)
        {
            if (j < this._attributeSprites.Length)
            {
                this.panelButtons[i].panelButtonHelper.centerAttributeSprite.sprite = this._attributeSprites[j];
            }
        }
    }

    private void UpdateSpriteButtons(bool nextPressed)
    {
        if (nextPressed == true)
        {
            this.buttonDisplayOrigin = DisplayOrigin.UpperRight;
        }
        else
        {
            this.buttonDisplayOrigin = DisplayOrigin.UpperLeft;
        }

        StartCoroutine(this.UpdateSpriteButtonsCoroutine());
    }

    private IEnumerator UpdateSpriteButtonsCoroutine()
    {
        //Hide
        this.HideSpriteButtonPanel();

        yield return new WaitForSeconds(this.timeBetweenPageChanges);

        //Update Sprites
        this.LoadButtonSprites();

        yield return new WaitForSeconds(this.timeBetweenPageChanges);

        //Reveal
        this.DisplaySpriteButtonPanel();
    }

    public void PrevPagePressed()
    {
        if (this._currentPage > 0)
        {
            this._currentPage--;
        }

        this.UpdatePageButtons();
        this.UpdateSpriteButtons(false);
    }

    public void NextPagePressed()
    {
        if (this._currentPage < this._maxPages)
        {
            this._currentPage++;
        }

        this.UpdatePageButtons();
        this.UpdateSpriteButtons(true);
    }
}
