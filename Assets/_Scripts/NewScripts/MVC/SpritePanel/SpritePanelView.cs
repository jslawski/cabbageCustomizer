using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CharacterCustomizer;

public class SpritePanelView : SettingsPanelView
{
    private SpritePanelModel _model;

    protected override void Awake()
    {
        base.Awake();    
    
        this._model = GetComponent<SpritePanelModel>();
    }

    private void UpdateButtonSprites()
    {
        AttributeType currentAttributeType = MasterController.instance.GetCurrentAttributeType();

        if (currentAttributeType == AttributeType.Eyebrows || currentAttributeType == AttributeType.Eyes)
        {
            this.UpdateDoubleAttributeButtonSprites();
        }
        else if (currentAttributeType == AttributeType.EyebrowL || currentAttributeType == AttributeType.EyeL)
        {
            this.UpdateDoubleAttributeLeftButtonSprites();
        }
        else if (currentAttributeType == AttributeType.EyebrowR || currentAttributeType == AttributeType.EyeR)
        {
            this.UpdateDoubleAttributeRightButtonSprites();
        }
        else
        {
            this.UpdateSingleAttributeButtonSprites();
        }
    }

    private void UpdateSingleAttributeButtonSprites()
    {
        int startingSpriteIndex = this._model.pageIndex * this._model.allButtonControllers.Length;

        List<Sprite> attributeSprites = AttributeSpriteDicts.GetAllSprites(MasterController.instance.GetCurrentAttributeType());

        for (int i = 0, j = startingSpriteIndex; i < this._model.allButtonControllers.Length; i++, j++)
        {
            if (j < attributeSprites.Count)
            {
                this._model.allButtonControllers[i].SetVisibleStatus(true);
                this._model.allButtonControllers[i].SetCenterSprite(attributeSprites[j]);
                this._model.allButtonControllers[i].SetSelectedStatus((attributeSprites[j].name == MasterController.instance.GetCurrentAttributeSettingsData().name));
                this._model.allButtonControllers[i].RefreshView();
            }
            else
            {
                this._model.allButtonControllers[i].SetVisibleStatus(false);
            }
        }
    }

    private void UpdateDoubleAttributeButtonSprites()
    {
        //This might take some modifications to the .dll
    
    /*    
    int startingSpriteIndex = this._model.pageIndex * this._model.allButtonControllers.Length;

        if (startingSpriteIndex != 0 && startingSpriteIndex % 2 == 0)
        {
            startingSpriteIndex -= 1;
        }

        List<Sprite> attributeSprites = AttributeSpriteDicts.GetAllSprites(MasterController.instance.GetCurrentAttributeType());

        for (int i = 0, j = startingSpriteIndex; i < this._model.allButtonControllers.Length; i++, j+=2)
        {
            if (j < (attributeSprites.Count - 1))
            {
                this._model.allButtonControllers[i].SetVisibleStatus(true);
                this._model.allButtonControllers[i].SetLeftSprite(attributeSprites[j]);
                this._model.allButtonControllers[i].SetRightSprite(attributeSprites[j+1]);
                this._model.allButtonControllers[i].SetSelectedStatus((attributeSprites[j].name == MasterController.instance.GetCurrentAttributeSettingsData().name));
                this._model.allButtonControllers[i].RefreshView();
            }
            else
            {
                this._model.allButtonControllers[i].SetVisibleStatus(false);
            }
        }

        */
    }

    private void UpdateDoubleAttributeLeftButtonSprites()
    {
        //TODO: Replace this with AttributeDicts.GetAllSprites() once it supports grabbing only L or R sprites    

        string folderName = "CharacterCreator/";

        if (MasterController.instance.GetCurrentAttributeType() == AttributeType.EyebrowL)
        {
            folderName += "Eyebrows";
        }
        else if (MasterController.instance.GetCurrentAttributeType() == AttributeType.EyeL)
        {
            folderName += "Eyes";
        }

        int startingSpriteIndex = this._model.pageIndex * this._model.allButtonControllers.Length;

        if (startingSpriteIndex != 0 && (startingSpriteIndex % 2 != 0))
        {
            startingSpriteIndex -= 1;
        }

        Sprite[] spritesheetSprites = Resources.LoadAll<Sprite>(folderName);

        for (int i = 0, j = startingSpriteIndex; i < this._model.allButtonControllers.Length; i++, j += 2)
        {
            if (j < (spritesheetSprites.Length - 2))
            {
                this._model.allButtonControllers[i].SetVisibleStatus(true);
                this._model.allButtonControllers[i].SetCenterSprite(spritesheetSprites[j]);
                this._model.allButtonControllers[i].SetSelectedStatus((spritesheetSprites[j].name == MasterController.instance.GetCurrentAttributeSettingsData().name));
                this._model.allButtonControllers[i].RefreshView();
            }
            else
            {
                this._model.allButtonControllers[i].SetVisibleStatus(false);
            }
        }
    }

    private void UpdateDoubleAttributeRightButtonSprites()
    {
        //TODO: Replace this with AttributeDicts.GetAllSprites() once it supports grabbing only L or R sprites
        
        string folderName = "CharacterCreator/";

        if (MasterController.instance.GetCurrentAttributeType() == AttributeType.EyebrowR)
        {
            folderName += "Eyebrows";
        }
        else if (MasterController.instance.GetCurrentAttributeType() == AttributeType.EyeR)
        {
            folderName += "Eyes";
        }

        int startingSpriteIndex = this._model.pageIndex * this._model.allButtonControllers.Length;
        
        Sprite[] spritesheetSprites = Resources.LoadAll<Sprite>(folderName);

        if ((startingSpriteIndex != (spritesheetSprites.Length - 1)) && (startingSpriteIndex % 2 == 0))
        {
            startingSpriteIndex += 1;
        }

            for (int i = 0, j = startingSpriteIndex; i < this._model.allButtonControllers.Length; i++, j += 2)
        {
            if (j < (spritesheetSprites.Length - 1))
            {
                this._model.allButtonControllers[i].SetVisibleStatus(true);
                this._model.allButtonControllers[i].SetCenterSprite(spritesheetSprites[j]);
                this._model.allButtonControllers[i].SetSelectedStatus((spritesheetSprites[j].name == MasterController.instance.GetCurrentAttributeSettingsData().name));
                this._model.allButtonControllers[i].RefreshView();
            }
            else
            {
                this._model.allButtonControllers[i].SetVisibleStatus(false);
            }
        }
    }

    private void UpdateSelectedStatus()
    {
        for (int i = 0; i < this._model.allButtonControllers.Length; i++)
        {
            if (this._model.allButtonControllers[i] == this._model.selectedButton)
            {
                this._model.allButtonControllers[i].SetSelectedStatus(true);
            }
            else
            {
                this._model.allButtonControllers[i].SetSelectedStatus(false);
            }

            this._model.allButtonControllers[i].RefreshView();
        }
    }

    public override void UpdateView()
    {
        base.UpdateView();

        this.UpdateButtonSprites();
        this.UpdateSelectedStatus();
    }
}
