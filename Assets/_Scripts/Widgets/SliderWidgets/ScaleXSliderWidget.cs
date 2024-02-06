using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CharacterCustomizer;

public class ScaleXSliderWidget : SettingsSliderWidget
{
    public override void RefreshWidget(CharacterAttribute attObj)
    {
        base.RefreshWidget(attObj);

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
