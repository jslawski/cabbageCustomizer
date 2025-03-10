using CharacterCustomizer;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PositionPanelController : SettingsPanelController
{
    [SerializeField]
    private PositionPanelModel _model;
    [SerializeField]
    private PositionPanelView _view;

    private void Awake()
    {
        this._model = GetComponent<PositionPanelModel>();
        this._view = GetComponent<PositionPanelView>();
    }

    private void SetAttributeInitialPositionValues()
    {
        AttributeSettingsData settingsData = MasterController.instance.GetCurrentAttributeSettingsData();

        this._model.SetXValue(settingsData.horPos);
        this._model.SetYValue(settingsData.verPos);
        this._model.SetZValue(settingsData.dep);
    }

    public override void UpdateAttributeSetting()
    {
        base.UpdateAttributeSetting();

        CharacterAttribute currentAttribute = CharacterPreview.instance.GetCachedAttribute(MasterController.instance.GetCurrentAttributeType());
        currentAttribute.SetHorizontalPosition(this._model.GetXValue());
        currentAttribute.SetVerticalPosition(this._model.GetYValue());
        currentAttribute.UpdateAttributeObject();
    }

    public void UpdateDepth()
    {
        CharacterAttribute currentAttribute = CharacterPreview.instance.GetCachedAttribute(MasterController.instance.GetCurrentAttributeType());
        currentAttribute.SetDepth((int)this._view._depthSlider.value);
        currentAttribute.UpdateAttributeObject();

        this._model.SetZValue((int)this._view._depthSlider.value);
    }

    public void ResetXPosition()
    {
        CharacterAttribute currentAttribute = CharacterPreview.instance.GetCachedAttribute(MasterController.instance.GetCurrentAttributeType());
        currentAttribute.ResetAttributeSetting(AttributeSettingType.Horizontal_Position);

        this._model.SetXValue(currentAttribute.GetHorizontalPosition());

        this.RefreshView();
    }

    public void ResetYPosition()
    {
        CharacterAttribute currentAttribute = CharacterPreview.instance.GetCachedAttribute(MasterController.instance.GetCurrentAttributeType());
        currentAttribute.ResetAttributeSetting(AttributeSettingType.Vertical_Position);

        this._model.SetYValue(currentAttribute.GetVerticalPosition());

        this.RefreshView();
    }

    public void ResetZPosition()
    {
        CharacterAttribute currentAttribute = CharacterPreview.instance.GetCachedAttribute(MasterController.instance.GetCurrentAttributeType());
        currentAttribute.ResetAttributeSetting(AttributeSettingType.Depth);

        this._model.SetZValue(currentAttribute.GetDepth());

        this.RefreshView();
    }

    public override void RefreshView()
    {
        base.RefreshView();

        this.SetAttributeInitialPositionValues();

        this._view.UpdateView();
    }
}
