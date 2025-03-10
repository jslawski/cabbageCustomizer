using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ClickPanelView : MonoBehaviour
{
    [SerializeField]
    private ClickPanelModel _model;

    public Slider xSlider;
    public Slider ySlider;

    public void UpdateView()
    {
        this.xSlider.value = this._model.xValue;
        this.ySlider.value = this._model.yValue;
    }
}
