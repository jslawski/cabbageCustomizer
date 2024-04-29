using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttributeSettingsButtonController : MonoBehaviour
{
    private AttributeSettingsButtonModel _model;
    private AttributeSettingsButtonView _view;

    private void Awake()
    {
        this._model = GetComponent<AttributeSettingsButtonModel>();
        this._view = GetComponent<AttributeSettingsButtonView>();
    }

    public void ButtonClicked()
    {
        MasterController.instance.SetCurrentSettingsPanelController(this._model.associatedSettingsPanelController);
    }

    public void SetSelectedStatus(bool isSelected)
    {
        this._model.isSelected = isSelected;
    }

    public void RefreshView()
    {
        this._view.UpdateView();
    }
}
