using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CharacterCustomizer;

public class CurrentCustomizerData : MonoBehaviour
{
    public static CurrentCustomizerData instance;

    public AttributeType currentAttributeType;
    public AttributeSettingsData currentAttributeSettingsData;

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

    public void SetCurrentAttributeType(int newAttributeType)
    {
        this.currentAttributeType = (AttributeType)newAttributeType;
        AttributeSettings.CurrentSettings.GetAttributeSettingsData((AttributeType)newAttributeType);
    }
}
