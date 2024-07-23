using System;
using System.Linq;
using UnityEngine;
using CharacterCustomizer;
using System.Collections.Generic;

public class SpritePanelController : SettingsPanelController
{
    [SerializeField]
    private SpritePanelModel _model;
    [SerializeField]
    private SpritePanelView _view;

    [SerializeField]
    private AttributeTypePanelController _attributeTypePanelController;

    private SpritePagePanelController _spritePagePanelController;

    private void Awake()
    {
        this._model = GetComponent<SpritePanelModel>();
        this._view = GetComponent<SpritePanelView>();
        this._spritePagePanelController = GetComponentInChildren<SpritePagePanelController>();
    }

    private void Start()
    {
        this.RefreshView();
    }

    public int GetPageIndex()
    {
        return this._model.pageIndex;
    }

    public void SetPageIndex(int newIndex)
    {
        this._model.pageIndex = newIndex;
    }

    public int GetMaxPages()
    {
        AttributeType currentAttributeType = MasterController.instance.GetCurrentAttributeType();
        List<Sprite> attributeSprites = AttributeSpriteDicts.GetAllSprites(currentAttributeType);

        if (currentAttributeType == AttributeType.Eyebrows || currentAttributeType == AttributeType.Eyes)
        {
            if ((attributeSprites.Count / 2) % this._model.allButtonControllers.Length == 0)
            {
                return 0;
            }
            else
            {
                return (Mathf.FloorToInt((attributeSprites.Count / 2) / this._model.allButtonControllers.Length));
            }
        }
        else
        {
            if (attributeSprites.Count % this._model.allButtonControllers.Length == 0)
            {
                return 0;
            }
            else
            {
                return (Mathf.FloorToInt(attributeSprites.Count / this._model.allButtonControllers.Length));
            }
        }
    }

    public void ButtonClicked(SpriteButtonController selectedButton)
    {
        this._model.selectedButton = selectedButton;

        this.UpdateAttributeTypePanelButtonSprite();

        this.RefreshView();
    }

    private int GetSingleAttributeStartingPageIndex()
    {
        string spriteName = MasterController.instance.GetCurrentAttributeSettingsData().name;

        if (spriteName == string.Empty)
        {
            return 0;
        }

        List<Sprite> attributeSprites = AttributeSpriteDicts.GetAllSprites(MasterController.instance.GetCurrentAttributeType());

        Sprite targetSprite = attributeSprites.First(attSprite => attSprite.name == spriteName);
        int spriteIndex = attributeSprites.IndexOf(targetSprite);

        int pageIndex = Mathf.FloorToInt(spriteIndex / this._model.allButtonControllers.Length);

        return pageIndex;
    }

    private int GetDoubleAttributeStartingPageIndex()
    {
        return 0;
    }

    private void UpdateAttributeTypePanelButtonSprite()
    {
        AttributeTypeButtonController attributeTypeButtonController = this._attributeTypePanelController.GetSelectedButton();
        AttributeType currentAttributeType = MasterController.instance.GetCurrentAttributeType();

        if (currentAttributeType != AttributeType.Eyebrows && currentAttributeType != AttributeType.Eyes)
        {
            attributeTypeButtonController.SetCenterSprite(this._model.selectedButton.GetCenterSprite());
        }
        else
        {
            attributeTypeButtonController.SetLeftSprite(this._model.selectedButton.GetLeftSprite());
            attributeTypeButtonController.SetRightSprite(this._model.selectedButton.GetRightSprite());
        }

        attributeTypeButtonController.RefreshView();

        this.UpdateDoubleAttributePanelButtonSprite();
    }

    private void UpdateDoubleAttributePanelButtonSprite()
    {
        AttributeType currentAttributeType = MasterController.instance.GetCurrentAttributeType();

        if (currentAttributeType == AttributeType.EyebrowL || currentAttributeType == AttributeType.EyebrowR)
        {
            AttributeTypeButtonController eyebrowsController = this._attributeTypePanelController.GetAttributeTypeButtonController(AttributeType.Eyebrows);

            if (currentAttributeType == AttributeType.EyebrowL)
            {
                eyebrowsController.SetLeftSprite(this._model.selectedButton.GetCenterSprite());
            }
            else
            {
                eyebrowsController.SetRightSprite(this._model.selectedButton.GetCenterSprite());
            }

            eyebrowsController.RefreshView();
        }
        else if (currentAttributeType == AttributeType.EyeL || currentAttributeType == AttributeType.EyeR)
        {
            AttributeTypeButtonController eyesController = this._attributeTypePanelController.GetAttributeTypeButtonController(AttributeType.Eyes);

            if (currentAttributeType == AttributeType.EyeL)
            {
                eyesController.SetLeftSprite(this._model.selectedButton.GetCenterSprite());
            }
            else
            {
                eyesController.SetRightSprite(this._model.selectedButton.GetCenterSprite());
            }

            eyesController.RefreshView();
        }
    }

    private void UpdateButtonsSelectedStatus()
    {
        AttributeType currentAttributeType = MasterController.instance.GetCurrentAttributeType();

        if (currentAttributeType == AttributeType.Eyebrows || currentAttributeType == AttributeType.Eyes)
        {
            this.UpdateDoubleAttributeButtonsSelectedStatus();
        }
        else
        {
            this.UpdateSingleAttributeButtonsSelectedStatus();
        }
    }

    private void UpdateSingleAttributeButtonsSelectedStatus()
    {
        Sprite equippedSprite = AttributeSpriteDicts.GetSprite(MasterController.instance.GetCurrentAttributeType(), MasterController.instance.GetCurrentAttributeSettingsData().name);

        for (int i = 0; i < this._model.allButtonControllers.Length; i++)
        {            
            if (equippedSprite == this._model.allButtonControllers[i].GetCenterSprite())
            {
                this._model.allButtonControllers[i].SetSelectedStatus(true);
            }
            else
            {
                this._model.allButtonControllers[i].SetSelectedStatus(false);
            }
        }
    }

    private void UpdateDoubleAttributeButtonsSelectedStatus()
    {
        Sprite leftEquippedSprite = null;
        Sprite rightEquippedSprite = null;

        AttributeType currentAttributeType = MasterController.instance.GetCurrentAttributeType();

        if (currentAttributeType == AttributeType.Eyebrows)
        {
            leftEquippedSprite = AttributeSpriteDicts.GetSprite(AttributeType.EyebrowL, AttributeSettings.GetAttributeSpriteName(AttributeType.EyebrowL));
            rightEquippedSprite = AttributeSpriteDicts.GetSprite(AttributeType.EyebrowR, AttributeSettings.GetAttributeSpriteName(AttributeType.EyebrowR));
        }
        else if (currentAttributeType == AttributeType.Eyes)
        {
            leftEquippedSprite = AttributeSpriteDicts.GetSprite(AttributeType.EyeL, AttributeSettings.GetAttributeSpriteName(AttributeType.EyeL));
            rightEquippedSprite = AttributeSpriteDicts.GetSprite(AttributeType.EyeR, AttributeSettings.GetAttributeSpriteName(AttributeType.EyeR));
        }

        for (int i = 0; i < this._model.allButtonControllers.Length; i++)
        {
            if (leftEquippedSprite == this._model.allButtonControllers[i].GetLeftSprite() &&
                rightEquippedSprite == this._model.allButtonControllers[i].GetRightSprite())
            {
                this._model.allButtonControllers[i].SetSelectedStatus(true);
            }
            else
            {
                this._model.allButtonControllers[i].SetSelectedStatus(false);
            }
        }
    }

    private void SetPageIndexToStartingPage()
    {
        AttributeType currentAttributeType = MasterController.instance.GetCurrentAttributeType();

        if (currentAttributeType == AttributeType.Eyebrows || currentAttributeType == AttributeType.Eyes)
        {
            this._model.pageIndex = this.GetDoubleAttributeStartingPageIndex();
        }
        else
        {
            this._model.pageIndex = this.GetSingleAttributeStartingPageIndex();
        }
    }

    public override void RefreshView()
    {
        if (this._model.lastAttributeType != MasterController.instance.GetCurrentAttributeType())
        {
            this.SetPageIndexToStartingPage();
            this._model.lastAttributeType = MasterController.instance.GetCurrentAttributeType();
        }

        //Update once to load the button sprites
        this._view.UpdateView();
        //Identify the selected button based on the loaded sprites
        this.UpdateButtonsSelectedStatus();
        //Refresh the buttons again to properly reflect the selected status
        this._view.UpdateView();

        this._spritePagePanelController.RefreshView();
    }
}
