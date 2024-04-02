using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CharacterCustomizer;

public class SpritePanelView : MonoBehaviour
{
    private SpritePanelModel _model;

    private void Awake()
    {
        this._model = GetComponent<SpritePanelModel>();
    }

    private void UpdateButtonSprites()
    {
        if (CurrentCustomizerData.instance.currentAttributeType == AttributeType.Eyebrows ||
            CurrentCustomizerData.instance.currentAttributeType == AttributeType.Eyes)
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

        List<Sprite> attributeSprites = AttributeSpriteDicts.GetAllSprites(CurrentCustomizerData.instance.currentAttributeType);

        for (int i = 0, j = startingSpriteIndex; i < this._model.allButtonControllers.Length; i++, j++)
        {
            if (j < attributeSprites.Count)
            {
                this._model.allButtonControllers[i].SetVisibleStatus(true);
                this._model.allButtonControllers[i].SetCenterSprite(attributeSprites[j]);
                this._model.allButtonControllers[i].SetSelectedStatus((attributeSprites[j].name == CurrentCustomizerData.instance.currentAttributeSettingsData.name));
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

    public void UpdateView()
    {
        this.UpdateButtonSprites();
    }
}
