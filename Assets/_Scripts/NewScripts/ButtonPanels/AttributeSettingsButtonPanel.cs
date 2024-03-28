using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttributeSettingsButtonPanel : ButtonPanel
{
    public override void ButtonSelected(PanelButtonController selectedButton)
    {
        base.ButtonSelected(selectedButton);

        this.HighlightButtonAtIndex(this.selectedButtonIndex_);
    }
}
