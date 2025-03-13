using UnityEngine;
using UnityEngine.UI;

public class PositionPanelView : SettingsPanelView
{
    [SerializeField]
    private PositionPanelModel _model;

    [SerializeField]
    private ClickPanelView _clickPanelView;

    public Slider _depthSlider;

    public override void UpdateView()
    {
        base.UpdateView();

        this._clickPanelView.UpdateView();

        this._depthSlider.value = this._model.GetZValue();
    }
}
