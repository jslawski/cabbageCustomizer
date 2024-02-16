using System.Collections;
using UnityEngine;
using CharacterCustomizer;

public class AttributeTypeButtonPanel : ButtonPanel
{
    [SerializeField]
    private ButtonPanel _attributeSettingsPanel;
    
    protected override void SelectPanelButtonCallback()
    {
        base.SelectPanelButtonCallback();

        this.SelectAttribute();
    }

    private void SelectAttribute()
    {
        //StartCoroutine(this.TransitionToAttributeSettingsPanel());
    }

}
