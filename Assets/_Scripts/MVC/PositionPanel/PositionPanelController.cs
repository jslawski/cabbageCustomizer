using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PositionPanelController : SettingsPanelController
{
    private PositionPanelModel _model;
    private PositionPanelView _view;
    
    protected override void Awake()
    {
        base.Awake();

        this._model = GetComponent<PositionPanelModel>();
        this._view = GetComponent<PositionPanelView>();
    }

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
