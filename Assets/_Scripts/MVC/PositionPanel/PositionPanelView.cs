using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PositionPanelView : SettingsPanelView
{
    [SerializeField]
    private PositionPanelModel _model;

    [SerializeField]
    private Slider xSlider;
    [SerializeField]
    private Slider ySlider;
    
    public override void UpdateView()
    {
        base.UpdateView();
    
        this.xSlider.value = this._model.GetXValue();
        this.ySlider.value = this._model.GetYValue();
    }
}
