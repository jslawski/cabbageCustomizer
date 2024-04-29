using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SettingsPanelView : MonoBehaviour
{
    private SettingsPanelModel _baseModel;

    protected virtual void Awake()
    {
        this._baseModel = GetComponent<SettingsPanelModel>();
    }

    public virtual void UpdateView()
    {
        this.gameObject.SetActive(this._baseModel.shouldShow);
    }
}
