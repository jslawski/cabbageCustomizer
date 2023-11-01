using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CharacterCustomizer;

public class SpacingSliderWidget : SettingsSliderWidget
{
    public override void RefreshWidget(CharacterAttribute attObj)
    {
        base.RefreshWidget(attObj);

        if (this.associatedAttribute.GetChildren().Length > 0)
        {
            this.gameObject.SetActive(true);            
        }
        else
        {
            this.gameObject.SetActive(false);
            return;
        }

        this.AnimateSliderToValue(this.associatedAttribute.GetVerticalPosition());
    }

    protected override void UpdateValue()
    {
        this.associatedAttribute.SetHorizontalPosition(this.settingSlider.value);

        base.UpdateValue();
    }

    public override void ResetAttributeSetting()
    {
        base.ResetAttributeSetting();

        this.settingSlider.value = AttributeSettings.DefaultSettings.GetAttributeSettingsData(AttributeType.EyebrowR).horPos;

        this.associatedAttribute.UpdateAttributeObject();
    }
}
