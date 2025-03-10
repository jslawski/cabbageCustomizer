using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PositionPanelModel : SettingsPanelModel
{
    [SerializeField]
    private ClickPanelModel _clickPanelModel;
    
    public float GetXValue()
    {
        return this._clickPanelModel.xValue;
    }

    public float GetYValue()    
    {
        return this._clickPanelModel.yValue;
    }

    public void SetXValue(float xValue)
    {
        this._clickPanelModel.xValue = xValue;
    }

    public void SetYValue(float yValue) 
    {
        this._clickPanelModel.xValue = yValue;
    }
}
