using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CharacterCustomizer;

public class AttributeTypePanelButton : PanelButton
{
    private AttributeTypePanelButtonHelper _attributeTypePanelButtonHelper;

    protected override void Awake()
    {
        base.Awake();

        this._attributeTypePanelButtonHelper = GetComponent<AttributeTypePanelButtonHelper>();
    }

    protected override void SelectedCallback()
    {
        CurrentCustomizerData.currentAttributeType = this._attributeTypePanelButtonHelper.attributeType;
        CurrentCustomizerData.currentAttributeSettingsData = 
            AttributeSettings.CurrentSettings.GetAttributeSettingsData(this._attributeTypePanelButtonHelper.attributeType);

        base.SelectedCallback();
    }   
}
