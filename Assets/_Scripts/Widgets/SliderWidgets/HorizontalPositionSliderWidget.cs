using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CabbageCustomizer;

public class HorizontalPositionSliderWidget : SettingsSliderWidget
{
    public override void RefreshWidget(CabbageAttribute attObj)
    {
        base.RefreshWidget(attObj);

        if (this.associatedAttribute.attributeType == AttributeType.BaseCabbage ||
            this.associatedAttribute.GetChildren().Length > 0)
        {
            this.gameObject.SetActive(false);
            return;
        }
        else
        {
            this.gameObject.SetActive(true);
        }
        
        this.AnimateSliderToValue(this.associatedAttribute.GetHorizontalPosition());
    }

    protected override void UpdateValue()
    {
        this.associatedAttribute.SetHorizontalPosition(this.settingSlider.value);

        base.UpdateValue();
    }

    public override void ResetAttributeSetting()
    {
        base.ResetAttributeSetting();

        this.settingSlider.value = this.associatedAttribute.GetHorizontalPosition();

        this.associatedAttribute.UpdateAttributeObject();        
    }
}
