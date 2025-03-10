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
        for (int i = 0; i < this._model.settingsPanelControllers.Length; i++)
        {
            this._model.settingsPanelControllers[i].RefreshView();
        }
    }
}
