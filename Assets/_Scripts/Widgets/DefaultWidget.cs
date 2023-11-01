using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CharacterCustomizer;

public class DefaultWidget : SettingsWidget
{
    public override void SetupWidget()
    {
        this.associatedAttribute = null;
    }

    public override void RefreshWidget(CharacterAttribute attObj)
    {
        this.associatedAttribute = attObj;
    }

    public void ResetAttribute()
    {
        this.associatedAttribute.ResetAttribute();
        this.associatedAttribute.UpdateAttributeObject();
        SettingsPanel.instance.RefreshWidgets(this.associatedAttribute.attributeType);
    }
}
