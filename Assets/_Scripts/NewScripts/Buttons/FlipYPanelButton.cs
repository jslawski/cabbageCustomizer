using CharacterCustomizer;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlipYPanelButton : PanelButton
{
    public override void SelectButton()
    {
        base.SelectButton();
        CharacterAttribute currentAttribute = CharacterPreview.instance.GetCachedAttribute(CurrentCustomizerData.instance.currentAttributeType);
        currentAttribute.SetFlipY();
        currentAttribute.UpdateAttributeObject();
    }
}
