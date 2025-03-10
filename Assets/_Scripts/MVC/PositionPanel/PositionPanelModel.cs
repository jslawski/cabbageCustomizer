using Newtonsoft.Json.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PositionPanelModel : SettingsPanelModel
{
    [SerializeField]
    private ClickPanelModel _clickPanelModel;

    private float _minPositionValue = -0.5f;
    private float _maxPositionValue = 0.5f;

    private int _zValue = 0;

    public float GetXValue()
    {
        return this._clickPanelModel.xValue;
    }

    public float GetYValue()    
    {        
        return this._clickPanelModel.yValue;
    }

    public int GetZValue()
    {
        return this._zValue;
    }

    public void SetXValue(float xValue)
    {            
        if (xValue < this._minPositionValue)
        { 
            xValue = this._minPositionValue;
        }
        if (xValue > this._maxPositionValue)
        {
            xValue = this._maxPositionValue;
        }

        this._clickPanelModel.xValue = xValue;
    }

    public void SetYValue(float yValue) 
    {
        if (yValue < this._minPositionValue)
        {
            yValue = this._minPositionValue;
        }
        if (yValue > this._maxPositionValue)
        {
            yValue = this._maxPositionValue;
        }

        this._clickPanelModel.yValue = yValue;
    }

    public void SetZValue(int zValue)
    {
        this._zValue = zValue;
    }
}
