using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CharacterCustomizer;

public class RotationSliderWidget : SettingsSliderWidget
{
    public override void RefreshWidget(CharacterAttribute attObj)
    {
        base.RefreshWidget(attObj);

        this.gameObject.SetActive(true);

        this.AnimateSliderToValue(-this.GetInitialRotation());
    }

    protected override void UpdateValue()
    {
        //Do this so you can map right to clockwise and left to counterclockwise
        float adjustedSliderValue = -this.settingSlider.value;
        this.associatedAttribute.SetRotation(adjustedSliderValue);

        base.UpdateValue();
    }

    private float GetInitialRotation()
    {
        float adjustedRotationValue = this.associatedAttribute.GetRotation();

        if (adjustedRotationValue > 180)
        {
            adjustedRotationValue -= 360;
        }

        return adjustedRotationValue;
    }

    public override void ResetAttributeSetting()
    {
        base.ResetAttributeSetting();

        this.settingSlider.value = this.associatedAttribute.GetRotation();

        this.associatedAttribute.UpdateAttributeObject();
    }
}
