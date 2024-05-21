using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PositionPanelModel : MonoBehaviour
{
    private ClickPanelModel _clickPanelModel;

    private void Awake()
    {
        this._clickPanelModel = GetComponentInChildren<ClickPanelModel>();
    }

    public float GetXValue()
    {
        return this._clickPanelModel.xValue;
    }

    public float GetYValue()    
    {
        return this._clickPanelModel.yValue;
    }
}
