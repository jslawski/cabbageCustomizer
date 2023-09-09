using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CabbageCustomizer;

public class FlipWidget : SettingsWidget
{
    public override void SetupWidget()
    {
        this.associatedAttribute = null;
    }

    public override void RefreshWidget(CabbageAttribute attObj)
    {
        this.associatedAttribute = attObj;
    }

    public void ToggleFlipX()
    {        
        this.associatedAttribute.SetFlipX();
        this.associatedAttribute.UpdateAttributeObject();
    }

    public void ToggleFlipY()
    {        
        this.associatedAttribute.SetFlipY();
        this.associatedAttribute.UpdateAttributeObject();
    }
}
