using UnityEngine;
using UnityEngine.UI;

public class ScalePanelView : SettingsPanelView
{
    [SerializeField]
    private ScalePanelModel _model;

    [SerializeField]
    private ClickPanelView _clickPanelView;

    [SerializeField]
    private Toggle _toggle;

    [SerializeField]
    private Image _previewImage;

    private float _defaultRectSize = 425f;

    public override void UpdateView()
    {
        base.UpdateView();

        this._clickPanelView.UpdateView();

        //this._toggle.isOn = this._model.IsLockedXY();

        this._previewImage.sprite = this._model.GetPreviewSprite();
        this._previewImage.rectTransform.sizeDelta = new Vector2(this._model.GetXValue() * this._defaultRectSize, this._model.GetYValue() * this._defaultRectSize);
    }
}
