using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SettingsPanelController : MonoBehaviour
{
    [HideInInspector]
    public SettingsPanelModel _baseModel;

    protected virtual void Awake()
    {
        this._baseModel = GetComponent<SettingsPanelModel>();
    }

    public void SetVisibleStatus(bool isVisible)
    {
        this._baseModel.shouldShow = isVisible;
    }

    public virtual void RefreshView()
    { 
        
    }
}
