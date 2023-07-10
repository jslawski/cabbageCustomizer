using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefaultWidget : SettingsWidget
{
    public override void SetupWidget(AttributeType newType)
    {
        if (newType == AttributeType.Base)
        {
            this.gameObject.SetActive(false);            
        }
        else
        {
            this.gameObject.SetActive(true);
        }
    }

    public void ResetAttribute()
    {
        CharacterPreview.instance.GetAttributeFromType(CharacterPreview.instance.currentAttribute).ResetAttribute();
    }
}
