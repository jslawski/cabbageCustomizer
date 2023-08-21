using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlipWidget : SettingsWidget
{
    public override void SetupWidget()
    {

    }

    public void ToggleFlipX()
    {        
        AttributeSettingsManager.SetFlipX(AttributeSettingsManager.currentAttribute);
    }

    public void ToggleFlipY()
    {
        AttributeSettingsManager.SetFlipY(AttributeSettingsManager.currentAttribute);
    }
}
