using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttributeSettingsPanelController : MonoBehaviour
{
    private AttributeSettingsPanelModel _model;
    private AttributeSettingsPanelView _view;

    private void Awake()
    {
        this._model = GetComponent<AttributeSettingsPanelModel>();
        this._view = GetComponent<AttributeSettingsPanelView>();
    }

    void Start()
    {
        this.RefreshView();
    }

    public void ButtonClicked(AttributeSettingsButtonController selectedButton)
    {
        this._model.selectedButton = selectedButton;
    
        MasterController.instance.RefreshView();

        this.RefreshView();
    }

    public void RefreshView()
    {
        this._view.UpdateView();
    }
}
