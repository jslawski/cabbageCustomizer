using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CabbageCustomizer;

public class VerticalPositionSliderWidget : SettingsSliderWidget
{
    public override void RefreshWidget(CabbageAttribute attObj)
    {
        base.RefreshWidget(attObj);

        if (this.associatedAttribute.attributeType == AttributeType.BaseCabbage)
        {
            this.gameObject.SetActive(false);
            return;
        }
        else
        {
            this.gameObject.SetActive(true);
        }

        this.AnimateSliderToValue(this.associatedAttribute.GetVerticalPosition());
    }

    protected override void UpdateValue()
    {
        this.associatedAttribute.SetVerticalPosition(this.settingSlider.value);

        base.UpdateValue();
    }

    public override void ResetAttributeSetting()
    {
        base.ResetAttributeSetting();

        this.settingSlider.value = this.associatedAttribute.GetVerticalPosition();

        this.associatedAttribute.UpdateAttributeObject();
    }
}
