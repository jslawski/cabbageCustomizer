using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CharacterCustomizer;

public class ScaleYSliderWidget : SettingsSliderWidget
{
    public override void RefreshWidget(CharacterAttribute attObj)
    {
        base.RefreshWidget(attObj);

        if (attObj.attributeType == AttributeType.BaseCabbage)
        {
            this.SetMinMaxValues(0.5f, 2.0f);            
        }
        else
        {
            this.SetMinMaxValues(0.25f, 5.0f);            
        }

        this.gameObject.SetActive(true);

        this.AnimateSliderToValue(this.associatedAttribute.GetScaleY());
    }

    protected override void UpdateValue()
    {
        this.associatedAttribute.SetScaleY(this.settingSlider.value);

        base.UpdateValue();
    }

    public override void ResetAttributeSetting()
    {
        base.ResetAttributeSetting();

        this.settingSlider.value = this.associatedAttribute.GetScaleY();

        this.associatedAttribute.UpdateAttributeObject();
    }
}