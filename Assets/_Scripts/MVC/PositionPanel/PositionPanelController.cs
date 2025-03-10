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
    }

    public override void RefreshView()
    {
        base.RefreshView();

        this.SetAttributeInitialPositionValues();

        this._view.UpdateView();
    }
}
