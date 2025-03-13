using CharacterCustomizer;
using UnityEngine;

public class ScalePanelController : SettingsPanelController
{
    [SerializeField]
    private ScalePanelModel _model;

    [SerializeField]
    private ScalePanelView _view;

    private void Awake()
    {
        this._model = GetComponent<ScalePanelModel>();
        this._view = GetComponent<ScalePanelView>();
    }

    private void SetAttributeInitialScaleValues()
    {
        AttributeSettingsData settingsData = MasterController.instance.GetCurrentAttributeSettingsData();
        Sprite attributeSprite = AttributeSpriteDicts.GetSprite(MasterController.instance.GetCurrentAttributeType(), settingsData.name);

        this._model.SetXValue(settingsData.scaleX);
        this._model.SetYValue(settingsData.scaleY);
        this._model.SetPreviewSprite(attributeSprite);
    }

    public override void UpdateAttributeSetting()
    {
        base.UpdateAttributeSetting();

        CharacterAttribute currentAttribute = CharacterPreview.instance.GetCachedAttribute(MasterController.instance.GetCurrentAttributeType());
        currentAttribute.SetScaleX(this._model.GetXValue());
        currentAttribute.SetScaleY(this._model.GetYValue());
        currentAttribute.UpdateAttributeObject();

        this._view.UpdateView();
    }

    public void UpdateXYLocked()
    { 
        //Do this later
    }

    public void ResetXScale()
    {
        CharacterAttribute currentAttribute = CharacterPreview.instance.GetCachedAttribute(MasterController.instance.GetCurrentAttributeType());
        currentAttribute.ResetAttributeSetting(AttributeSettingType.Scale_X);

        this._model.SetXValue(currentAttribute.GetScaleX());

        this.RefreshView();
    }

    public void ResetYScale()
    {
        CharacterAttribute currentAttribute = CharacterPreview.instance.GetCachedAttribute(MasterController.instance.GetCurrentAttributeType());
        currentAttribute.ResetAttributeSetting(AttributeSettingType.Scale_Y);

        this._model.SetYValue(currentAttribute.GetScaleY());

        this.RefreshView();
    }

    public override void RefreshView()
    {
        base.RefreshView();

        this.SetAttributeInitialScaleValues();

        this._view.UpdateView();
    }
}
