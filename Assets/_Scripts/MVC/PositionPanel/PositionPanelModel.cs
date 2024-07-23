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
}
