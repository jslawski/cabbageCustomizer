using UnityEngine;

public class MasterView : MonoBehaviour
{
    private MasterModel _model;

    private void Awake()
    {
        this._model = GetComponent<MasterModel>();
    }

    public void UpdateView()
    {
        if (this._model.currentSettingsPanelController != null)
        {
            this._model.currentSettingsPanelController.RefreshView();
        }
    }
}
