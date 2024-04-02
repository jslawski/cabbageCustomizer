using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CharacterCustomizer;

public class CurrentCustomizerData : MonoBehaviour
{
    public static CurrentCustomizerData instance;

    public AttributeType currentAttributeType;
    public AttributeSettingsData currentAttributeSettingsData;

    public ButtonPanel currentSettingsPanel;

    public void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    public bool IsSingleAttribute()
    {
        return (this.currentAttributeType != AttributeType.Eyebrows &&
                this.currentAttributeType != AttributeType.EyebrowL &&
                this.currentAttributeType != AttributeType.EyebrowR &&
                this.currentAttributeType != AttributeType.Eyes &&
                this.currentAttributeType != AttributeType.EyeL &&
                this.currentAttributeType != AttributeType.EyeR);
    }

    public void SetCurrentAttributeType(AttributeType newAttributeType)
    {
        this.currentAttributeType = newAttributeType;
        //this.currentAttributeSettingsData = AttributeSettings.CurrentSettings.GetAttributeSettingsData(newAttributeType);

        this.currentSettingsPanel.Reveal();
    }

    public void SetCurrentAttributeSettingPanel(ButtonPanel newSettingsPanel)
    {
        if (this.currentSettingsPanel != null)
        {
            this.currentSettingsPanel.Hide();
        }
    
        this.currentSettingsPanel = newSettingsPanel;
        this.currentSettingsPanel.Reveal();
    }
}
