using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefaultWidget : SettingsWidget
{
    public override void SetupWidget()
    {
        
    }

    public void ResetAttribute()
    {
        AttributeSettingsManager.ResetAttribute(AttributeSettingsManager.currentAttribute);
        CharacterPreview.instance.UpdateAttribute();
    }
}
