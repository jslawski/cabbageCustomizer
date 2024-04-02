using UnityEngine;
using CharacterCustomizer;

public class AttributeTypeButtonController : MonoBehaviour
{
    private AttributeTypeButtonModel _model;
    private AttributeTypeButtonView _view;

    private void Awake()
    {
        this._model = GetComponent<AttributeTypeButtonModel>();
        this._view = GetComponent<AttributeTypeButtonView>();
    }

    private void InitializeSprites()
    {
        if (this._model.attributeType == AttributeType.Eyebrows)
        {
            string leftSpriteName = AttributeSettings.CurrentSettings.GetAttributeSettingsData(AttributeType.EyebrowL).name;
            string rightSpriteName = AttributeSettings.CurrentSettings.GetAttributeSettingsData(AttributeType.EyebrowR).name;
            this.SetLeftSprite(AttributeAssetManager.GetAttributeSprite(AttributeType.EyebrowL, leftSpriteName));
            this.SetRightSprite(AttributeAssetManager.GetAttributeSprite(AttributeType.EyebrowR, rightSpriteName));
        }
        else if (this._model.attributeType == AttributeType.Eyes)
        {
            string leftSpriteName = AttributeSettings.CurrentSettings.GetAttributeSettingsData(AttributeType.EyeL).name;
            string rightSpriteName = AttributeSettings.CurrentSettings.GetAttributeSettingsData(AttributeType.EyeR).name;
            this.SetLeftSprite(AttributeAssetManager.GetAttributeSprite(AttributeType.EyeL, leftSpriteName));
            this.SetRightSprite(AttributeAssetManager.GetAttributeSprite(AttributeType.EyeR, rightSpriteName));
        }
        else
        {
            string spriteName = AttributeSettings.CurrentSettings.GetAttributeSettingsData(this._model.attributeType).name;
            this.SetCenterSprite(AttributeAssetManager.GetAttributeSprite(this._model.attributeType, spriteName));
        }
    }

    public void ButtonClicked()
    {
        CurrentCustomizerData.instance.SetCurrentAttributeType(this._model.attributeType);
    }

    public void SetSelectedStatus(bool isSelected)
    {
        this._model.isSelected = isSelected;
    }

    public void SetVisibleStatus(bool isVisible)
    {
        this._model.shouldShow = isVisible;
        this.InitializeSprites();
    }

    public void SetLeftSprite(Sprite newSprite)
    {
        this._model.leftSprite = newSprite;
        this._model.isEquipped = (newSprite != null);        
    }

    public void SetRightSprite(Sprite newSprite)
    {
        this._model.rightSprite = newSprite;
        this._model.isEquipped = (newSprite != null);
    }

    public void SetCenterSprite(Sprite newSprite)
    {
        this._model.centerSprite = newSprite;
        this._model.isEquipped = (newSprite != null);
    }

    public void RefreshView()
    {
        this._view.UpdateView();
    }
}
