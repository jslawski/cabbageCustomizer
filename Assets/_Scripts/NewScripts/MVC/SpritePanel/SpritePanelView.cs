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
    
        int startingSpriteIndex = this._model.pageIndex * this._model.allButtonControllers.Length;

        if (startingSpriteIndex != 0 && (startingSpriteIndex % 2 != 0))
        {
            startingSpriteIndex -= 1;
        }

        List<Sprite> attributeSprites = AttributeSpriteDicts.GetAllSprites(MasterController.instance.GetCurrentAttributeType());

        for (int i = 0, j = startingSpriteIndex; i < this._model.allButtonControllers.Length; i++, j+=2)
        {
            if (j < (attributeSprites.Count - 2))
            {
                this._model.allButtonControllers[i].SetVisibleStatus(true);
                this._model.allButtonControllers[i].SetLeftSprite(attributeSprites[j]);
                this._model.allButtonControllers[i].SetRightSprite(attributeSprites[j + 1]);
                this._model.allButtonControllers[i].SetSelectedStatus(this.GetDoubleAttributeButtonSelectedStatus(attributeSprites[j].name, attributeSprites[j + 1].name));
                this._model.allButtonControllers[i].RefreshView();
            }
            else
            {
                this._model.allButtonControllers[i].SetVisibleStatus(false);
            }
        }
    }

    private bool GetDoubleAttributeButtonSelectedStatus(string leftSpriteName, string rightSpriteName)
    {
        string leftEquippedName = string.Empty;
        string rightEquippedName = string.Empty;

        if (MasterController.instance.GetCurrentAttributeType() == AttributeType.Eyebrows)
        {
            leftEquippedName = AttributeSettings.CurrentSettings.GetAttributeSettingsData(AttributeType.EyebrowL).name;
            rightEquippedName = AttributeSettings.CurrentSettings.GetAttributeSettingsData(AttributeType.EyebrowR).name;
        }
        else if (MasterController.instance.GetCurrentAttributeType() == AttributeType.Eyes)
        {
            leftEquippedName = AttributeSettings.CurrentSettings.GetAttributeSettingsData(AttributeType.EyeL).name;
            rightEquippedName = AttributeSettings.CurrentSettings.GetAttributeSettingsData(AttributeType.EyeR).name;
        }
        else
        {
            Debug.LogError("Unknown AttributeType: " + MasterController.instance.GetCurrentAttributeType());
        }

        if (leftEquippedName == string.Empty || rightEquippedName == string.Empty)
        {
            return false;
        }

        return ((leftSpriteName == leftEquippedName) && (rightSpriteName == rightEquippedName));
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
