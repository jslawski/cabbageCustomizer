using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PositionPanelView : MonoBehaviour
{
    private PositionPanelModel _model;

    [SerializeField]
    private Slider xSlider;
    [SerializeField]
    private Slider ySlider;

    private void Awake()
    {
        this._model = GetComponent<PositionPanelModel>();
    }

    public void UpdateView()
    {
        this.xSlider.value = this._model.GetXValue();
        this.ySlider.value = this._model.GetYValue();
    }
}
