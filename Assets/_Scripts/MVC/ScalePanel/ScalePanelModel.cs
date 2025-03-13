using UnityEngine;

public class ScalePanelModel : SettingsPanelModel
{
    [SerializeField]
    private ClickPanelModel _clickPanelModel;

    private float _minScaleValue = 0.1f;
    private float _maxScaleValue = 2.0f;

    private bool _lockedXY = false;

    private Sprite _previewSprite;

    public float GetXValue()
    {
        return this._clickPanelModel.xValue;
    }

    public float GetYValue()
    {
        return this._clickPanelModel.yValue;
    }

    public bool IsLockedXY()
    {
        return this._lockedXY;
    }

    public Sprite GetPreviewSprite()
    {
        return this._previewSprite;
    }

    public void SetXValue(float xValue)
    {
        if (xValue < this._minScaleValue)
        {
            xValue = this._minScaleValue;
        }
        if (xValue > this._maxScaleValue)
        {
            xValue = this._maxScaleValue;
        }

        this._clickPanelModel.xValue = xValue;
    }

    public void SetYValue(float yValue)
    {
        if (yValue < this._minScaleValue)
        {
            yValue = this._minScaleValue;
        }
        if (yValue > this._maxScaleValue)
        {
            yValue = this._maxScaleValue;
        }

        this._clickPanelModel.yValue = yValue;
    }

    public void SetLockedXY(bool isLocked)
    { 
        this._lockedXY = isLocked;
    }

    public void SetPreviewSprite(Sprite newSprite)
    { 
        this._previewSprite = newSprite;
    }
}
