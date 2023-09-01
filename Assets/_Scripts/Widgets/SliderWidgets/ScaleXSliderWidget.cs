using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScaleXSliderWidget : SettingsSliderWidget
{
    public override void RefreshWidget(CabbageAttribute attObj)
    {
        base.RefreshWidget(attObj);

        //Change min/max value here if attribute type is BaseCabbage?
        this.gameObject.SetActive(true);

        this.AnimateSliderToValue(this.associatedAttribute.GetScaleX());
    }

    protected override void UpdateValue()
    {
        this.associatedAttribute.SetScaleX(this.settingSlider.value);

        base.UpdateValue();
    }

    public override void ResetAttributeSetting()
    {
        base.ResetAttributeSetting();

        this.settingSlider.value = this.associatedAttribute.GetScaleX();

        this.associatedAttribute.UpdateAttributeObject();
    }
}
