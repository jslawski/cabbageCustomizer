using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CabbageCustomizer;

public class DepthSliderWidget : SettingsSliderWidget
{
    public override void RefreshWidget(CabbageAttribute attObj)
    {
        base.RefreshWidget(attObj);

        this.gameObject.SetActive(true);

        this.AnimateSliderToValue(this.associatedAttribute.GetDepth());
    }

    protected override void UpdateValue()
    {
        this.associatedAttribute.SetDepth((int)this.settingSlider.value);

        base.UpdateValue();
    }

    public override void ResetAttributeSetting()
    {
        base.ResetAttributeSetting();

        this.settingSlider.value = this.associatedAttribute.GetDepth();

        this.associatedAttribute.UpdateAttributeObject();
    }
}
