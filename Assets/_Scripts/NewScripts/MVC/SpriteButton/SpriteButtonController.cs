using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CharacterCustomizer;

public class SpriteButtonController : MonoBehaviour
{
    private SpriteButtonModel _model;
    private SpriteButtonView _view;

    private void Awake()
    {
        this._model = GetComponent<SpriteButtonModel>();
        this._view = GetComponent<SpriteButtonView>();
    }

    private void EquipSingleAttribute()
    {
        CharacterAttribute currentAttribute = CharacterPreview.instance.GetCachedAttribute(CurrentCustomizerData.instance.currentAttributeType);
        currentAttribute.SetAssetName(this._model.centerSprite.name);
        currentAttribute.UpdateAttributeObject();
    }

    private void EquipDoubleAttribute()
    {
        CharacterAttribute leftAttribute;
        CharacterAttribute rightAttribute;

        if (CurrentCustomizerData.instance.currentAttributeType == AttributeType.Eyebrows)
        {
            leftAttribute = CharacterPreview.instance.GetCachedAttribute(AttributeType.EyebrowL);
            rightAttribute = CharacterPreview.instance.GetCachedAttribute(AttributeType.EyebrowR);

        }
        else if (CurrentCustomizerData.instance.currentAttributeType == AttributeType.Eyebrows)
        {
            leftAttribute = CharacterPreview.instance.GetCachedAttribute(AttributeType.EyebrowL);
            rightAttribute = CharacterPreview.instance.GetCachedAttribute(AttributeType.EyebrowR);
        }
        else
        {
            Debug.LogError("Unknown Attribute Type: " + CurrentCustomizerData.instance.currentAttributeType);
            return;
        }


        leftAttribute.SetAssetName(this._model.leftSprite.name);
        rightAttribute.SetAssetName(this._model.rightSprite.name);
    }

    public void ButtonClicked()
    {
        if (CurrentCustomizerData.instance.currentAttributeType == AttributeType.Eyebrows ||
            CurrentCustomizerData.instance.currentAttributeType == AttributeType.Eyes)
        {
            this.EquipDoubleAttribute();
        }
        else
        {
            this.EquipSingleAttribute();
        }
    }

    public void SetSelectedStatus(bool isSelected)
    {
        this._model.isSelected = isSelected;
    }

    public void SetVisibleStatus(bool isVisible)
    {
        this._model.shouldShow = isVisible;
    }

    public void SetLeftSprite(Sprite newSprite)
    {
        this._model.leftSprite = newSprite;
    }

    public void SetRightSprite(Sprite newSprite)
    {
        this._model.rightSprite = newSprite;
    }

    public void SetCenterSprite(Sprite newSprite)
    {
        this._model.centerSprite = newSprite;
    }

    public void RefreshView()
    {
        this._view.UpdateView();
    }
}
