using UnityEngine;
using CharacterCustomizer;

public class MasterController : MonoBehaviour
{
    public static MasterController instance;

    private MasterModel _model;
    private MasterView _view;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }

        this._model = GetComponent<MasterModel>();
        this._view = GetComponent<MasterView>();
    }

    public AttributeType GetCurrentAttributeType()
    {
        return this._model.currentAttributeType;
    }

    public void SetCurrentAttributeType(AttributeType newAttributeType)
    {
        this._model.currentAttributeType = newAttributeType;

        if (newAttributeType != AttributeType.Eyebrows && newAttributeType != AttributeType.Eyes)
        {
            this._model.currentAttributeSettingsData = AttributeSettings.CurrentSettings.GetAttributeSettingsData(newAttributeType);
        }
    }

    public AttributeSettingsData GetCurrentAttributeSettingsData()
    {
        return this._model.currentAttributeSettingsData;
    }

    public void SetCurrentSettingsPanelController(SettingsPanelController newController)
    {
        if (this._model.currentSettingsPanelController != null)
        {
            this._model.currentSettingsPanelController.SetVisibleStatus(false);
        }

        this._model.currentSettingsPanelController = newController;
        this._model.currentSettingsPanelController.SetVisibleStatus(true);
    }

    public void RefreshView()
    {
        this._view.UpdateView();
    }
}
