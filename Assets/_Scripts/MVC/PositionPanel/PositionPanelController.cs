using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PositionPanelController : SettingsPanelController
{
    [SerializeField]
    private PositionPanelView _view;
    
    private void Start()
    {
        this.RefreshView();
    }
    
    public override void RefreshView()
    {
        base.RefreshView();

        this._view.UpdateView();
    }
}
