using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlipWidget : SettingsWidget
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
}
