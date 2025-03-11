using System.Collections.Generic;
using UnityEngine;
using CharacterCustomizer;

public class SpritePanelView : SettingsPanelView
{
    [SerializeField]
    private SpritePanelModel _model;

    private void Awake()
    {
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
            }
            else
            {
                this._model.allButtonControllers[i].SetVisibleStatus(false);
            }

            this._model.allButtonControllers[i].RefreshView();
        }
    }

    private void UpdateDoubleAttributeButtonSprites()
    {
        int startingSpriteIndex = this._model.pageIndex * this._model.allButtonControllers.Length * 2;

        if (startingSpriteIndex != 0 && (startingSpriteIndex % 2 != 0))
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
                this._model.allButtonControllers[i].SetRightSprite(attributeSprites[j + 1]);
            }
            else
            {
                this._model.allButtonControllers[i].SetVisibleStatus(false);
            }
            this._model.allButtonControllers[i].RefreshView();
        }
    }

    public override void UpdateView()
    {
        base.UpdateView();

        this.UpdateButtonSprites();
    }
}
