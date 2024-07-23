using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SettingsPanelView : MonoBehaviour
{
    private SettingsPanelModel _baseModel;
    
    public virtual void UpdateView()
    {
        if (this._baseModel == null)
        {
            this._baseModel = GetComponent<SettingsPanelModel>();
        }
    
        this.gameObject.SetActive(this._baseModel.shouldShow);
    }
}
