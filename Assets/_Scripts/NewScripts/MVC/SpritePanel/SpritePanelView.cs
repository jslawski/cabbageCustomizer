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
        if (MasterController.instance.GetCurrentAttributeType() == AttributeType.Eyebrows ||
            MasterController.instance.GetCurrentAttributeType() == AttributeType.Eyes)
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
