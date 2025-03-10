using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PositionPanelView : SettingsPanelView
{
    [SerializeField]
    private PositionPanelModel _model;

    [SerializeField]
    private ClickPanelView _clickPanelView;

    public override void UpdateView()
    {
        base.UpdateView();

        this._clickPanelView.UpdateView();
    }
}
